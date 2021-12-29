module AOC7b.Tests

open Xunit
open AOC7b

[<Fact>]
let ``Sample returns 168`` () =
    let positions = parsePositions "16,1,2,0,4,2,7,1,2,14"
    let position = calculatePositionWithLeastAmountOfFuel positions
    let fuel = calculateFuel positions position

    Assert.Equal(168, fuel)