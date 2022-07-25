#I "bin/Release/net6.0"
#r "AltaxoCore.Redist.dll"
#r "FSOde.dll"
#r "nuget: Plotly.NET"

open FsODE
open System
open Plotly.NET

let ctx = new OdeContext(Altaxo.Calc.Ode.RK8713M())

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
|> Seq.map (fun (t, vals) ->
    (t, vals[0]),(t, vals[1])
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
|> Seq.map (fun (x,y) -> x,y[0])
|> Seq.take 10
|> Chart.Point 
|> Chart.show


// Define a function which calculates the derivative
// Simple version (no vector)
let dy_dx : SimpleModel =     
    fun y x ->            
        x - y


ctx.OdeInt(0.,1.,dy_dx)
|> Seq.take 10
|> Chart.Point 
|> Chart.show