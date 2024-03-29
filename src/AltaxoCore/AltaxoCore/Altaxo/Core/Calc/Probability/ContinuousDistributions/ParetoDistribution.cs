﻿/*
 * Copyright © 2006 Stefan Troschütz (stefan@troschuetz.de)
 *
 * This file is part of Troschuetz.Random Class Library.
 *
 * Troschuetz.Random is free software; you can redistribute it and/or
 * modify it under the terms of the GNU Lesser General Public
 * License as published by the Free Software Foundation; either
 * version 2.1 of the License, or (at your option) any later version.
 * This library is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the GNU
 * Lesser General Public License for more details.
 * You should have received a copy of the GNU Lesser General Public
 * License along with this library; if not, write to the Free Software
 * Foundation, Inc., 51 Franklin Street, Fifth Floor, Boston, MA  02110-1301  USA
 *
 * ParetoDistribution.cs, 21.09.2006
 *
 * 09.08.2006: Initial version
 * 21.09.2006: Adapted to change in base class (field "generator" declared private (formerly protected)
 *             and made accessible through new protected property "Generator")
 *
 */

using System;

namespace Altaxo.Calc.Probability
{
  /// <summary>
  /// Provides generation of pareto distributed random numbers.
  /// </summary>
  /// <remarks>
  /// The implementation of the <see cref="ParetoDistribution"/> type bases upon information presented on
  ///   <a href="http://en.wikipedia.org/wiki/Pareto_distribution">Wikipedia - Pareto distribution</a> and
  ///   <a href="http://www.xycoon.com/par_random.htm">Xycoon - Pareto Distribution</a>.
  /// </remarks>
  public class ParetoDistribution : ContinuousDistribution
  {
    #region instance fields

    /// <summary>
    /// Gets or sets the parameter alpha which is used for generation of pareto distributed random numbers.
    /// </summary>
    /// <remarks>Call <see cref="IsValidAlpha"/> to determine whether a value is valid and therefor assignable.</remarks>
    public double Alpha
    {
      get
      {
        return alpha;
      }
      set
      {
        Initialize(value, beta);
      }
    }

    /// <summary>
    /// Stores the parameter alpha which is used for generation of pareto distributed random numbers.
    /// </summary>
    private double alpha;

    /// <summary>
    /// Gets or sets the parameter beta which is used for generation of pareto distributed random numbers.
    /// </summary>
    /// <remarks>Call <see cref="IsValidBeta"/> to determine whether a value is valid and therefor assignable.</remarks>
    public double Beta
    {
      get
      {
        return beta;
      }
      set
      {
        Initialize(alpha, value);
      }
    }

    /// <summary>
    /// Stores the parameter beta which is used for generation of pareto distributed random numbers.
    /// </summary>
    private double beta;

    /// <summary>
    /// Stores an intermediate result for generation of pareto distributed random numbers.
    /// </summary>
    /// <remarks>
    /// Speeds up random number generation cause this value only depends on distribution parameters
    ///   and therefor doesn't need to be recalculated in successive executions of <see cref="NextDouble"/>.
    /// </remarks>
    private double helper1;

    #endregion instance fields

    #region construction

    /// <summary>
    /// Initializes a new instance of the <see cref="ParetoDistribution"/> class, using a
    ///   <see cref="StandardGenerator"/> as underlying random number generator.
    /// </summary>
    public ParetoDistribution()
      : this(DefaultGenerator)
    {
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="ParetoDistribution"/> class, using the specified
    ///   <see cref="Generator"/> as underlying random number generator.
    /// </summary>
    /// <param name="generator">A <see cref="Generator"/> object.</param>
    /// <exception cref="ArgumentNullException">
    /// <paramref name="generator"/> is NULL (<see langword="Nothing"/> in Visual Basic).
    /// </exception>
    public ParetoDistribution(Generator generator)
      : this(1, 1, generator)
    {
    }

    public ParetoDistribution(double alpha, double beta)
      : this(alpha, beta, DefaultGenerator)
    {
    }

    public ParetoDistribution(double alpha, double beta, Generator generator)
      : base(generator)
    {
      Initialize(alpha, beta);
    }

    #endregion construction

    #region instance methods

    public void Initialize(double alpha, double beta)
    {
      if (!IsValidAlpha(alpha))
        throw new ArgumentOutOfRangeException("Alpha out of range (must be positive)");
      if (!IsValidBeta(beta))
        throw new ArgumentOutOfRangeException("Beta out of range (must be positive)");

      this.alpha = alpha;
      this.beta = beta;

      helper1 = 1.0 / this.beta;
    }

    /// <summary>
    /// Determines whether the specified value is valid for parameter <see cref="Alpha"/>.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    /// <see langword="true"/> if value is greater than 0.0; otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsValidAlpha(double value)
    {
      return value > 0.0;
    }

    /// <summary>
    /// Determines whether the specified value is valid for parameter <see cref="Beta"/>.
    /// </summary>
    /// <param name="value">The value to check.</param>
    /// <returns>
    /// <see langword="true"/> if value is greater than 0.0; otherwise, <see langword="false"/>.
    /// </returns>
    public bool IsValidBeta(double value)
    {
      return value > 0.0;
    }

    #endregion instance methods

    #region overridden Distribution members

    /// <summary>
    /// Gets the minimum possible value of pareto distributed random numbers.
    /// </summary>
    public override double Minimum
    {
      get
      {
        return alpha;
      }
    }

    /// <summary>
    /// Gets the maximum possible value of pareto distributed random numbers.
    /// </summary>
    public override double Maximum
    {
      get
      {
        return double.MaxValue;
      }
    }

    /// <summary>
    /// Gets the mean value of pareto distributed random numbers.
    /// </summary>
    public override double Mean
    {
      get
      {
        if (beta > 1.0)
        {
          return alpha * beta / (beta - 1.0);
        }
        else
        {
          return double.NaN;
        }
      }
    }

    /// <summary>
    /// Gets the median of pareto distributed random numbers.
    /// </summary>
    public override double Median
    {
      get
      {
        return alpha * Math.Pow(2.0, 1.0 / beta);
      }
    }

    /// <summary>
    /// Gets the variance of pareto distributed random numbers.
    /// </summary>
    public override double Variance
    {
      get
      {
        if (beta > 2.0)
        {
          return beta * Math.Pow(alpha, 2.0) / Math.Pow(beta - 1.0, 2.0) / (beta - 2.0);
        }
        else
        {
          return double.NaN;
        }
      }
    }

    /// <summary>
    /// Gets the mode of pareto distributed random numbers.
    /// </summary>
    public override double[] Mode
    {
      get
      {
        return new double[] { alpha };
      }
    }

    /// <summary>
    /// Returns a pareto distributed floating point random number.
    /// </summary>
    /// <returns>A pareto distributed double-precision floating point number.</returns>
    public override double NextDouble()
    {
      return alpha / Math.Pow(1.0 - Generator.NextDouble(), helper1);
    }

    #endregion overridden Distribution members

    #region CdfPdfQuantile

    public override double CDF(double x)
    {
      return CDF(x, alpha, beta);
    }

    public static double CDF(double x, double alpha, double beta)
    {
      return 1 - Math.Pow(alpha / x, beta);
    }

    public override double PDF(double x)
    {
      return PDF(x, alpha, beta);
    }

    public static double PDF(double x, double alpha, double beta)
    {
      return Math.Pow(alpha, beta) * beta * Math.Pow(x, -1 - beta);
    }

    public override double Quantile(double p)
    {
      return Quantile(p, alpha, beta);
    }

    public static double Quantile(double p, double alpha, double beta)
    {
      return alpha * Math.Pow(1 - p, -1 / beta);
    }

    #endregion CdfPdfQuantile
  }
}
