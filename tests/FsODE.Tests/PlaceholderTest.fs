module PlaceholderTest

open Expecto

[<Tests>]
let ``placeholder test pls replace`` =
    testList "placeholder tests" [
        testCase "pls replace" (fun _ ->
            Expect.isTrue true "no"
        )
    ]