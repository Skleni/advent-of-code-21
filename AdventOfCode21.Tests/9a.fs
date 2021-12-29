module AOC9a.Tests

open Xunit
open AOC9a

[<Fact>]
let ``Sample returns 15`` () =
    let input = seq {
       yield "2199943210"
       yield "3987894921"
       yield "9856789892"
       yield "8767896789"
       yield "9899965678"
    }

    let array = buildArray(input)
    let sum = sumRiskLevels array
    Assert.Equal(15, sum)