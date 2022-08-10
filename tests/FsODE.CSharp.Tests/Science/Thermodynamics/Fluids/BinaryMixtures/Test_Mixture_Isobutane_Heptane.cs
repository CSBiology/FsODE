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
  /// Tests and test data for <see cref="Mixture_Isobutane_Heptane"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_Isobutane_Heptane : MixtureTestBase
  {

    public Test_Mixture_Isobutane_Heptane()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("75-28-5", 0.5), ("142-82-5", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 200, 7599.83327759306, 100000.000000459, -0.992087216630954, 151.670757183871, 1 ),
      ( 200, 7604.5509739535, 1000000.0000025, -0.920921254606146, 151.731447950141, 1 ),
      ( 200, 7650.23505385346, 9999999.99999969, -0.213934804986881, 152.330513891193, 1 ),
      ( 250, 7184.50733737327, 99999.9999992884, -0.993303832138459, 162.714758512877, 1 ),
      ( 250, 7190.932002661, 1000000.00011818, -0.933098146415003, 162.770484054134, 1 ),
      ( 250, 7252.31525744011, 10000000.0000009, -0.336644004468889, 163.320310733211, 1 ),
      ( 300, 0.401357900603549, 999.99994338762, -0.00112700722601217, 157.659033423868, 2 ),
      ( 300, 6768.47676740771, 100000.0000001, -0.994076871747596, 178.433415044988, 1 ),
      ( 300, 6777.44677113243, 1000000.00784633, -0.940847109046336, 178.484705291839, 1 ),
      ( 300, 6861.37830153141, 10000000.0000081, -0.41570694737106, 178.994299460954, 1 ),
      ( 350, 0.343847011718356, 999.999992995912, -0.000621405128827684, 179.88946187311, 2 ),
      ( 350, 3.4579415928988, 9999.99999999796, -0.00624885005829092, 180.163286003613, 2 ),
      ( 350, 6331.78292566116, 100000.000003394, -0.994572881801753, 197.204880421851, 1 ),
      ( 350, 6344.94020868482, 999999.999999824, -0.94584135829211, 197.248427614923, 1 ),
      ( 350, 6463.75286090112, 10000000.0001645, -0.468368684861866, 197.698631464391, 1 ),
      ( 400, 0.30079264781973, 999.999998785588, -0.00037724434992507, 202.273839765307, 2 ),
      ( 400, 3.01821543215388, 9999.98690152904, -0.00378490615799887, 202.420975984824, 2 ),
      ( 400, 31.2944231659961, 99999.9999999998, -0.0391924660256645, 203.954139089496, 2 ),
      ( 400, 5867.93027266333, 1000000.00279808, -0.948758904356539, 217.12616559962, 1 ),
      ( 400, 6046.7354913459, 10000000.0023718, -0.502741312252612, 217.438965550838, 1 ),
      ( 500, 0.24058367855598, 999.99999992928, -0.000167667906898096, 243.688226119832, 2 ),
      ( 500, 2.40947857185389, 9999.99927012052, -0.00167885602369472, 243.740689219535, 2 ),
      ( 500, 24.4706334393643, 99999.9999914035, -0.0170122036662225, 244.274541499404, 2 ),
      ( 500, 301.345799068779, 999999.999915087, -0.20176972387022, 250.959029273758, 2 ),
      ( 500, 5089.01945417481, 9999999.99999984, -0.527328707307613, 255.648064660795, 1 ),
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
      ( 200, 9017.89574707859, 100000.000000152, -0.993331485119654, 114.930165324712, 1 ),
      ( 200, 9025.0379823788, 1000000.00204926, -0.93336762409165, 114.986409517402, 1 ),
      ( 200, 9093.75388590178, 10000000.0000006, -0.33871124073117, 115.529709324046, 1 ),
      ( 250, 8451.66499668056, 100000.000000286, -0.994307775157485, 124.815662305716, 1 ),
      ( 250, 8461.93952127689, 1000000.00679652, -0.943146866068454, 124.869266331496, 1 ),
      ( 250, 8558.74896212274, 10000000.0000026, -0.437899417223548, 125.387521179494, 1 ),
      ( 300, 0.401124164110348, 999.999998525752, -0.000542681049941067, 123.268463364571, 2 ),
      ( 300, 4.03105507443062, 10000.0000191925, -0.00545521151623274, 123.468203206202, 2 ),
      ( 300, 7869.51309011577, 1000000.0015369, -0.949055744963445, 138.077836702523, 1 ),
      ( 300, 8011.48660899891, 10000000.0000012, -0.499585406318133, 138.560670745305, 1 ),
      ( 350, 0.343742510919253, 999.999999791754, -0.00031530522562227, 141.264240726917, 2 ),
      ( 350, 3.44724110465554, 9999.99779584981, -0.00316189984973477, 141.363306844172, 2 ),
      ( 350, 35.5199847784768, 99999.9991099818, -0.0325611642042837, 142.402063531019, 2 ),
      ( 350, 7208.54931699647, 1000000.00000015, -0.952329641929601, 153.519034119149, 1 ),
      ( 350, 7432.92228666435, 9999999.99999993, -0.53768637172026, 153.885809441028, 1 ),
      ( 400, 0.300739740149109, 999.999999960255, -0.000199105473947566, 159.239288540051, 2 ),
      ( 400, 3.0128069862251, 9999.99958839425, -0.00199427769316621, 159.293555844002, 2 ),
      ( 400, 30.6902846833561, 99999.9999964664, -0.0202767282119833, 159.851047806506, 2 ),
      ( 400, 6796.91949080211, 10000000.0000311, -0.557623329763143, 169.984636444545, 1 ),
      ( 500, 0.240566182521112, 999.999999999853, -9.2671149333287E-05, 192.362295064542, 2 ),
      ( 500, 2.40767134267656, 9999.99997872181, -0.000927224935972879, 192.382576709137, 2 ),
      ( 500, 24.2807888019226, 99999.9999999958, -0.0093242399212526, 192.587581388926, 2 ),
      ( 500, 267.029406232182, 1000000.01116062, -0.0991857711376098, 194.88571734399, 2 ),
      ( 500, 5174.81024288374, 9999999.99455864, -0.535163846427775, 201.717826148681, 1 ),
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
      ( 200, 0.601936852903923, 999.999999989063, -0.000956510633536527, 63.6114260771586, 2 ),
      ( 200, 11311.1366066374, 100000.000001769, -0.994683460082926, 79.2763338120922, 1 ),
      ( 200, 11322.6475656389, 1000000.00225492, -0.946888650232163, 79.3386331447446, 1 ),
      ( 200, 11432.3383254386, 10000000.0000007, -0.473982420060225, 79.9305457476868, 1 ),
      ( 250, 0.481305925087221, 999.999999997161, -0.000450960508203461, 75.7035017792816, 2 ),
      ( 250, 4.83279131109919, 9999.9999697833, -0.00453207231688564, 75.8249656202064, 2 ),
      ( 250, 10426.8829548568, 100000.000001829, -0.995386071997893, 87.657326974171, 1 ),
      ( 250, 10445.322178777, 1000000.00000259, -0.953942169837196, 87.7150177128225, 1 ),
      ( 250, 10614.7901991973, 10000000.000051, -0.546774956364049, 88.2671193923147, 1 ),
      ( 300, 0.401007511959645, 999.999999999582, -0.000249661218631391, 88.9019409415398, 2 ),
      ( 300, 4.0191310809064, 9999.99999563714, -0.00250231239826575, 88.9570885708073, 2 ),
      ( 300, 41.1449862474428, 99999.9999999995, -0.0256227246632175, 89.544843356868, 2 ),
      ( 300, 9453.65466415374, 999999.999999943, -0.957592337547964, 98.3489601862911, 1 ),
      ( 300, 9739.99923187118, 10000000.0021837, -0.58839073138038, 98.7890868495887, 1 ),
      ( 350, 0.343687350959462, 999.999999999968, -0.000152580993845611, 102.650689644332, 2 ),
      ( 350, 3.44160656070077, 9999.99999966887, -0.00152761583481435, 102.679368499353, 2 ),
      ( 350, 34.903156355235, 99999.9947221625, -0.0154617892055983, 102.975008347874, 2 ),
      ( 350, 419.603473082939, 999999.999668735, -0.181048459135493, 107.168036587484, 2 ),
      ( 350, 8754.74455525608, 10000000.0000002, -0.607487221776906, 110.778330055948, 1 ),
      ( 400, 0.300710448148997, 999.998304929365, -9.94350108136156E-05, 116.211040327067, 2 ),
      ( 400, 3.00980019904928, 9999.99999997888, -0.000994992801572861, 116.227702048902, 2 ),
      ( 400, 30.372233660518, 99999.9996409229, -0.0100150341721012, 116.397010611317, 2 ),
      ( 400, 337.04906472743, 999999.999513325, -0.107902740468437, 118.418276560717, 2 ),
      ( 400, 7553.92733865894, 10000000.0000002, -0.60195467407682, 123.576579471102, 1 ),
      ( 500, 0.240555835627792, 999.998395036177, -4.73821312735438E-05, 141.038684799363, 2 ),
      ( 500, 2.40658483590421, 9999.99999999939, -0.000473891580292476, 141.045615022107, 2 ),
      ( 500, 24.1691477381003, 99999.9999924653, -0.00474588440956932, 141.115207142637, 2 ),
      ( 500, 252.718025098537, 999999.999999995, -0.0481706341780501, 141.841064377935, 2 ),
      ( 500, 4103.55502693608, 10000000, -0.413814519404852, 147.973072694739, 1 ),
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