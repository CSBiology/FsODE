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
using Altaxo.Calc.Fourier;
using Xunit;

namespace AltaxoTest.Calc.Fourier
{
  
  public class TestNativeSplittedComplexConvolution
  {
    private const int nLowerLimit = 5;
    private const int nUpperLimit = 100;
    private const double maxTolerableEpsPerN = 1E-15;

    private SplittedComplexConvolutionTests _test = new SplittedComplexConvolutionTests(new SplittedComplexConvolutionTests.ConvolutionRoutine(NativeFourierMethods.ConvolutionCyclic));

    [Fact]
    public void Test01BothZero()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestBothZero(i);
    }

    [Fact]
    public void Test02OneZero()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestOneZero(i);
    }

    [Fact]
    public void Test03ReOne_ZeroPos()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestReOne_ZeroPos(i);
    }

    [Fact]
    public void Test04OneReOne_OtherRandom()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestOneReOne_OtherRandom(i);
    }

    [Fact]
    public void Test05OneImOne_OtherRandom()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestOneImOne_OtherRandom(i);
    }

    [Fact]
    public void Test06ReOne_OnePos_OtherRandom()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestReOne_OnePos_OtherRandom(i);
    }

    [Fact]
    public void Test07ImOne_OnePos_OtherRandom()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestImOne_OnePos_OtherRandom(i);
    }

    [Fact]
    public void Test08BothRandom()
    {
      for (int i = nLowerLimit; i <= nUpperLimit; i++)
        _test.TestBothRandom(i);
    }
  }
}
