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
  /// Tests and test data for <see cref="Mixture_Water_Helium"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_Water_Helium : MixtureTestBase
  {

    public Test_Mixture_Water_Helium()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("7732-18-5", 0.5), ("7440-59-7", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 300, 0.400905496054228, 1000.01416708973, 4.75571772051469E-06, 12.4845275445897, 1 ),
      ( 300, 4.00888337966058, 10000.0000000048, 4.75560217817018E-05, 12.4846161729862, 1 ),
      ( 300, 40.0716856939555, 100000.000047672, 0.000475512017569996, 12.4855022603634, 1 ),
      ( 300, 399.011987168747, 1000000, 0.00475027193218788, 12.4943433695563, 1 ),
      ( 300, 3829.04873820413, 10000000.0186782, 0.0470156690715557, 12.5808132749191, 1 ),
      ( 350, 0.34363354069216, 1000, 4.00379943140726E-06, 12.4848089910684, 1 ),
      ( 350, 3.43621158760508, 10000.0000000216, 4.00376143182753E-05, 12.4848836486759, 1 ),
      ( 350, 34.3497401424636, 100000.00021534, 0.000400338130709155, 12.4856300773794, 1 ),
      ( 350, 342.266000419641, 1000000.00000001, 0.00399956789816537, 12.4930796531015, 1 ),
      ( 350, 3305.40541621289, 10000000.0000093, 0.0396150343507946, 12.5661316248645, 1 ),
      ( 350, 25119.4010918876, 100000000, 0.368006009677167, 13.1783262940387, 1 ),
      ( 400, 0.300679517593208, 1000.01811816695, 3.440177714921E-06, 12.4851913482863, 1 ),
      ( 400, 3.0067020865403, 10000.0000000057, 3.44008522108363E-05, 12.4852555203415, 1 ),
      ( 400, 30.0577159929747, 100000.000056471, 0.000343978350770308, 12.4858971293177, 1 ),
      ( 400, 299.650724038696, 1000000, 0.00343676100773375, 12.4923019519568, 1 ),
      ( 400, 2907.74762795524, 10000000.0000001, 0.0340668807522485, 12.5552440582006, 1 ),
      ( 400, 22814.7554138342, 99999999.9999999, 0.317921435103873, 13.0930779063001, 1 ),
      ( 500, 0.240543789766481, 1000.01093945522, 2.65661532129753E-06, 12.4861538848605, 1 ),
      ( 500, 2.40538051518673, 10000.0000000016, 2.65656666007124E-05, 12.4862034636381, 1 ),
      ( 500, 24.0480561055829, 100000.000016222, 0.00026563692405832, 12.4866991811225, 1 ),
      ( 500, 239.907632159427, 1000000, 0.00265439413619075, 12.4916492782064, 1 ),
      ( 500, 2343.69292605759, 10000000.0018477, 0.0263479438755405, 12.5404542866876, 1 ),
      ( 500, 19273.8269068425, 100000000.000643, 0.248036742963836, 12.9697283181755, 1 ),
      ( 600, 0.200453263309525, 1000.00723637775, 2.14222309071579E-06, 12.4872514387073, 1 ),
      ( 600, 2.00449407294946, 10000.0000000006, 2.14219408646466E-05, 12.487291424326, 1 ),
      ( 600, 20.0410772157626, 100000.000005751, 0.000214205814431772, 12.4876912330848, 1 ),
      ( 600, 200.025506940244, 999999.999999997, 0.00214069883490842, 12.4916845527654, 1 ),
      ( 600, 1962.78428148777, 10000000.0002096, 0.021272195834176, 12.5311480833418, 1 ),
      ( 600, 16679.3707677033, 99999999.9999996, 0.201806135867174, 12.8854122193773, 1 ),
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
      ( 300, 0.400914071568633, 999.999999999959, -1.05942828429956E-05, 18.8766787090012, 2 ),
      ( 350, 0.343639107003325, 999.999999999994, -6.15429451442151E-06, 19.0181075425488, 2 ),
      ( 350, 3.43658141892125, 9999.9999999407, -6.15429768499838E-05, 19.0189290448526, 2 ),
      ( 400, 0.30068346305779, 1000, -3.64146769653004E-06, 19.2098341849367, 2 ),
      ( 400, 3.00693317470684, 9999.99999999074, -3.64136526342267E-05, 19.2103560938074, 2 ),
      ( 400, 30.0791866534381, 99999.9999075688, -0.000364033798077055, 19.2155744835231, 2 ),
      ( 500, 0.240546177110068, 999.994436050312, -1.15181340835012E-06, 19.6918818971136, 2 ),
      ( 500, 2.40548664924366, 9999.9999999998, -1.15170933476453E-05, 19.6921476443486, 2 ),
      ( 500, 24.0573574985121, 99999.9999982013, -0.000115060360161611, 19.694804554339, 2 ),
      ( 500, 240.820291027436, 999999.983950721, -0.00113942441853587, 19.721317326155, 2 ),
      ( 500, 2430.03898310471, 10000000.0000003, -0.0101150797293166, 19.9804571827046, 2 ),
      ( 600, 0.200454929335004, 999.999655104229, -8.43634235240094E-08, 20.2411772538606, 2 ),
      ( 600, 2.00455081034108, 9999.99999999999, -8.4282386809271E-07, 20.2413419269842, 2 ),
      ( 600, 20.0456585321803, 99999.9999999998, -8.34712423373378E-06, 20.2429883644203, 2 ),
      ( 600, 200.470009429671, 999999.999998965, -7.53097380095138E-05, 20.2594234053943, 2 ),
      ( 600, 2004.29931091735, 9999999.99999997, 0.000124637041664222, 20.4208440944984, 1 ),
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
      ( 350, 0.343707476060043, 999.999999732602, -0.000199030505708219, 25.5825813821737, 2 ),
      ( 350, 3.44328815206149, 9999.99983283711, -0.0020031649291391, 25.8711936664863, 2 ),
      ( 400, 0.300715506211077, 999.999999971332, -0.000104157905350995, 25.9454335518548, 2 ),
      ( 400, 3.00998516398698, 9999.99969931804, -0.00104429775624389, 26.0465547816297, 2 ),
      ( 400, 30.3942734280735, 100000.000043213, -0.0107209336337541, 27.1404953573691, 2 ),
      ( 400, 65914.0173122115, 1000000000, 3.56176389446283, 57.8465489433754, 1 ),
      ( 500, 0.240557103468091, 999.999999998956, -4.05559298654804E-05, 26.8999663704026, 2 ),
      ( 500, 2.40645003890763, 9999.99998938747, -0.000405811207394061, 26.9224941967473, 2 ),
      ( 500, 24.1533643186889, 99999.9999999997, -0.00408347143448065, 27.1531723127865, 2 ),
      ( 500, 251.504155198453, 999999.999999981, -0.04356511620547, 30.0314133316413, 2 ),
      ( 500, 46425.6248849871, 9999999.99999844, -0.948186513795542, 57.9207469732076, 1 ),
      ( 500, 49848.368600486, 100000000.000005, -0.517441885853736, 57.2185410971326, 1 ),
      ( 500, 63225.0011365969, 1000000000, 2.80462385332937, 54.9821999836021, 1 ),
      ( 600, 0.200460121389285, 999.999999999996, -1.9946677486699E-05, 27.9958868196018, 2 ),
      ( 600, 2.00496123903436, 9999.99999931013, -0.000199510228723793, 28.0040794070374, 2 ),
      ( 600, 20.0857729618339, 99999.9913232324, -0.00199945856179944, 28.086642638966, 2 ),
      ( 600, 204.639326264074, 999999.999803424, -0.020441835221538, 28.9770156109778, 2 ),
      ( 600, 2753.00891217561, 10000000, -0.271865332548158, 46.9084137067222, 2 ),
      ( 600, 43853.4311701281, 99999999.9999999, -0.542895236410965, 52.6778422890384, 1 ),
      ( 600, 60543.9588126082, 1000000000, 2.31091865823199, 52.9756486368786, 1 ),
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
