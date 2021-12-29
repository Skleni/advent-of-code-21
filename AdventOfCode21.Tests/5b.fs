module AOC5b.Tests

open Xunit
open AOC5b

[<Fact>]
let ``Sample returns 12`` () =
    let input = seq {
       yield "0,9 -> 5,9"
       yield "8,0 -> 0,8"
       yield "9,4 -> 3,4"
       yield "2,2 -> 2,1"
       yield "7,0 -> 7,4"
       yield "6,4 -> 2,0"
       yield "0,9 -> 2,9"
       yield "3,4 -> 1,4"
       yield "0,0 -> 8,8"
       yield "5,5 -> 8,2"
    }

    let overlaps = countOverlaps(List.ofSeq(input))
    Assert.Equal(12, overlaps)