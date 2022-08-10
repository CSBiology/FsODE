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

namespace FsODE

//################## 



/// Context to solve ordinary differential equations
type OdeContext(?odeSolverMethod:OdeSolverMethod,?odeSolverOptions:OdeSolverOptions) =
    
    let odeSolver = 
        defaultArg odeSolverMethod (OdeSolverMethod.RK546M)
        |> OdeSolverMethod.toSolverObject

    let methodOptions = 
        let oso = defaultArg odeSolverOptions (OdeSolverOptions())
        match oso.AutomaticStepSizeControl with
        | true ->
            Altaxo.Calc.Ode.OdeMethodOptions(InitialStepSize=oso.StepSize,  RelativeTolerance = oso.RelativeTolerance, AutomaticStepSizeControl = true,IncludeInitialValueInOutput = true)
        | false ->
            Altaxo.Calc.Ode.OdeMethodOptions(InitialStepSize=oso.StepSize,  RelativeTolerance = oso.RelativeTolerance, AutomaticStepSizeControl = false,IncludeInitialValueInOutput = true)


    new (odeSolver) = OdeContext(odeSolver)

    /// Sets the initial step size to use the automatic step size control
    member this.SetInitialStepSize(stepSize:float) =
        methodOptions.AutomaticStepSizeControl <- true
        methodOptions.InitialStepSize <- stepSize

    /// Sets the step size (no automatic step size control)
    member this.SetStepSize(stepSize:float) =
        methodOptions.AutomaticStepSizeControl <- false
        methodOptions.StepSize <- stepSize

    /// Sets the relative tolerance for all y-values
    member this.RelativeErrorTolerance(error:float) =
        methodOptions.RelativeTolerance <- error
    
    /// Simulates the model and gets a sequence of solution points
    member this.OdeInt(x0:float,y0:float,simpleModel: float -> float -> float) =
        let fn = (fun x (y:float[]) (d:float[]) ->  d[0] <- simpleModel y[0] x  ) 
        odeSolver.Initialize(x0, [|y0|], System.Action<float,float[],float[]>(fn) )
            .GetSolutionPoints(methodOptions)
            |> Seq.map (fun tmp -> 
            let struct (x,y) = tmp
            SolPoint (x,y[0])
            )
    
    /// Simulates the model and gets a sequence of solution points
    member this.OdeInt(x0:float,y0:float[],model: float[] -> float -> float[]) =
        let fn = 
            (fun x (y:float[]) (d:float[]) ->  
                let d' = model y x
                for i=0 to d.Length-1 do
                    d.[i] <- d'.[i]
            )
        odeSolver.Initialize(x0, y0, System.Action<float,float[],float[]>(fn) )
            .GetSolutionPoints(methodOptions)
            |> Seq.map (fun tmp -> 
            let struct (x,y) = tmp
            SolPoint (x,y)
            )