module AOC6b.Tests

open Xunit
open AOC6b

[<Theory>]
[<InlineData(5L, 1)>]
[<InlineData(6L, 2)>]
[<InlineData(7L, 3)>]
[<InlineData(9L, 4)>]
[<InlineData(10L, 5)>]
[<InlineData(10L, 8)>]
[<InlineData(11L, 9)>]
[<InlineData(12L, 10)>]
[<InlineData(15L, 11)>]
[<InlineData(17L, 12)>]
[<InlineData(19L, 13)>]
[<InlineData(20L, 14)>]
[<InlineData(20L, 15)>]
[<InlineData(21L, 16)>]
[<InlineData(22L, 17)>]
[<InlineData(26L, 18)>]
let ``x after y days`` expectedFish days =
    let fish = parseFish "3,4,3,1,2"

    let count = countFish fish days

    Assert.Equal(expectedFish, count)

[<Fact>]
let ``26984457539 after 256 days`` () =
    let fish = parseFish "3,4,3,1,2"

    let count = countFish fish 256

    Assert.Equal(26984457539L, count)