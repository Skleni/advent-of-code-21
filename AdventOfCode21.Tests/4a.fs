module AOC4a.Tests

open Xunit
open AOC4a

[<Fact>]
let ``Sample returns 4512`` () =
    let input = seq {
       yield "7,4,9,5,11,17,23,2,0,14,21,24,10,16,13,6,15,25,12,22,18,20,8,19,3,26,1"
       yield ""
       yield "22 13 17 11  0"
       yield " 8  2 23  4 24"
       yield "21  9 14 16  7"
       yield " 6 10  3 18  5"
       yield " 1 12 20 15 19"
       yield ""
       yield " 3 15  0  2 22"
       yield " 9 18 13 17  5"
       yield "19  8  7 25 23"
       yield "20 11 10 24  4"
       yield "14 21 16 12  6"
       yield ""
       yield "14 21 17 24  4"
       yield "10 16 15  9 19"
       yield "18  8 23 26 20"
       yield "22 11 13  6  5"
       yield " 2  0 12  3  7"
    }

    let score = calcWinnerScore(List.ofSeq(input))
    Assert.Equal(4512, score)