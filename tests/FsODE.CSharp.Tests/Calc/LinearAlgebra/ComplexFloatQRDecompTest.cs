﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
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

using System;
using Altaxo.Calc;
using Altaxo.Calc.LinearAlgebra;
using Xunit;

namespace AltaxoTest.Calc.LinearAlgebra
{
  
  public class ComplexFloatQRDecompTest
  {
    [Fact]
    public void NullTest()
    {
      Assert.Throws<ArgumentNullException>(() =>
      {
        var test = new ComplexFloatQRDecomp(null);
      });
    }

    [Fact]
    public void SquareDecomp()
    {
      var a = new ComplexFloatMatrix(3)
      {
        [0, 0] = new ComplexFloat(1.1f, 1.1f),
        [0, 1] = new ComplexFloat(2.2f, -2.2f),
        [0, 2] = new ComplexFloat(3.3f, 3.3f),
        [1, 0] = new ComplexFloat(4.4f, -4.4f),
        [1, 1] = new ComplexFloat(5.5f, 5.5f),
        [1, 2] = new ComplexFloat(6.6f, -6.6f),
        [2, 0] = new ComplexFloat(7.7f, 7.7f),
        [2, 1] = new ComplexFloat(8.8f, -8.8f),
        [2, 2] = new ComplexFloat(9.9f, 9.9f)
      };

      var qrd = new ComplexFloatQRDecomp(a);
      ComplexFloatMatrix qq = qrd.Q.GetConjugateTranspose() * qrd.Q;
      ComplexFloatMatrix qr = qrd.Q * qrd.R;
      var I = ComplexFloatMatrix.CreateIdentity(3);

      // determine the maximum relative error
      double MaxError = 0.0;
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; i < 3; i++)
        {
          double E = ComplexMath.Absolute((qq[i, j] - I[i, j]));
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }

      Assert.True(MaxError < 1.0E-6);

      MaxError = 0.0;
      for (int i = 0; i < 3; i++)
      {
        for (int j = 0; i < 3; i++)
        {
          double E = ComplexMath.Absolute((qr[i, j] - a[i, j]) / a[i, j]);
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }

      Assert.True(MaxError < 2.4E-6);
    }

    [Fact]
    public void WideDecomp()
    {
      var a = new ComplexFloatMatrix(2, 4)
      {
        [0, 0] = new ComplexFloat(1.1f, 1.1f),
        [0, 1] = new ComplexFloat(2.2f, -2.2f),
        [0, 2] = new ComplexFloat(3.3f, 3.3f),
        [0, 3] = new ComplexFloat(4.4f, -4.4f),
        [1, 0] = new ComplexFloat(5.5f, 5.5f),
        [1, 1] = new ComplexFloat(6.6f, -6.6f),
        [1, 2] = new ComplexFloat(7.7f, 7.7f),
        [1, 3] = new ComplexFloat(8.8f, -8.8f)
      };

      var qrd = new ComplexFloatQRDecomp(a);
      ComplexFloatMatrix qq = qrd.Q.GetConjugateTranspose() * qrd.Q;
      ComplexFloatMatrix qr = qrd.Q * qrd.R;
      var I = ComplexFloatMatrix.CreateIdentity(2);

      // determine the maximum relative error
      double MaxError = 0.0;
      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 2; j++)
        {
          double E = ComplexMath.Absolute((qq[i, j] - I[i, j]));
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }
      Assert.True(MaxError < 1.0E-6);

      MaxError = 0.0;
      for (int i = 0; i < 2; i++)
      {
        for (int j = 0; j < 4; j++)
        {
          double E = ComplexMath.Absolute((qr[i, j] - a[i, j]) / a[i, j]);
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }
      Assert.True(MaxError < 2.8E-6);
    }

    [Fact]
    public void LongDecomp()
    {
      var a = new ComplexFloatMatrix(4, 2)
      {
        [0, 0] = new ComplexFloat(1.1f, 1.1f),
        [0, 1] = new ComplexFloat(2.2f, -2.2f),
        [1, 0] = new ComplexFloat(3.3f, 3.3f),
        [1, 1] = new ComplexFloat(4.4f, -4.4f),
        [2, 0] = new ComplexFloat(5.5f, 5.5f),
        [2, 1] = new ComplexFloat(6.6f, -6.6f),
        [3, 0] = new ComplexFloat(7.7f, 7.7f),
        [3, 1] = new ComplexFloat(8.8f, -8.8f)
      };

      var qrd = new ComplexFloatQRDecomp(a);
      ComplexFloatMatrix qq = qrd.Q.GetConjugateTranspose() * qrd.Q;
      ComplexFloatMatrix qr = qrd.Q * qrd.R;
      var I = ComplexFloatMatrix.CreateIdentity(4);

      // determine the maximum relative error
      double MaxError = 0.0;
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; i < 4; i++)
        {
          double E = ComplexMath.Absolute((qq[i, j] - I[i, j]));
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }
      Assert.True(MaxError < 1.0E-6);
      MaxError = 0.0;
      for (int i = 0; i < 4; i++)
      {
        for (int j = 0; j < 2; j++)
        {
          double E = ComplexMath.Absolute((qr[i, j] - a[i, j]) / a[i, j]);
          if (E > MaxError)
          {
            MaxError = E;
          }
        }
      }
      Assert.True(MaxError < 1.0E-5);
    }

    [Fact]
    public void SolveMatrix()
    {
      var a = new ComplexFloatMatrix(3)
      {
        [0, 0] = new ComplexFloat(1.1f, 1.1f),
        [0, 1] = new ComplexFloat(2.2f, -2.2f),
        [0, 2] = new ComplexFloat(3.3f, 3.3f),
        [1, 0] = new ComplexFloat(4.4f, -4.4f),
        [1, 1] = new ComplexFloat(5.5f, 5.5f),
        [1, 2] = new ComplexFloat(6.6f, -6.6f),
        [2, 0] = new ComplexFloat(7.7f, 7.7f),
        [2, 1] = new ComplexFloat(8.8f, -8.8f),
        [2, 2] = new ComplexFloat(9.9f, 9.9f)
      };
      var qr = new ComplexFloatQRDecomp(a);

      var b = new ComplexFloatMatrix(3)
      {
        [0, 0] = new ComplexFloat(2.3f, -3.2f),
        [0, 1] = new ComplexFloat(2.3f, -3.2f),
        [0, 2] = new ComplexFloat(2.3f, -3.2f),
        [1, 0] = new ComplexFloat(6.7f, 7.8f),
        [1, 1] = new ComplexFloat(6.7f, 7.8f),
        [1, 2] = new ComplexFloat(6.7f, 7.8f),
        [2, 0] = new ComplexFloat(1.3f, -9.7f),
        [2, 1] = new ComplexFloat(1.3f, -9.7f),
        [2, 2] = new ComplexFloat(1.3f, -9.7f)
      };

      ComplexFloatMatrix X = qr.Solve(b);

      Assert.True(Comparer.AreEqual(X[0, 0], new ComplexFloat(-0.57f, 1.14f), .01));
      Assert.True(Comparer.AreEqual(X[0, 1], new ComplexFloat(-0.57f, 1.14f), .01));
      Assert.True(Comparer.AreEqual(X[0, 2], new ComplexFloat(-0.57f, 1.14f), .01));
      Assert.True(Comparer.AreEqual(X[1, 0], new ComplexFloat(1.03f, -0.16f), .01));
      Assert.True(Comparer.AreEqual(X[1, 1], new ComplexFloat(1.03f, -0.16f), .01));
      Assert.True(Comparer.AreEqual(X[1, 2], new ComplexFloat(1.03f, -0.16f), .01));
      Assert.True(Comparer.AreEqual(X[2, 0], new ComplexFloat(0.16f, -0.52f), .01));
      Assert.True(Comparer.AreEqual(X[2, 1], new ComplexFloat(0.16f, -0.52f), .01));
      Assert.True(Comparer.AreEqual(X[2, 2], new ComplexFloat(0.16f, -0.52f), .01));

      a = new ComplexFloatMatrix(3, 2)
      {
        [0, 0] = new ComplexFloat(1.1f, 1.1f),
        [0, 1] = new ComplexFloat(2.2f, -2.2f),
        [1, 0] = new ComplexFloat(4.4f, -4.4f),
        [1, 1] = new ComplexFloat(5.5f, 5.5f),
        [2, 0] = new ComplexFloat(7.7f, 7.7f),
        [2, 1] = new ComplexFloat(8.8f, -8.8f)
      };
      qr = new ComplexFloatQRDecomp(a);

      b = new ComplexFloatMatrix(3)
      {
        [0, 0] = new ComplexFloat(2.3f, -3.2f),
        [0, 1] = new ComplexFloat(2.3f, -3.2f),
        [0, 2] = new ComplexFloat(2.3f, -3.2f),
        [1, 0] = new ComplexFloat(6.7f, 7.8f),
        [1, 1] = new ComplexFloat(6.7f, 7.8f),
        [1, 2] = new ComplexFloat(6.7f, 7.8f),
        [2, 0] = new ComplexFloat(1.3f, -9.7f),
        [2, 1] = new ComplexFloat(1.3f, -9.7f),
        [2, 2] = new ComplexFloat(1.3f, -9.7f)
      };

      X = qr.Solve(b);

      Assert.True(Comparer.AreEqual(X[0, 0], new ComplexFloat(-0.344f, 0.410f), .01));
      Assert.True(Comparer.AreEqual(X[0, 1], new ComplexFloat(-0.344f, 0.410f), .01));
      Assert.True(Comparer.AreEqual(X[0, 2], new ComplexFloat(-0.344f, 0.410f), .01));
      Assert.True(Comparer.AreEqual(X[1, 0], new ComplexFloat(1.01f, -0.170f), .01));
      Assert.True(Comparer.AreEqual(X[1, 1], new ComplexFloat(1.01f, -0.170f), .01));
      Assert.True(Comparer.AreEqual(X[1, 2], new ComplexFloat(1.01f, -0.170f), .01));
    }
  }
}
