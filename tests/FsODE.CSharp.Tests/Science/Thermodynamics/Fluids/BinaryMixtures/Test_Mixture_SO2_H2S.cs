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
  /// Tests and test data for <see cref="Mixture_SO2_H2S"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_SO2_H2S : MixtureTestBase
  {

    public Test_Mixture_SO2_H2S()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7446-09-5", 0.5), ("7783-06-4", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 0.601526852472832, 999.999999784742, -0.000275557282866412, 25.0766470578928, 2 ),
      ( 200, 6.0302690389531, 9999.99773073609, -0.00276240767229383, 25.1682478171181, 2 ),
      ( 200, 28501.9702373402, 100000.000000116, -0.997890106924084, 43.0571735356491, 1 ),
      ( 200, 28524.0812058682, 1000000.00166778, -0.978917424405308, 43.0726224485269, 1 ),
      ( 200, 28737.2101760477, 10000000.0000029, -0.790737829566714, 43.2262777796821, 1 ),
      ( 250, 0.481152125680033, 999.99999999493, -0.000131450704367671, 25.3418196199794, 2 ),
      ( 250, 4.81722824204567, 9999.99994805396, -0.00131599806982675, 25.3750310027381, 2 ),
      ( 250, 48.7580647810029, 99999.999999971, -0.0133142485145398, 25.7124746051399, 2 ),
      ( 250, 25856.9131869474, 1000000.00359963, -0.981394187460853, 39.0549721319446, 1 ),
      ( 250, 26211.6722370649, 10000000.0000023, -0.816460058884333, 39.1997583129277, 1 ),
      ( 300, 0.400936879821258, 999.999999998403, -7.35317142699486E-05, 25.82267736777, 2 ),
      ( 300, 4.01202586504967, 9999.9999837848, -0.000735758614763017, 25.8373744871868, 2 ),
      ( 300, 40.3897189728112, 99999.9999999987, -0.00740235764283639, 25.9854759418431, 2 ),
      ( 300, 435.41872797041, 999999.999999984, -0.0792600949575699, 27.6359955230244, 2 ),
      ( 300, 23236.3562742471, 10000000.0016747, -0.827465462493987, 36.796064414298, 1 ),
      ( 350, 0.343650454948465, 999.999999999984, -4.52266734035528E-05, 26.4719886040578, 2 ),
      ( 350, 3.43790450119534, 9999.99999786772, -0.000452419018229684, 26.4794817575809, 2 ),
      ( 350, 34.5201967973548, 99999.9999999998, -0.00453953143613639, 26.5547600774986, 2 ),
      ( 350, 360.602627889812, 999999.990453077, -0.0470537750618162, 27.3469354128228, 2 ),
      ( 350, 18976.575603486, 9999999.99999961, -0.818916268159091, 35.8696824357658, 1 ),
      ( 400, 0.300689425570349, 999.999999999946, -2.95217780097253E-05, 27.2291974791929, 2 ),
      ( 400, 3.00769357758433, 9999.99999946007, -0.000295273013219037, 27.2334519235807, 2 ),
      ( 400, 30.1572684015255, 99999.9943732285, -0.00295827615294553, 27.276125741766, 2 ),
      ( 400, 310.031499661718, 999999.999878156, -0.0301612932456172, 27.716368375458, 2 ),
      ( 400, 5051.16492515034, 9999999.99999999, -0.404730288677066, 34.6748678992032, 2 ),
      ( 500, 0.240547780372128, 999.997848261086, -1.38908695437023E-05, 28.9130193286192, 2 ),
      ( 500, 2.40577858296812, 9999.99999999968, -0.000138912824090261, 28.9147632932928, 2 ),
      ( 500, 24.087914327104, 99999.999996811, -0.00138951143404662, 28.9322292123649, 2 ),
      ( 500, 243.943442648144, 1000000, -0.0139335727336792, 29.1094911283749, 2 ),
      ( 500, 2804.03210216379, 10000000, -0.142148056145701, 31.0914044516918, 2 ),
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
      ( 200, 0.601645579286095, 999.999999998502, -0.000472245828966081, 26.5858331056003, 2 ),
      ( 200, 26702.6741666728, 99999.9999981265, -0.997747935479946, 49.8196600190149, 1 ),
      ( 200, 26719.7944260406, 1000000.00021579, -0.977493784388183, 49.8282887776315, 1 ),
      ( 200, 26885.6148252875, 10000000.0000012, -0.776325942863405, 49.9195922541331, 1 ),
      ( 250, 0.481188104734062, 999.999999999933, -0.000205618128315609, 27.596192540338, 2 ),
      ( 250, 4.82082287258714, 9999.99999934454, -0.00206007054697833, 27.6780762518328, 2 ),
      ( 250, 49.141346571678, 100000.000073565, -0.0210093998398884, 28.5192990214274, 2 ),
      ( 250, 24495.8023133273, 1000000.00181797, -0.980360342622929, 46.6160225513075, 1 ),
      ( 250, 24752.7964589225, 10000000.0000017, -0.8056425000195, 46.5848576627516, 1 ),
      ( 300, 0.400950810775903, 999.999999999967, -0.000107679863907697, 28.7323301715957, 2 ),
      ( 300, 4.01340192354814, 9999.99999966952, -0.00107777869192736, 28.7689902164699, 2 ),
      ( 300, 40.5316641014489, 99999.9964115418, -0.0108779256830266, 29.1407115605472, 2 ),
      ( 300, 22396.5094406106, 10000000.0002716, -0.820995482568702, 44.6630809726413, 1 ),
      ( 350, 0.343657065732499, 999.984063256593, -6.3867239071005E-05, 29.9507944323673, 2 ),
      ( 350, 3.43854836847056, 9999.99999991804, -0.000638990262106368, 29.9675391853725, 2 ),
      ( 350, 34.5855863122472, 99999.9991246887, -0.0064210162854368, 30.1363714282392, 2 ),
      ( 350, 368.597758891959, 999999.999987742, -0.0677232602063581, 31.9871091990696, 2 ),
      ( 350, 19465.4711271101, 10000000.0000094, -0.823464269263727, 43.6447331360154, 1 ),
      ( 400, 0.300693030505223, 999.997642659869, -4.09159494818712E-05, 31.1917756218499, 2 ),
      ( 400, 3.00803837283907, 9999.99999998366, -0.000409269873818435, 31.2000453970979, 2 ),
      ( 400, 30.1919717326479, 99999.9997934702, -0.00410370675787023, 31.2831546421435, 2 ),
      ( 400, 313.931751237682, 999999.999999738, -0.0422098874996301, 32.1587926293238, 2 ),
      ( 400, 14231.4173619843, 9999999.99947259, -0.788720462847174, 45.6932443250797, 1 ),
      ( 500, 0.240549131329155, 999.996435983869, -1.89127460840692E-05, 33.5717963850905, 2 ),
      ( 500, 2.40590087399523, 9999.99999999879, -0.000189141338761726, 33.5746465179673, 2 ),
      ( 500, 24.1000732317564, 99999.9999873133, -0.00189273470040151, 33.6031930221153, 2 ),
      ( 500, 245.218512202659, 999999.999999999, -0.0190602670751764, 33.8932228764407, 2 ),
      ( 500, 3015.62407048561, 10000000, -0.202338964519458, 37.2458743836884, 2 ),
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
      ( 200, 0.60183598969914, 999.999999998954, -0.000787885292723859, 28.0970949664287, 2 ),
      ( 200, 25324.5193564374, 100000.000002934, -0.997625377194681, 56.0104539496736, 1 ),
      ( 200, 25337.8268222569, 1000000.00003198, -0.976266243501814, 56.0226899905872, 1 ),
      ( 200, 25467.7288423165, 10000000.000001, -0.763873011332294, 56.1478021378951, 1 ),
      ( 250, 0.481245873190127, 999.999999999472, -0.000325038861642875, 29.853156211124, 2 ),
      ( 250, 4.82663204636502, 9999.99999457833, -0.00326056562384552, 30.0072888088266, 2 ),
      ( 250, 23348.8008780197, 99999.9999988894, -0.997939553932165, 53.1162720870458, 1 ),
      ( 250, 23368.3733553276, 1000000.00087732, -0.979412796832461, 53.1159432527833, 1 ),
      ( 250, 23556.2997249444, 10000000.0000005, -0.795770364957142, 53.1303559691475, 1 ),
      ( 300, 0.400972083994595, 999.999999999852, -0.000160134203140022, 31.6438655237917, 2 ),
      ( 300, 4.0155181701093, 9999.99999848971, -0.00160363453426827, 31.719530191655, 2 ),
      ( 300, 40.7539817386377, 99999.9825512949, -0.0162731131475876, 32.4922073736122, 2 ),
      ( 300, 21275.7541710796, 1000000.01503208, -0.981156584276997, 51.8853036815456, 1 ),
      ( 300, 21572.8399938654, 10000000.000024, -0.814160826871493, 51.6438240893905, 1 ),
      ( 350, 0.343666572518571, 999.999999999957, -9.09352057379954E-05, 33.4305965222545, 2 ),
      ( 350, 3.43948315822036, 9999.99999957909, -0.000910005019586669, 33.4656156190988, 2 ),
      ( 350, 34.6814378108079, 99999.9954286643, -0.00916645035260714, 33.8202298784209, 2 ),
      ( 350, 381.69527351021, 999999.999029998, -0.0997129254213598, 37.9074985299652, 2 ),
      ( 350, 19320.2030337498, 10000000.0032386, -0.822136796059592, 50.8392692950072, 1 ),
      ( 400, 0.300698001976976, 999.995100684791, -5.68540729217232E-05, 35.1548088612857, 2 ),
      ( 400, 3.00852019412168, 9999.99999990201, -0.000568762760534783, 35.1712381879909, 2 ),
      ( 400, 30.2407578929251, 99999.9987578582, -0.00570975408524889, 35.3368196986435, 2 ),
      ( 400, 319.716567114056, 999999.999984511, -0.0595391765227901, 37.1366952003275, 2 ),
      ( 400, 16304.5063051621, 9999999.99999983, -0.815584170192331, 51.1959132944051, 1 ),
      ( 500, 0.240550936023021, 999.992576545764, -2.58206737775749E-05, 38.2306554250471, 2 ),
      ( 500, 2.40606858734112, 9999.99999999286, -0.000258238459087019, 38.2353999451494, 2 ),
      ( 500, 24.1168233932855, 99999.9999275231, -0.00258537010340301, 38.2829613196886, 2 ),
      ( 500, 247.005714324277, 999999.999999989, -0.0261572472211277, 38.7706422169618, 2 ),
      ( 500, 3409.12515250868, 10000000.0000034, -0.294409228087384, 45.3123566615245, 2 ),
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