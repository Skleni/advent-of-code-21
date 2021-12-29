module AOC9b.Tests

open Xunit
open AOC9b

[<Fact>]
let ``Sample returns 1134`` () =
    let input = seq {
       yield "2199943210"
       yield "3987894921"
       yield "9856789892"
       yield "8767896789"
       yield "9899965678"
    }

    let array = buildArray(input)
    let result = getResult array
    Assert.Equal(1134, result)