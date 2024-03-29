﻿#region Copyright

/////////////////////////////////////////////////////////////////////////////
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2018 Dr. Dirk Lellinger
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
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Altaxo.Science.Thermodynamics.Fluids
{

  /// <summary>
  /// Tests and test data for <see cref="Mixture_Decane_Water"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_Decane_Water : MixtureTestBase
  {

    public Test_Mixture_Decane_Water()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("124-18-5", 0.5), ("7732-18-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.40110588046093, 999.999999766739, -0.000482752107407652, 25.6056207506047, 2 ),
      ( 300, 55197.6758919268, 999999.999889803, -0.992736791192914, 74.5048480423885, 1 ),
      ( 300, 55418.7023076162, 9999999.99979419, -0.927657590479332, 73.9880202280251, 1 ),
      ( 300, 57422.6800805817, 100000000.000067, -0.301822476433288, 69.9852980707916, 1 ),
      ( 350, 0.343708017231431, 999.999999940274, -0.000200604701436224, 25.8283438492112, 2 ),
      ( 350, 3.44334324178879, 9999.99934557472, -0.00201913168798396, 26.1202254667067, 2 ),
      ( 350, 56106.7959369026, 100000000.000555, -0.387526836899675, 67.3430542318835, 1 ),
      ( 400, 0.300715731465636, 999.999999993975, -0.000104906888774655, 26.2227416294566, 2 ),
      ( 400, 3.01000786335247, 9999.9999373923, -0.00105183120350113, 26.3249063941313, 2 ),
      ( 400, 30.3967274191036, 99999.9999986929, -0.0108008001788616, 27.4308206240107, 2 ),
      ( 400, 51906.9654167209, 1000000.00018203, -0.994207247872079, 65.6461869278127, 1 ),
      ( 400, 52159.0653198552, 9999999.99998402, -0.942352459257213, 65.457513732507, 1 ),
      ( 400, 54343.5529906601, 100000000.00345, -0.446697597458375, 63.8135535281544, 1 ),
      ( 500, 0.240557166235196, 999.999999998928, -4.08168431464422E-05, 27.2356316547675, 2 ),
      ( 500, 2.4064563292429, 9999.99998911173, -0.000408424087783917, 27.2583630095569, 2 ),
      ( 500, 24.154007204498, 99999.9999999998, -0.00410997886204942, 27.4911659921764, 2 ),
      ( 500, 251.585092374765, 999999.99999998, -0.0438728098692304, 30.4006456544859, 2 ),
      ( 500, 46366.1225711428, 9999999.99999704, -0.948120020801422, 58.3141272914194, 1 ),
      ( 500, 49763.6715992989, 99999999.9999979, -0.516620579389763, 57.6130656614781, 1 ),
      ( 600, 0.200460145759225, 999.999999999995, -2.00682450621103E-05, 28.3808363166765, 2 ),
      ( 600, 2.0049636781121, 9999.99999929282, -0.000200726505677346, 28.389095518462, 2 ),
      ( 600, 20.0860189679278, 99999.9911025655, -0.00201168169590306, 28.472335255712, 2 ),
      ( 600, 204.66618207939, 999999.999790426, -0.020570370541029, 29.370537427054, 2 ),
      ( 600, 2763.05036906212, 10000000.0000011, -0.274511514084615, 47.6012147275098, 2 ),
      ( 600, 43797.1092669285, 100000000.000003, -0.542307411993356, 53.1150342371451, 1 ),
      };

      // TestData for 500 Permille to 500 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_500_500 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 350, 0.343784693379861, 999.999999996325, -0.000429632952382401, 141.761820363071, 2 ),
      ( 400, 0.300756966867043, 999.999992177844, -0.000248036607642195, 157.822561288312, 2 ),
      ( 400, 3.01432485378363, 9999.99998946178, -0.00248850832056285, 157.960178327427, 2 ),
      ( 400, 12795.4323923359, 100000000.003888, 1.34991955660347, 184.954319593976, 1 ),
      ( 500, 0.240570860118731, 999.999999623235, -0.000103776557858593, 187.518945318485, 2 ),
      ( 500, 2.4079602817332, 9999.99606727015, -0.00103877781435099, 187.561310176313, 2 ),
      ( 500, 24.309612007626, 99999.9940523067, -0.0104906049502501, 187.996611645459, 2 ),
      ( 500, 11737.4767941984, 100000000.002137, 1.04938334469295, 208.872191041577, 1 ),
      ( 600, 0.200465221144106, 999.999999967157, -5.14256700727687E-05, 212.715361763127, 2 ),
      ( 600, 2.00558084723614, 9999.99966603658, -0.00051442770069428, 212.733258809531, 2 ),
      ( 600, 20.1494919794866, 99999.9999996187, -0.00516145868337659, 212.91389043173, 2 ),
      ( 600, 211.766851264825, 1000000, -0.0534169494020432, 214.889701166322, 2 ),
      ( 600, 5611.20241135039, 10000000.0017603, -0.642759434807224, 235.064517939482, 1 ),
      ( 600, 10726.014782097, 100000000.000002, 0.868866640189641, 229.860658231386, 1 ),
      };

      // TestData for 999 Permille to 1 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_999_001 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 5108.86002517517, 1000000.00351421, -0.921527033026468, 253.202710705391, 1 ),
      ( 300, 5157.98867347728, 10000000.0000008, -0.222744701653116, 253.839596330692, 1 ),
      ( 300, 5500.69873693295, 100000000.009347, 6.28829957481821, 259.58534995381, 1 ),
      ( 350, 0.344176619619265, 999.99999214469, -0.00157391017262635, 257.756178301919, 2 ),
      ( 350, 4835.43955190815, 1000000.00000427, -0.928934089063761, 281.757843220651, 1 ),
      ( 350, 4901.01015863276, 10000000.0000002, -0.298848797729024, 282.326918389966, 1 ),
      ( 350, 5316.39604937115, 99999999.9999994, 5.46368166217751, 287.619525094108, 1 ),
      ( 400, 0.300956306440791, 999.99999846225, -0.000916260829151815, 289.456045139427, 2 ),
      ( 400, 3.03484430472603, 9999.98366851356, -0.00923893799627604, 289.920157263167, 2 ),
      ( 400, 4542.41899563883, 100000.000001033, -0.993380607287483, 310.623172797182, 1 ),
      ( 400, 4552.45211399832, 1000000.00000059, -0.933951957222985, 310.666023313788, 1 ),
      ( 400, 4642.2896726234, 10000000.0000274, -0.352301185056469, 311.133428688173, 1 ),
      ( 400, 5144.18499858513, 100000000.000001, 4.84505712854697, 316.025788178593, 1 ),
      ( 500, 0.240636205091677, 999.999894834536, -0.000381337087788657, 347.815512585981, 2 ),
      ( 500, 2.41468192256027, 9999.99999961305, -0.00382555844009379, 347.979833004519, 2 ),
      ( 500, 25.0454488733429, 100000.011987891, -0.0395682602700388, 349.693765950632, 2 ),
      ( 500, 3899.0162559262, 1000000.00000022, -0.938306376331006, 365.485785037363, 1 ),
      ( 500, 4096.70829218075, 10000000.0012726, -0.412834831176412, 365.289554716378, 1 ),
      ( 500, 4828.2101573335, 100000000.000991, 3.9820623737587, 369.24504567808, 1 ),
      ( 600, 0.200491594358927, 999.999999485623, -0.000189000684709575, 397.056916926774, 2 ),
      ( 600, 2.00833758867033, 9999.99999999941, -0.0018923987610855, 397.127790873907, 2 ),
      ( 600, 20.4371590584856, 100000.000213465, -0.0191704202714039, 397.850827251088, 2 ),
      ( 600, 259.631791142759, 999999.998698319, -0.227930830325946, 407.273585001418, 2 ),
      ( 600, 3474.72100083915, 10000000.0042861, -0.423108498960823, 412.379073629631, 1 ),
      ( 600, 4543.99420150392, 100000000.000002, 3.41139870389682, 414.768175512253, 1 ),
      };
    }

    [Fact]
    public override void CASNumberAttribute_Test()
    {
      base.CASNumberAttribute_Test();
    }

    [Fact]
    public override void Constants_Test()
    {
      base.Constants_Test();
    }

    [Fact]
    public override void DeltaPhiRDelta_001_999_Test()
    {
      base.DeltaPhiRDelta_001_999_Test();
    }

    [Fact]
    public override void DeltaPhiRDelta_500_500_Test()
    {
      base.DeltaPhiRDelta_500_500_Test();
    }

    [Fact]
    public override void DeltaPhiRDelta_999_001_Test()
    {
      base.DeltaPhiRDelta_999_001_Test();
    }
  }
}
