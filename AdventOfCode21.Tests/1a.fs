module AOC1a.Tests

open System
open Xunit
open AOC1a

[<Fact>]
let ``Empty sequences returns 0`` () =
    let input = Seq.empty
    let actual = countIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``One element returns 0`` () =
    let input = seq {
        yield "12"
    }

    let actual = countIncrements(input)
    Assert.Equal(0, actual)

[<Fact>]
let ``Two increments`` () =
    let input = seq {
        yield "3"
        yield "4"
        yield "2"
        yield "1"
        yield "5"
        yield "5"
    }

    let actual = countIncrements(input)
    Assert.Equal(2, actual)

[<Fact>]
let ``Four increments`` () =
    let input = seq {
        yield "7"
        yield "3"
        yield "1"
        yield "2"
        yield "3"
        yield "3"
        yield "4"
        yield "2"
        yield "1"
        yield "8"
        yield "7"
    }

    let actual = countIncrements(input)
    Assert.Equal(4, actual)