namespace FsODE

//################## 

type SimpleModel = (float -> float -> float)  

type Model = (float[] -> float -> float[])  



type OdeContext(odeSolver:Altaxo.Calc.Ode.RungeKuttaExplicitBase,?methodOptions:Altaxo.Calc.Ode.OdeMethodOptions) =

    let methodOptions = 
        defaultArg methodOptions (Altaxo.Calc.Ode.OdeMethodOptions(InitialStepSize=1.0,  RelativeTolerance = 1E-5, AutomaticStepSizeControl = true,IncludeInitialValueInOutput = true  ))

    member this.OdeInt(x0:float,y0:float,simpleModel: float -> float -> float) =
        let fn = (fun x (y:float[]) (d:float[]) ->  d[0] <- simpleModel x y[0]  ) 
        odeSolver.Initialize(x0, [|y0|], System.Action<float,float[],float[]>(fn) )
            .GetSolutionPoints(methodOptions)
            |> Seq.map (fun tmp -> 
            let struct (x,y) = tmp
            x,y[0]
            )
    
    member this.OdeInt(x0:float,y0:float[],model: float[] -> float -> float[]) =
        let fn = 
            (fun x (y:float[]) (d:float[]) ->  
                let d' = model y x
                for i=0 to d.Length-1 do
                    d.[i] <- y.[0]
            )
        odeSolver.Initialize(x0, y0, System.Action<float,float[],float[]>(fn) )
            .GetSolutionPoints(methodOptions)
            |> Seq.map (fun tmp -> 
            let struct (x,y) = tmp
            x,y
            )


