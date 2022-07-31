namespace FsODE

/// Defines a model with one dimension
type SimpleModel = (float -> float -> float)  

/// Defines a model with one dimension
type Model = (float[] -> float -> float[])  


/// Structure to represent solution point. Current point has form (x,y1,y2,...,yn), where n is problem's dimension
[<Struct>]
type SolPoint(_x: float, y: float[]) =
    new(x,y) = SolPoint(x,[|y|])
    member this.x = _x
    /// Problem's phase variable vector
    member this.Y = y  
    
    /// n is the dimension (1,2,... n)
    member this.point( n ) = (_x,y[n-1])
    
    static member toPoint (n) (p:SolPoint) = p.point n

/// Module to manipulate a sequence of solution point. Points have the form (x,y1,y2,...,yn), where n is problem's dimension
type SolPoints() =
    
    // (x,y_n), where n is dimension (1,2,... n) 
    static member toPoints dim (p:seq<SolPoint>) = 
        p |> Seq.map (fun p -> p.point dim)

    static member toX (p:seq<SolPoint>) =
        p |> Seq.map (fun p -> p.x)

    static member toY n (p:seq<SolPoint>) =
        p |> Seq.map (fun p -> p.Y[n])

    static member map f (p:seq<SolPoint>) =
        p |> Seq.map f

    static member take n (p:seq<SolPoint>) =
        p |> Seq.take n
        
    static member memorize (p:seq<SolPoint>) =
        p |> Seq.toArray

    // static member evalModel (model:Model) (X:seq<float>) =
    //     X |> Seq.map (fun x -> SolPoint(x, model x)) 

/// ODE solver method
type OdeSolverMethod =
    | RK546M
    | RK547M
    | RK8713M
    
    static member toSolverObject (osm:OdeSolverMethod) : Altaxo.Calc.Ode.RungeKuttaExplicitBase =
        match osm with
        | RK546M -> Altaxo.Calc.Ode.RK546M()
        | RK547M -> Altaxo.Calc.Ode.RK547M()
        | RK8713M -> Altaxo.Calc.Ode.RK8713M()

/// ODE solver options
type OdeSolverOptions(?StepSize,?RelativeTolerance,?AutomaticStepSizeControl) =
    let mutable stepSize = defaultArg StepSize 1.
    let mutable relativeTolerance = defaultArg RelativeTolerance 1e-3
    let mutable automaticStepSizeControl = defaultArg AutomaticStepSizeControl true
    
    ///Step size (if no automatic step size control) or initial step size to use the automatic step size control
    member this.StepSize
            with get() = stepSize
            and set(value) = stepSize <- value
    
    /// Relative tolerance for all y-values
    member this.RelativeTolerance
            with get() = relativeTolerance
            and set(value) = relativeTolerance <- value    
    
    /// Value indicating whether automatic step size control is switched on
    member this.AutomaticStepSizeControl
            with get() = automaticStepSizeControl
            and set(value) = automaticStepSizeControl <- value
    



