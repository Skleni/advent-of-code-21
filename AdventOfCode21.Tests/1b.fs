module AOC1b.Tests

open System
open Xunit
open AOC1b

[<Fact>]
let ``Empty sequences returns 0`` () =
    let input = Seq.empty
    let actual = countWindowIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``One element returns 0`` () =
    let input = seq {
        yield "12"
    }

    let actual = countWindowIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``Two elements returns 0`` () =
    let input = seq {
        yield "12"
        yield "14"
    }

    let actual = countWindowIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``Three elements returns 0`` () =
    let input = seq {
        yield "12"
        yield "14"
        yield "13"
    }

    let actual = countWindowIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``Four elements returns 1`` () =
    let input = seq {
        yield "12"
        yield "14"
        yield "13"
        yield "15"
    }

    let actual = countWindowIncrements(input)
    Assert.Equal(1, actual)

[<Fact>]
let ``Sample returns 5`` () =
    let input = seq {
        yield "199"
        yield "200"
        yield "208"
        yield "210"
        yield "200"
        yield "207"
        yield "240"
        yield "269"
        yield "260"
        yield "263"
    }

    let actual = countWindowIncrements(input)
    Assert.Equal(5, actual)