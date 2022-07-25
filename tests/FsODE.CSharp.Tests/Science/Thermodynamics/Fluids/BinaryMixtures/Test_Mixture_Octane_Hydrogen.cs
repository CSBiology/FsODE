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
  /// Tests and test data for <see cref="Mixture_Octane_Hydrogen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_Octane_Hydrogen : MixtureTestBase
  {

    public Test_Mixture_Octane_Hydrogen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("111-65-9", 0.5), ("1333-74-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 250, 0.481085799635596, 1000.00000000101, 6.39280360873006E-06, 20.1449952672476, 1 ),
      ( 300, 0.400905050975692, 1000.00000000325, 5.84916510469475E-06, 20.6927019708208, 1 ),
      ( 300, 4.008839471631, 10000.0000327532, 5.84926701848241E-05, 20.6928522245203, 1 ),
      ( 300, 40.0672990529399, 100000, 0.000585029217472276, 20.694354691883, 1 ),
      ( 300, 398.571319124698, 1000000.00118341, 0.0058611261899851, 20.7093717887407, 1 ),
      ( 350, 0.343633092339124, 1000.0000000018, 5.29187321303725E-06, 20.9571130898904, 1 ),
      ( 350, 3.43616726901491, 10000.0000180995, 5.29191363476228E-05, 20.9572415416049, 1 ),
      ( 350, 34.3453144373004, 100000, 0.000529232100051989, 20.9585259737593, 1 ),
      ( 350, 341.824369061631, 1000000.00441037, 0.00529670176197253, 20.9713614234495, 1 ),
      ( 350, 3261.6122070642, 10000000.0000001, 0.0535737818788338, 21.0985180139765, 1 ),
      ( 400, 0.300679107868125, 1000.00000000104, 4.78611078224043E-06, 21.0819550988761, 1 ),
      ( 400, 3.00666156703745, 10000.0000104065, 4.78612161492806E-05, 21.0820672208672, 1 ),
      ( 400, 30.053670311998, 100000, 0.000478623177020429, 21.0831883479764, 1 ),
      ( 400, 299.247893922055, 1000000.00263591, 0.00478751247983115, 21.0943901138199, 1 ),
      ( 400, 2868.78539101638, 10000000.0000078, 0.0481109806723044, 21.2052685612659, 1 ),
      ( 500, 0.240543465970957, 1000, 3.95994722807551E-06, 21.1979393103921, 1 ),
      ( 500, 2.40534912531164, 10000.0000000339, 3.95993664778044E-05, 21.1980283721592, 1 ),
      ( 500, 24.0449223792678, 100000.000337907, 0.000395982850164038, 21.1989188995271, 1 ),
      ( 500, 239.595919963429, 1000000.00000002, 0.00395882198262626, 21.2078150586236, 1 ),
      ( 500, 2313.95241859244, 10000000.000055, 0.0395392559873309, 21.2957939894012, 1 ),
      ( 500, 17315.828721937, 100000000.000332, 0.389159256679373, 22.0670134845797, 1 ),
      ( 600, 0.200453015170544, 1000, 3.33948065817577E-06, 21.3117143504878, 1 ),
      ( 600, 2.00447004109244, 10000.0000000141, 3.33946548574251E-05, 21.3117878202114, 1 ),
      ( 600, 20.0386782570585, 100000.000141245, 0.0003339311925306, 21.3125224388599, 1 ),
      ( 600, 199.786846609553, 1000000, 0.00333781411558099, 21.3198607341306, 1 ),
      ( 600, 1940.01810361058, 10000000.000003, 0.0332568422670909, 21.3924271941841, 1 ),
      ( 600, 15149.6610231307, 99999999.9999997, 0.323156324499324, 22.0356657280213, 1 ),
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
      ( 300, 0.400959728004028, 999.99999999979, -0.000132797318111228, 100.461728006287, 2 ),
      ( 350, 0.343661608559718, 999.999999404858, -7.99666001373669E-05, 113.335269079282, 2 ),
      ( 350, 3.43909256267585, 9999.99999958699, -0.000800005098021218, 113.3483525144, 2 ),
      ( 400, 0.300695073907724, 999.999999882622, -5.05917403840267E-05, 126.151792699202, 2 ),
      ( 400, 3.00832075073602, 9999.99999999992, -0.000505976142831866, 126.159318803315, 2 ),
      ( 400, 30.2210742862443, 99999.9992627841, -0.00506560954147687, 126.234949115812, 2 ),
      ( 500, 0.240549056218633, 999.999999993941, -2.14810327155287E-05, 149.711080256579, 2 ),
      ( 500, 2.40595556952869, 9999.99993983682, -0.000214750333400573, 149.714218225117, 2 ),
      ( 500, 24.1060116055716, 99999.9999999514, -0.00214148689218758, 149.745660693668, 2 ),
      ( 500, 245.652308915614, 999999.999974793, -0.0207953263763438, 150.065357088792, 2 ),
      ( 600, 0.200454963856289, 999.999999999988, -8.5956591776822E-06, 169.740531415748, 2 ),
      ( 600, 2.00470460513964, 9999.99999987458, -8.58964466883917E-05, 169.742169267314, 2 ),
      ( 600, 20.062436454615, 99999.9988518297, -0.000852955875149068, 169.758563240569, 2 ),
      ( 600, 202.056515431545, 999999.999999951, -0.00793478301149238, 169.923679761079, 2 ),
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
      ( 300, 0.401538520406909, 999.999999900635, -0.00157631970723162, 180.317375995645, 2 ),
      ( 350, 0.343927124342987, 999.999999981237, -0.00085419526962521, 205.755946064676, 2 ),
      ( 350, 3.46617312773934, 9999.99979440509, -0.00860882920859205, 206.164458731084, 2 ),
      ( 400, 0.30083265990552, 999.999995879665, -0.000510198634109517, 231.244727589541, 2 ),
      ( 400, 3.02228213586349, 9999.99999999946, -0.00512539205715666, 231.464362473451, 2 ),
      ( 400, 31.7796328622434, 99999.9999882135, -0.0538620228930736, 233.793141084335, 2 ),
      ( 400, 5505.36917403847, 10000000.0009945, -0.453843755046187, 250.513628891209, 1 ),
      ( 400, 6208.82099873816, 99999999.9999999, 3.84277410420584, 254.765430082669, 1 ),
      ( 500, 0.24059640586759, 999.99999977916, -0.000220558047099865, 278.232822049291, 2 ),
      ( 500, 2.41076030783153, 9999.99769302822, -0.00220963595425398, 278.31131685635, 2 ),
      ( 500, 24.6084622762565, 99999.9998452629, -0.0225177920401473, 279.114601831523, 2 ),
      ( 500, 4744.20393819588, 10000000.0000002, -0.492974282877507, 293.142120876186, 1 ),
      ( 500, 5812.35569830391, 99999999.9999985, 3.1384827921724, 296.562500931385, 1 ),
      ( 600, 0.200475112027712, 999.999999979357, -0.000111377246209548, 318.173466793269, 2 ),
      ( 600, 2.00676457024254, 9999.99978925877, -0.00111459690387641, 318.207680602625, 2 ),
      ( 600, 20.272937106399, 99999.9999996353, -0.0112296868040719, 318.553848675481, 2 ),
      ( 600, 228.352629125169, 999999.999746108, -0.122178779208386, 322.480772581482, 2 ),
      ( 600, 3794.5097880245, 9999999.99996596, -0.471729433147101, 331.243250328736, 1 ),
      ( 600, 5452.0509235202, 99999999.9999998, 2.67664914494538, 332.986054940309, 1 ),
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