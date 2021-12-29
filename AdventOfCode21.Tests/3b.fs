module AOC3b.Tests

open Xunit
open AOC3b

[<Fact>]
let ``Sample returns (23, 10)`` () =
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

    let (ox, o2) = calcRates(input)
    Assert.Equal(23, ox)
    Assert.Equal(10, o2)