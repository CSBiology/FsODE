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

/*
 * BSD Licence:
 * Copyright (c) 2001, 2002 Ben Houston [ ben@exocortex.org ]
 * Exocortex Technologies [ www.exocortex.org ]
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice,
 * this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright
 * notice, this list of conditions and the following disclaimer in the
 * documentation and/or other materials provided with the distribution.
 * 3. Neither the name of the <ORGANIZATION> nor the names of its contributors
 * may be used to endorse or promote products derived from this software
 * without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
 * DAMAGE.
 */

using System;
using System.Runtime.InteropServices;

namespace Altaxo.Calc
{
  // Comments? Questions? Bugs? Tell Ben Houston at ben@exocortex.org
  // Version: May 4, 2002

  /// <summary>
  /// <p>A double-precision complex number representation.</p>
  /// </summary>
  [StructLayout(LayoutKind.Sequential)]
  public struct Complex : IComparable, ICloneable
  {
    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// The real component of the complex number
    /// </summary>
    public double Re;

    /// <summary>
    /// The imaginary component of the complex number
    /// </summary>
    public double Im;

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// The real component of the complex number
    /// </summary>
    public double Real
    {
      get
      {
        return Re;
      }
      set
      {
        Re = value;
      }
    }

    /// <summary>
    /// The imaginary component of the complex number
    /// </summary>
    public double Imag
    {
      get
      {
        return Im;
      }
      set
      {
        Im = value;
      }
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Create a complex number from a real and an imaginary component
    /// </summary>
    /// <param name="real"></param>
    /// <param name="imaginary"></param>
    public Complex(double real, double imaginary)
    {
      Re = real;
      Im = imaginary;
    }

    /// <summary>
    /// Create a complex number based on an existing complex number
    /// </summary>
    /// <param name="c"></param>
    public Complex(Complex c)
    {
      Re = c.Re;
      Im = c.Im;
    }

    ///<summary>Created a <c>Complex</c> from the given string. The string can be in the
    ///following formats: <c>n</c>, <c>ni</c>, <c>n +/- ni</c>, <c>n,n</c>, <c>n,ni</c>,
    ///<c>(n,n)</c>, or <c>(n,ni)</c>, where n is a real number.</summary>
    ///<param name="s">The string to create the <c>Complex</c> from.</param>
    ///<exception cref="FormatException">if the n, is not a number.</exception>
    ///<exception cref="ArgumentNullException">if s, is <c>null</c>.</exception>
    public Complex(string s)
    {
      this = Complex.Parse(s);
    }

    /// <summary>
    /// Create a complex number from a real and an imaginary component
    /// </summary>
    /// <param name="real"></param>
    /// <param name="imaginary"></param>
    /// <returns></returns>
    public static Complex FromRealImaginary(double real, double imaginary)
    {
      Complex c;
      c.Re = real;
      c.Im = imaginary;
      return c;
    }

    /// <summary>
    /// Create a complex number from a modulus (length) and an argument (radian)
    /// </summary>
    /// <param name="modulus"></param>
    /// <param name="argument"></param>
    /// <returns></returns>
    public static Complex FromModulusArgument(double modulus, double argument)
    {
      Complex c;
      c.Re = modulus * System.Math.Cos(argument);
      c.Im = modulus * System.Math.Sin(argument);
      return c;
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    object ICloneable.Clone()
    {
      return new Complex(this);
    }

    /// <summary>
    /// Clone the complex number
    /// </summary>
    /// <returns></returns>
    public Complex Clone()
    {
      return new Complex(this);
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// The modulus (length) of the complex number
    /// </summary>
    /// <returns></returns>
    public double GetModulus()
    {
      return RMath.Hypot(Re, Im);
    }

    /// <summary>
    /// The squared modulus (length^2) of the complex number
    /// </summary>
    /// <returns></returns>
    public double GetModulusSquared()
    {
      double x = Re;
      double y = Im;
      return x * x + y * y;
    }

    /// <summary>
    /// The argument (radians) of the complex number
    /// </summary>
    /// <returns></returns>
    public double GetArgument()
    {
      if (Re == 0 && Im == 0)
        return 0;
      else
        return Math.Atan2(Im, Re);
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Get the conjugate of the complex number
    /// </summary>
    /// <returns></returns>
    public Complex GetConjugate()
    {
      return FromRealImaginary(Re, -Im);
    }

    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Scale the complex number to 1.
    /// </summary>
    public void Normalize()
    {
      double modulus = GetModulus();
      if (modulus == 0)
      {
        throw new DivideByZeroException("Can not normalize a complex number that is zero.");
      }
      Re = Re / modulus;
      Im = Im / modulus;
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Convert to a from double precision complex number to a single precison complex number
    /// </summary>
    /// <param name="cF"></param>
    /// <returns></returns>
    public static implicit operator Complex(ComplexFloat cF)
    {
      Complex c;
      c.Re = cF.Re;
      c.Im = cF.Im;
      return c;
    }

    /// <summary>
    /// Convert from a single precision real number to a complex number
    /// </summary>
    /// <param name="d"></param>
    /// <returns></returns>
    public static implicit operator Complex(double d)
    {
      Complex c;
      c.Re = d;
      c.Im = 0;
      return c;
    }

    /// <summary>
    /// Convert from a single precision complex to a real number
    /// </summary>
    /// <param name="c"></param>
    /// <returns></returns>
    public static explicit operator double(Complex c)
    {
      return c.Re;
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Are these two complex numbers equivalent?
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator ==(Complex a, Complex b)
    {
      return (a.Re == b.Re) && (a.Im == b.Im);
    }

    /// <summary>
    /// Are these two complex numbers different?
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static bool operator !=(Complex a, Complex b)
    {
      return (a.Re != b.Re) || (a.Im != b.Im);
    }

    /// <summary>
    /// Get the hash code of the complex number
    /// </summary>
    /// <returns></returns>
    public override int GetHashCode()
    {
      return (Re.GetHashCode() + Im.GetHashCode());
    }

    ///<summary>Check if <c>ComplexDouble</c> variable is the same as another object</summary>
    ///<param name="obj"><c>obj</c> to compare present <c>ComplexDouble</c> to.</param>
    ///<returns>Returns true if the variable is the same as the <c>ComplexDouble</c> variable</returns>
    ///<remarks>The <c>obj</c> parameter is converted into a <c>ComplexDouble</c> variable before comparing with the current <c>ComplexDouble</c>.</remarks>
    public bool Equals(Complex obj)
    {
      return Re == obj.Re && Im == obj.Im;
    }

    ///<summary>Check if <c>ComplexDouble</c> variable is the same as another object</summary>
    ///<param name="obj"><c>obj</c> to compare present <c>ComplexDouble</c> to.</param>
    ///<returns>Returns true if the variable is the same as the <c>ComplexDouble</c> variable</returns>
    ///<remarks>The <c>obj</c> parameter is converted into a <c>ComplexDouble</c> variable before comparing with the current <c>ComplexDouble</c>.</remarks>
    public bool Equals(ComplexFloat obj)
    {
      return Re == obj.Re && Im == obj.Im;
    }

    ///<summary>Check if <c>ComplexDouble</c> variable is the same as another object</summary>
    ///<param name="obj"><c>obj</c> to compare present <c>ComplexDouble</c> to.</param>
    ///<returns>Returns true if the variable is the same as the <c>ComplexDouble</c> variable</returns>
    ///<remarks>The <c>obj</c> parameter is converted into a <c>ComplexDouble</c> variable before comparing with the current <c>ComplexDouble</c>.</remarks>
    public override bool Equals(object? obj)
    {
      if (obj is null)
      {
        return false;
      }
      if (obj is Complex crhs)
      {
        return Equals(crhs);
      }
      else if (obj is ComplexFloat cfrhs)
      {
        return Equals(cfrhs);
      }
      else
      {
        return false;
      }
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Compare to other complex numbers or real numbers
    /// </summary>
    /// <param name="o"></param>
    /// <returns></returns>
    public int CompareTo(object? o)
    {
      if (o is null)
      {
        return 1;  // null sorts before current
      }
      if (o is Complex c)
      {
        return GetModulus().CompareTo(c.GetModulus());
      }
      if (o is double d)
      {
        return GetModulus().CompareTo(d);
      }
      if (o is ComplexFloat cf)
      {
        return GetModulus().CompareTo(cf.GetModulus());
      }
      if (o is float f)
      {
        return GetModulus().CompareTo(f);
      }
      throw new ArgumentException();
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// This operator doesn't do much. :-)
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator +(Complex a)
    {
      return a;
    }

    /// <summary>
    /// Negate the complex number
    /// </summary>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator -(Complex a)
    {
      a.Re = -a.Re;
      a.Im = -a.Im;
      return a;
    }

    /// <summary>
    /// Add a complex number to a real
    /// </summary>
    /// <param name="a"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Complex operator +(Complex a, double f)
    {
      a.Re = a.Re + f;
      return a;
    }

    /// <summary>
    /// Add a real to a complex number
    /// </summary>
    /// <param name="f"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator +(double f, Complex a)
    {
      a.Re += f;
      return a;
    }

    /// <summary>
    /// Add to complex numbers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex operator +(Complex a, Complex b)
    {
      a.Re = a.Re + b.Re;
      a.Im = a.Im + b.Im;
      return a;
    }

    /// <summary>
    /// Subtract a real from a complex number
    /// </summary>
    /// <param name="a"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Complex operator -(Complex a, double f)
    {
      a.Re = a.Re - f;
      return a;
    }

    /// <summary>
    /// Subtract a complex number from a real
    /// </summary>
    /// <param name="f"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator -(double f, Complex a)
    {
      a.Re = (f - a.Re);
      a.Im = (0 - a.Im);
      return a;
    }

    /// <summary>
    /// Subtract two complex numbers
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex operator -(Complex a, Complex b)
    {
      a.Re = a.Re - b.Re;
      a.Im = a.Im - b.Im;
      return a;
    }

    /// <summary>
    /// Multiply a complex number by a real
    /// </summary>
    /// <param name="a"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Complex operator *(Complex a, double f)
    {
      a.Re = (a.Re * f);
      a.Im = (a.Im * f);
      return a;
    }

    /// <summary>
    /// Multiply a real by a complex number
    /// </summary>
    /// <param name="f"></param>
    /// <param name="a"></param>
    /// <returns></returns>
    public static Complex operator *(double f, Complex a)
    {
      a.Re = a.Re * f;
      a.Im = a.Im * f;

      return a;
    }

    /// <summary>
    /// Multiply two complex numbers together
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex operator *(Complex a, Complex b)
    {
      // (x + yi)(u + vi) = (xu – yv) + (xv + yu)i.
      double x = a.Re, y = a.Im;
      double u = b.Re, v = b.Im;

      a.Re = x * u - y * v;
      a.Im = x * v + y * u;

      return a;
    }

    /// <summary>
    /// Divide a complex number by a real number
    /// </summary>
    /// <param name="a"></param>
    /// <param name="f"></param>
    /// <returns></returns>
    public static Complex operator /(Complex a, double f)
    {
      if (f == 0)
      {
        throw new DivideByZeroException();
      }

      a.Re = a.Re / f;
      a.Im = a.Im / f;

      return a;
    }

    /// <summary>
    /// Divide a complex number by a complex number
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <returns></returns>
    public static Complex operator /(Complex a, Complex b)
    {
      double x = a.Re, y = a.Im;
      double u = b.Re, v = b.Im;
      double denom = u * u + v * v;

      if (denom == 0)
      {
        return new Complex(x / denom, y / denom);
      }
      else
      {
        a.Re = (x * u + y * v) / denom;
        a.Im = (y * u - x * v) / denom;
      }
      return a;
    }

    /// <summary>Creates a <c>Complex</c> based on a string. The string can be in the
    ///following formats: <c>n</c>, <c>ni</c>, <c>n +/- ni</c>, <c>n,n</c>, <c>n,ni</c>,
    ///<c>(n,n)</c>, or <c>(n,ni)</c>, where n is a real number.</summary>
    /// <param name="s">the string to parse.</param>
    /// <returns></returns>
    public static Complex Parse(string s)
    {
      if (s is null)
      {
        throw new ArgumentNullException(s, "s cannot be null.");
      }
      s = s.Trim();
      if (s.Length == 0)
      {
        throw new FormatException();
      }

      //check if one character strings are valid
      if (s.Length == 1)
      {
        if (string.Compare(s, "i") == 0)
        {
          return new Complex(0, 1);
        }
        else
        {
          return new Complex(double.Parse(s));
        }
      }

      //strip out parens
      if (s.StartsWith("("))
      {
        if (!s.EndsWith(")"))
        {
          throw new FormatException();
        }
        else
        {
          s = s.Substring(1, s.Length - 2);
        }
      }

      string real = s;
      string imag = "0";

      //comma separated
      int index = s.IndexOf(',');
      if (index > -1)
      {
        real = s.Substring(0, index);
        imag = s.Substring(index + 1, s.Length - index - 1);
      }
      else
      {
        index = s.IndexOf('+', 1);
        if (index > -1)
        {
          real = s.Substring(0, index);
          imag = s.Substring(index + 1, s.Length - index - 1);
        }
        else
        {
          index = s.IndexOf('-', 1);
          if (index > -1)
          {
            real = s.Substring(0, index);
            imag = s.Substring(index, s.Length - index);
          }
        }
      }

      //see if we have numbers in the format xxxi
      if (real.EndsWith("i"))
      {
        if (!imag.Equals("0"))
        {
          throw new FormatException();
        }
        else
        {
          imag = real.Substring(0, real.Length - 1);
          real = "0";
        }
      }
      if (imag.EndsWith("i"))
      {
        imag = imag.Substring(0, imag.Length - 1);
      }
      //handle cases of - n, + n
      if (real.StartsWith("-"))
      {
        real = "-" + real.Substring(1, real.Length - 1).Trim();
      }
      if (imag.StartsWith("-"))
      {
        imag = "-" + imag.Substring(1, imag.Length - 1).Trim();
      }

      Complex ret;
      try
      {
        ret = new Complex(double.Parse(real.Trim()), double.Parse(imag.Trim()));
      }
      catch (Exception)
      {
        throw new FormatException();
      }
      return ret;
    }

    ///<summary>Tests whether the the complex number is not a number.</summary>
    ///<returns>True if either the real or imaginary components are NaN, false otherwise.</returns>
    public bool IsNaN()
    {
      return (double.IsNaN(Re) || double.IsNaN(Im));
    }

    ///<summary>Tests whether the the complex number is infinite.</summary>
    ///<returns>True if either the real or imaginary components are infinite, false otherwise.</returns>
    public bool IsInfinity()
    {
      return (double.IsInfinity(Re) || double.IsInfinity(Im));
    }

    ///<summary>A string representation of this <c>Complex</c>.</summary>
    ///<returns>The string representation of the value of <c>this</c> instance.</returns>
    public override string ToString()
    {
      return ToString(null, null);
    }

    ///<summary>A string representation of this <c>Complex</c>.</summary>
    ///<param name="format">A format specification.</param>
    ///<returns>The string representation of the value of <c>this</c> instance as specified by format.</returns>
    public string ToString(string format)
    {
      return ToString(format, null);
    }

    ///<summary>A string representation of this <c>Complex</c>.</summary>
    ///<param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
    ///<returns>The string representation of the value of <c>this</c> instance as specified by provider.</returns>
    public string ToString(IFormatProvider formatProvider)
    {
      return ToString(null, formatProvider);
    }

    ///<summary>A string representation of this <c>Complex</c>.</summary>
    ///<param name="format">A format specification.</param>
    ///<param name="formatProvider">An IFormatProvider that supplies culture-specific formatting information.</param>
    ///<returns>The string representation of the value of <c>this</c> instance as specified by format and provider.</returns>
    ///<exception cref="FormatException">if the n, is not a number.</exception>
    ///<exception cref="ArgumentNullException">if s, is <c>null</c>.</exception>
    public string ToString(string? format, IFormatProvider? formatProvider)
    {
      if (IsNaN())
      {
        return "NaN";
      }
      if (IsInfinity())
      {
        return "IsInfinity";
      }

      var ret = new System.Text.StringBuilder();

      ret.Append(Re.ToString(format, formatProvider));
      if (Im < 0)
      {
        ret.Append(" ");
      }
      else
      {
        ret.Append(" + ");
      }
      ret.Append(Im.ToString(format, formatProvider)).Append("i");

      return ret.ToString();
    }

    //-----------------------------------------------------------------------------------
    //-----------------------------------------------------------------------------------

    /// <summary>
    /// Determine whether two complex numbers are almost (i.e. within the tolerance) equivalent.
    /// </summary>
    /// <param name="a"></param>
    /// <param name="b"></param>
    /// <param name="tolerance"></param>
    /// <returns></returns>
    public static bool IsEqual(Complex a, Complex b, double tolerance)
    {
      return
        (Math.Abs(a.Re - b.Re) < tolerance) &&
        (Math.Abs(a.Im - b.Im) < tolerance);
    }

    //----------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------

    /// <summary>
    /// Represents zero
    /// </summary>
    public static Complex Zero
    {
      get { return new Complex(0, 0); }
    }

    /// <summary>
    /// Represents One
    /// </summary>
    public static Complex One
    {
      get { return new Complex(1, 0); }
    }

    /// <summary>
    /// Represents the result of sqrt( -1 )
    /// </summary>
    public static Complex I
    {
      get { return new Complex(0, 1); }
    }

    /// <summary>
    /// Represents the largest possible value of Complex.
    /// </summary>
    public static Complex MaxValue
    {
      get { return new Complex(double.MaxValue, double.MaxValue); }
    }

    /// <summary>
    /// Represents the smallest possible value of Complex.
    /// </summary>
    public static Complex MinValue
    {
      get { return new Complex(double.MinValue, double.MinValue); }
    }

    //----------------------------------------------------------------------------------
    //----------------------------------------------------------------------------------

    #region AltaxoModified

    public static Complex operator /(double a, Complex z)
    {
      return Complex.FromRealImaginary(a, 0) / z;
    }

    public static Complex NaN
    {
      get { return new Complex(double.NaN, double.NaN); }
    }

    #endregion AltaxoModified
  }
}
