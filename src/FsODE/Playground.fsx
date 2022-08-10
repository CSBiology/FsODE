/////////////////////////////////////////////////////////////////////////////
//    FsODE:  Ordinary Differential Equation (ODE) Models in F#
//    Copyright (C) 2022 CSBiolgy.
//
//
//    This program is free software; you can redistribute it and/or modify
//    it under the terms of the GNU General Public License as published by
//    the Free Software Foundation; either version 3 of the License, or
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
//    FsODE is derivative work bilt on top of a subset of Altaxo (https://github.com/Altaxo/Altaxo):
//
//    Altaxo:  a data processing and data plotting program
//    Copyright (C) 2002-2021 Dr. Dirk Lellinger
//
//    also distributed under GPL v3.0. All used source files from Altaxo are unchanged, unused ones 
//    present in the original source code were removed.
//
/////////////////////////////////////////////////////////////////////////////

#I "bin/Release/net6.0"
#r "AltaxoCore.Redist.dll"
#r "FSOde.dll"
#r "nuget: Plotly.NET"

open FsODE
open System
open Plotly.NET

let ctx = new OdeContext(OdeSolverMethod.RK8713M)

let y0 = [|Math.PI - 0.1; 0.0|]
let t = [|0. .. 0.1 .. 10.|]

// trying to port the scipy example at https://docs.scipy.org/doc/scipy/reference/generated/scipy.integrate.odeint.html
let sol =
    ctx.OdeInt(
        0., 
        y0, 
        (fun y t ->
            let theta, omega = y[0], y[1]
            [|omega; -0.25 * omega - 5. * sin(theta)|]
        )
    )

sol
|> Seq.map (fun p ->
    (p.x, p.Y[0]),(p.x, p.Y[1])
)
|> Seq.take 100
|> Seq.toArray
|> Array.unzip
|> fun (theta, omega) ->
    [
        Chart.Line(theta, Name="theta(t)")
        Chart.Line(omega, Name="omega(t)")
    ]
|> Chart.combine
|> Chart.show

// Define a function which calculates the derivative
let dyV_dx : Model=     
    fun y x ->            
        [|x - y.[0] |]

ctx.OdeInt(0.,[|1.|],dyV_dx)
|> Seq.map (fun p -> p.x,p.Y[0])
|> Seq.take 10
|> Chart.Point 
|> Chart.show


// Define a function which calculates the derivative
// Simple version (no vector)
let dy_dx : SimpleModel =     
    fun y x ->            
        x - y


ctx.OdeInt(0.,1.,dy_dx)
|> SolPoints.take 10
|> SolPoints.toPoints 1
|> Chart.Point 
|> Chart.show