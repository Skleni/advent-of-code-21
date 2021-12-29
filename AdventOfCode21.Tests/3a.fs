module AOC3a.Tests

open System
open Xunit
open AOC3a

[<Fact>]
let ``Empty sequences returns (0, 0)`` () =
    let input = Seq.empty
    let (g, e) = calcRates(input)
    Assert.Equal(0, g)
    Assert.Equal(0, e)

[<Fact>]
let ``(0, 1, 1) returns (1, 0)`` () =
    let input = seq {
        yield "0"
        yield "1"
        yield "1"
    }
    let (g, e) = calcRates(input)
    Assert.Equal(1, g)
    Assert.Equal(0, e)

[<Fact>]
let ``Sample returns (22, 9)`` () =
    let input = seq {
        yield "00100"
        yield "11110"
        yield "10110"
        yield "10111"
        yield "10101"
        yield "01111"
        yield "00111"
        yield "11100"
        yield "10000"
        yield "11001"
        yield "00010"
        yield "01010"
    }

    let (g, e) = calcRates(input)
    Assert.Equal(22, g)
    Assert.Equal(9, e)