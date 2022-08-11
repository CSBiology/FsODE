module TestTasks

open BlackFox.Fake
open Fake.DotNet

open ProjectInfo
open BasicTasks

let buildTests = BuildTask.create "BuildTests" [clean; build] {
    testProjects
    |> List.iter (fun pInfo ->
        let proj = pInfo.ProjFile
        proj
        |> DotNet.build (fun p ->
            p
            |> DotNet.Options.withCustomParams (Some "--no-dependencies")
        )
    )
}

/// runs the individual test projects via `dotnet test`
let runTests =
    BuildTask.create "RunTests" [ clean; build; buildTests ] {
        testProjects
        |> Seq.iter (fun testProjectInfo ->
            Fake.DotNet.DotNet.test
                (fun testParams ->
                    { testParams with
                        Logger = Some "console;verbosity=detailed"
                        Configuration = DotNet.BuildConfiguration.fromString configuration
                        NoBuild = true
                    })
                testProjectInfo.ProjFile)
    }