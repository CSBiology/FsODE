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
  /// Tests and test data for <see cref="Mixture_Isobutane_Hydrogen"/>.
  /// </summary>
  /// <remarks>
  /// <para>Reference:</para>
  /// <para>The test data was created automatically using calls into the TREND.DLL of the following software:</para>
  /// <para>TREND 3.0.: Span, R.; Eckermann, T.; Herrig, S.; Hielscher, S.; Jäger, A.; Thol, M. (2016): TREND.Thermodynamic Reference and Engineering Data 3.0.Lehrstuhl für Thermodynamik, Ruhr-Universität Bochum.</para>
  /// </remarks>
  
  public class Test_Mixture_Isobutane_Hydrogen : MixtureTestBase
  {

    public Test_Mixture_Isobutane_Hydrogen()
    {
      _mixture = MixtureOfFluids.FromCASRegistryNumbersAndMoleFractions(new[] { ("75-28-5", 0.5), ("1333-74-0", 0.5) });

      // TestData for 1 Permille to 999 Permille Molefraction contains:
      // 0. Temperature (Kelvin)
      // 1. Mole density (mol/m³)
      // 2. Pressure (Pa)
      // 3. delta*AlphaR_delta
      // 4. Isochoric heat capacity (J/mol K)
      // 5. Phasetype (1: liquid, 2: gas)
      _testData_001_999 = new (double temperature, double moleDensity, double pressure, double deltaPhiR_delta, double cv, int phase)[]
      {
      ( 150, 0.801810282518427, 1000.00000000072, 5.6285349472375E-06, 17.104150272644, 1 ),
      ( 200, 0.601357085740882, 1000.00000000309, 6.66976565315593E-06, 19.0078849364642, 1 ),
      ( 200, 6.01320986634584, 10000.0000313634, 6.67031721016084E-05, 19.0081154140149, 1 ),
      ( 200, 60.0959903690782, 100000, 0.000667586902945451, 19.0104199476184, 1 ),
      ( 200, 597.338187061114, 1000000.00768628, 0.00673472700888456, 19.0334402130008, 1 ),
      ( 250, 0.481085805209648, 1000.00000000178, 6.38578750938396E-06, 20.0638446260587, 1 ),
      ( 250, 4.81058156845207, 10000.0000179239, 6.38602127107007E-05, 20.064025402943, 1 ),
      ( 250, 48.0781736050247, 100000, 0.000638837227106416, 20.0658331017889, 1 ),
      ( 250, 478.023251016374, 1000000.00805281, 0.00641313225513366, 20.0839021582136, 1 ),
      ( 250, 4508.17070798213, 10000000.0035637, 0.0671487583220821, 20.2630335555157, 1 ),
      ( 300, 0.400905057624238, 1000.00000000097, 5.83715153944467E-06, 20.6011442793645, 1 ),
      ( 300, 4.00883997157854, 10000.0000097006, 5.83725220929921E-05, 20.6012940412302, 1 ),
      ( 300, 40.0673473977103, 100000, 0.000583826496849878, 20.6027915880343, 1 ),
      ( 300, 398.576139870583, 1000000.00364449, 0.00584896499350564, 20.6177592641089, 1 ),
      ( 300, 3782.71146088562, 10000000.000099, 0.0598413384513883, 20.7661550417968, 1 ),
      ( 350, 0.343633098699083, 1000.00000000053, 5.27793548939937E-06, 20.8537879542395, 1 ),
      ( 350, 3.43616776363203, 10000.0000053545, 5.27797548448418E-05, 20.8539159833066, 1 ),
      ( 350, 34.3453624546219, 99999.9999999998, 0.000527837859973251, 20.8551961873863, 1 ),
      ( 350, 341.829127780143, 1000000.00084063, 0.00528271126351306, 20.8679892012814, 1 ),
      ( 350, 3262.06997120035, 10000000.0000048, 0.053425939376679, 20.9947102262456, 1 ),
      ( 400, 0.300679113600923, 1000.00000000001, 4.77161489211474E-06, 20.9666479790991, 1 ),
      ( 400, 3.00666201660114, 10000.0000000915, 4.77162569837895E-05, 20.9667597250939, 1 ),
      ( 400, 30.0537139948631, 100000.000912759, 0.000477173565153976, 20.9678770912222, 1 ),
      ( 400, 299.252214389032, 1000000.00000019, 0.00477301039576584, 20.9790411474434, 1 ),
      ( 400, 2869.18989560534, 10000000.0017006, 0.0479632205200464, 21.0895354150249, 1 ),
      ( 500, 0.240543470511833, 1000, 3.94592048552463E-06, 21.0603938542986, 1 ),
      ( 500, 2.40534947367724, 10000.0000000332, 3.94591017516393E-05, 21.0604826028209, 1 ),
      ( 500, 24.0449561959019, 100000.00033159, 0.000394580473372857, 21.0613699974169, 1 ),
      ( 500, 239.599261819104, 1000000.00000002, 0.00394482366702634, 21.0702347977702, 1 ),
      ( 500, 2314.26099358687, 10000000.0000518, 0.0394006524212955, 21.1578982705476, 1 ),
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
      ( 200, 0.601441555734472, 999.999999999869, -0.00013377705944413, 41.2433782168832, 2 ),
      ( 250, 0.481122066129569, 999.999999761729, -6.89820952379682E-05, 47.8191526067681, 2 ),
      ( 250, 4.81421093942047, 9999.99999996595, -0.000690074915330098, 47.8255913508809, 2 ),
      ( 250, 48.4444291993508, 100000.002923644, -0.00692631700532777, 47.8904450124655, 2 ),
      ( 300, 0.400922988744611, 999.999999969866, -3.88877097016387E-05, 54.6803059772909, 2 ),
      ( 300, 4.01063378576707, 9999.99969559522, -0.00038891809243573, 54.6837494458699, 2 ),
      ( 300, 40.2474331049935, 99999.9998611885, -0.00389325021320028, 54.7182302197072, 2 ),
      ( 350, 0.343642789032518, 999.999999995466, -2.29210690850071E-05, 61.6712940777303, 2 ),
      ( 350, 3.4371369101993, 9999.99995451421, -0.000229198455631411, 61.6733906193367, 2 ),
      ( 350, 34.4423894220506, 99999.9999999977, -0.00229072912916354, 61.6943439624302, 2 ),
      ( 350, 351.634197061906, 999999.99396342, -0.0227488813900699, 61.9024699141179, 2 ),
      ( 400, 0.300684659430197, 999.999999999726, -1.36724778236569E-05, 68.4973339213548, 2 ),
      ( 400, 3.00721656981432, 9999.99999725093, -0.000136700016800527, 68.4987390232603, 2 ),
      ( 400, 30.1091389014828, 99999.9999999999, -0.00136450494370634, 68.512773751084, 2 ),
      ( 400, 304.757141286172, 999999.999789637, -0.0133765297255089, 68.6513821187023, 2 ),
      ( 500, 0.240545474887937, 999.999999999974, -4.30782266891326E-06, 80.9378133357223, 2 ),
      ( 500, 2.40554795749537, 9999.99999972378, -4.30550088052364E-05, 80.9385871392018, 2 ),
      ( 500, 24.0647489491732, 99999.9977220395, -0.000428223161293991, 80.9463160726398, 2 ),
      ( 500, 241.52130808902, 1000000, -0.00404465110751291, 81.0226661262489, 2 ),
      ( 500, 2439.23383928616, 10000000.0000036, -0.0138524860286297, 81.6714185417476, 1 ),
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
      ( 200, 0.601933673628021, 999.999999979547, -0.000951229348470063, 63.5107686095565, 2 ),
      ( 250, 0.481304840609729, 999.999999997459, -0.000448703753055083, 75.5862509645772, 2 ),
      ( 250, 4.83268057300592, 9999.99997318974, -0.00450925719455696, 75.7067562970195, 2 ),
      ( 250, 10623.3314250378, 10000000.0000495, -0.54713935010387, 88.106228544294, 1 ),
      ( 300, 0.401007044856237, 999.999999999538, -0.000248492114294907, 88.7647619983136, 2 ),
      ( 300, 4.01908375021953, 9999.99999520108, -0.0024905608208601, 88.8194910983663, 2 ),
      ( 300, 41.1397488589493, 99999.9999999994, -0.0254986749132743, 89.4026098723369, 2 ),
      ( 300, 9745.90245312899, 10000000.0023901, -0.588640046638015, 98.6179750446833, 1 ),
      ( 350, 0.343687116453393, 999.999999999926, -0.00015189420401265, 102.491502228987, 2 ),
      ( 350, 3.44158283828834, 9999.99999923951, -0.00152072892251311, 102.519971662685, 2 ),
      ( 350, 34.9006449207092, 99999.9894677442, -0.0153909369682137, 102.813404415034, 2 ),
      ( 350, 419.061664353747, 999999.999997578, -0.179989625386015, 106.965292715359, 2 ),
      ( 350, 8757.05876458614, 10000000.0000002, -0.607590948502122, 110.594591520425, 1 ),
      ( 400, 0.300710317314405, 999.997180047196, -9.89952884180146E-05, 116.02955539184, 2 ),
      ( 400, 3.00978694713327, 9999.99999994205, -0.000990589675099294, 116.046100339528, 2 ),
      ( 400, 30.370860977929, 99999.9990570746, -0.00997028488958475, 116.2142051204, 2 ),
      ( 400, 336.844278941557, 999999.99936655, -0.107360382382866, 118.218557518736, 2 ),
      ( 400, 7550.57269212996, 10000000.0000226, -0.601777824561773, 123.382356306612, 1 ),
      ( 500, 0.240555785616579, 999.997089752992, -4.71696111557828E-05, 140.815835532939, 2 ),
      ( 500, 2.40657972861798, 9999.99999999796, -0.000471765800051127, 140.822721909433, 2 ),
      ( 500, 24.1686287114524, 99999.9999762458, -0.00472450655805196, 140.8918709067, 2 ),
      ( 500, 252.657844632649, 999999.999999972, -0.0479439139899816, 141.612797821619, 2 ),
      ( 500, 4090.34475837127, 9999999.99999997, -0.411921359028747, 147.715002779548, 1 ),
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