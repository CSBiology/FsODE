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