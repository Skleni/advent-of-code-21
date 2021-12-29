module AOC2a.Tests

open System
open Xunit
open AOC2a

[<Fact>]
let ``Empty sequences returns (0, 0)`` () =
    let input = Seq.empty
    let (hor, depth) = calcPosition(input)
    Assert.Equal(0, hor)
    Assert.Equal(0, depth)

[<Fact>]
let ``Sample returns (15, 10)`` () =
    let input = seq {
        yield "forward 5"
        yield "down 5"
        yield "forward 8"
        yield "up 3"
        yield "down 8"
        yield "forward 2"
    }

    let (hor, depth) = calcPosition(input)
    Assert.Equal(15, hor)
    Assert.Equal(10, depth)