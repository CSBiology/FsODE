﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Copyright (c) 2003-2004, dnAnalytics. All rights reserved.
//
//    modified for Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2011 Dr. Dirk Lellinger
//
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; either version 2 of the License, or
//    (at your option) any later version.
//
//    This program is distributed in the hope that it will be useful,
//    but WITHOUT ANY WARRANTY; without even the implied warranty of
//    MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//    GNU General Public License for more details.
//
//    You should have received a copy of the GNU General Public License
//    along with this program; if not, write to the Free Software
//    Foundation, Inc., 675 Mass Ave, Cambridge, MA 02139, USA.
//
/////////////////////////////////////////////////////////////////////////////

#endregion Copyright

/*
 * FloatCholeskyDecomp.cs
 * Managed code is a port of JAMA and Jampack code.
 * Copyright (c) 2003-2004, dnAnalytics Project. All rights reserved.
*/

using System;
using System.Collections.Generic;

namespace Altaxo.Calc.LinearAlgebra
{
  ///<summary>This class computes the Cholesky factorization of a general n by n <c>FloatMatrix</c>.</summary>
  /// <remarks>
  /// <para>Copyright (c) 2003-2004, dnAnalytics Project. All rights reserved. See <a>http://www.dnAnalytics.net</a> for details.</para>
  /// <para>Adopted to Altaxo (c) 2005 Dr. Dirk Lellinger.</para>
  /// </remarks>
  public sealed class FloatCholeskyDecomp : Algorithm
  {
    private readonly int order;
    private bool ispd = true;
#nullable disable
    private FloatMatrix matrix;
    private FloatMatrix l;
#nullable enable

    ///<summary>Constructor for Cholesky decomposition class. The constructor performs the factorization of a symmetric positive
    ///definite matrax and the Cholesky factored matrix is accessible by the <c>Factor</c> property. The factor is the lower
    ///triangular factor.</summary>
    ///<param name="matrix">The matrix to factor.</param>
    ///<exception cref="ArgumentNullException">matrix is null.</exception>
    ///<exception cref="NotSquareMatrixException">matrix is not square.</exception>
    ///<remarks>This class only uses the lower triangle of the input matrix. It ignores the
    ///upper triangle.</remarks>
    public FloatCholeskyDecomp(IROMatrix<float> matrix)
    {
      if (matrix is null)
      {
        throw new System.ArgumentNullException("matrix cannot be null.");
      }

      if (matrix.RowCount != matrix.ColumnCount)
      {
        throw new NotSquareMatrixException("Matrix must be square.");
      }

      order = matrix.ColumnCount;
      this.matrix = new FloatMatrix(matrix);
    }

    ///<summary>Computes the algorithm.</summary>
    protected override void InternalCompute()
    {
#if MANAGED
      l = new FloatMatrix(order);
      for (int j = 0; j < order; j++)
      {
        float[] rowj = l.data[j];
        float d = 0.0f;
        for (int k = 0; k < j; k++)
        {
          float[] rowk = l.data[k];
          float s = 0.0f;
          for (int i = 0; i < k; i++)
          {
            s += rowk[i] * rowj[i];
          }
          rowj[k] = s = (matrix.data[j][k] - s) / l.data[k][k];
          d = d + s * s;
        }
        d = matrix.data[j][j] - d;
        if (d <= 0.0)
        {
          ispd = false;
          return;
        }
        l.data[j][j] = (float)System.Math.Sqrt(System.Math.Max(d, 0.0));
        for (int k = j + 1; k < order; k++)
        {
          l.data[j][k] = 0.0f;
        }
      }

#else
            float[] factor = new float[matrix.data.Length];
            Array.Copy(matrix.data, factor, matrix.data.Length);
            int status = Lapack.Potrf.Compute(Lapack.UpLo.Lower, order, factor, order);
            if (status != 0 ) {
                ispd = false;
            }
            l = new FloatMatrix(order);
            l.data = factor;
            for (int i = 0; i < order; i++) {
                for (int j = 0; j < order; j++) {
                    if ( j > i) {
                        l.data[j*order+i] = 0;
                    }
                }
            }

#endif
    }

    ///<summary>Return a value indicating whether the matrix is positive definite.</summary>
    ///<returns>true if the matrix is singular; otherwise, false.</returns>
    public bool IsPositiveDefinite
    {
      get
      {
        Compute();
        return ispd;
      }
    }

    ///<summary>Returns the Cholesky factored matrix (lower triangular form).</summary>
    ///<returns>the lower Cholesky factored matrix.</returns>
    public FloatMatrix Factor
    {
      get
      {
        Compute();
        return l;
      }
    }

    ///<summary>Calculates the determinant of the matrix.</summary>
    ///<returns>the determinant of the matrix.</returns>
    ///<exception cref="NotPositiveDefiniteException">A is not positive definite.</exception>
    public float GetDeterminant()
    {
      Compute();
      if (!ispd)
      {
        throw new NotPositiveDefiniteException();
      }
      float ret = 1.0f;
      for (int j = 0; j < order; j++)
      {
#if MANAGED
        ret *= (l.data[j][j] * l.data[j][j]);
#else
                ret *= (l.data[j*order+j]*l.data[j*order+j]);
#endif
      }
      return ret;
    }

    ///<summary>Solves a system on linear equations, AX=B, where A is the factored matrixed.</summary>
    ///<param name="B">RHS side of the system.</param>
    ///<returns>the solution matrix, X.</returns>
    ///<exception cref="ArgumentNullException">B is null.</exception>
    ///<exception cref="NotPositiveDefiniteException">A is not positive definite.</exception>
    ///<exception cref="ArgumentException">The number of rows of A and B must be the same.</exception>
    public FloatMatrix Solve(IROMatrix<float> B)
    {
      if (B is null)
      {
        throw new System.ArgumentNullException("B cannot be null.");
      }
      Compute();
      if (!ispd)
      {
        throw new NotPositiveDefiniteException();
      }
      else
      {
        if (B.RowCount != order)
        {
          throw new System.ArgumentException("Matrix row dimensions must agree.");
        }
#if MANAGED
        // Copy right hand side.
        int cols = B.ColumnCount;
        var X = new FloatMatrix(B);
        for (int c = 0; c < cols; c++)
        {
          // Solve L*Y = B;
          for (int i = 0; i < order; i++)
          {
            float sum = B[i, c];
            for (int k = i - 1; k >= 0; k--)
            {
              sum -= l.data[i][k] * X.data[k][c];
            }
            X.data[i][c] = sum / l.data[i][i];
          }

          // Solve L'*X = Y;
          for (int i = order - 1; i >= 0; i--)
          {
            float sum = X.data[i][c];
            for (int k = i + 1; k < order; k++)
            {
              sum -= l.data[k][i] * X.data[k][c];
            }
            X.data[i][c] = sum / l.data[i][i];
          }
        }

        return X;
#else
                float[] rhs = FloatMatrix.ToLinearArray(B);
                Lapack.Potrs.Compute(Lapack.UpLo.Lower,order,B.Columns,l.data,order,rhs,B.Rows);
                FloatMatrix ret = new FloatMatrix(order,B.Columns);
                ret.data = rhs;
                return ret;
#endif
      }
    }

    ///<summary>Solves a system on linear equations, AX=B, where A is the factored matrixed.</summary>
    ///<param name="B">RHS side of the system.</param>
    ///<returns>the solution vector, X.</returns>
    ///<exception cref="ArgumentNullException">B is null.</exception>
    ///<exception cref="NotPositiveDefiniteException">A is not positive definite.</exception>
    ///<exception cref="ArgumentException">The number of rows of A and the length of B must be the same.</exception>
    public FloatVector Solve(IReadOnlyList<float> B)
    {
      if (B is null)
      {
        throw new System.ArgumentNullException("B cannot be null.");
      }
      Compute();
      if (!ispd)
      {
        throw new NotPositiveDefiniteException();
      }
      else
      {
        if (B.Count != order)
        {
          throw new System.ArgumentException("The length of B must be the same as the order of the matrix.");
        }
#if MANAGED
        // Copy right hand side.
        var X = new FloatVector(B);
        var xarray = X.GetInternalData();
        // Solve L*Y = B;
        for (int i = 0; i < order; i++)
        {
          float sum = B[i];
          for (int k = i - 1; k >= 0; k--)
          {
            sum -= l.data[i][k] * xarray[k];
          }
          xarray[i] = sum / l.data[i][i];
        }
        // Solve L'*X = Y;
        for (int i = order - 1; i >= 0; i--)
        {
          float sum = xarray[i];
          for (int k = i + 1; k < order; k++)
          {
            sum -= l.data[k][i] * xarray[k];
          }
          xarray[i] = sum / l.data[i][i];
        }

        return X;
#else
                float[] rhs = FloatMatrix.ToLinearArray(B);
                Lapack.Potrs.Compute(Lapack.UpLo.Lower,order,1,l.data,order,rhs,B.Length);
                FloatVector ret = new FloatVector(order,B.Length);
                ret.data = rhs;
                return ret;
#endif
      }
    }

    ///<summary>Calculates the inverse of the matrix.</summary>
    ///<returns>the inverse of the matrix.</returns>
    ///<exception cref="NotPositiveDefiniteException">A is not positive definite.</exception>
    public FloatMatrix GetInverse()
    {
      Compute();
      if (!ispd)
      {
        throw new NotPositiveDefiniteException();
      }
      else
      {
#if MANAGED
        var ret = FloatMatrix.CreateIdentity(order);
        ret = Solve(ret);
        return ret;
#else
                float[] inverse = new float[l.data.Length];
                Array.Copy(l.data,inverse,l.data.Length);
                Lapack.Potri.Compute(Lapack.UpLo.Lower, order, inverse, order);
                FloatMatrix ret = new FloatMatrix(order,order);
                ret.data = inverse;
                for (int i = 0; i < order; i++) {
                    for (int j = 0; j < order; j++) {
                        if ( j > i) {
                            ret.data[j*order+i] =ret.data[i*order+j];
                        }
                    }
                }
                return ret;
#endif
      }
    }
  }
}
