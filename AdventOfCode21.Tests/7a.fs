module AOC7a.Tests

open Xunit
open AOC7a

[<Fact>]
let ``Sample returns 37`` () =
    let positions = parsePositions "16,1,2,0,4,2,7,1,2,14"
    let position = calculatePositionWithLeastAmountOfFuel positions
    let fuel = calculateFuel positions position

    Assert.Equal(37, fuel)