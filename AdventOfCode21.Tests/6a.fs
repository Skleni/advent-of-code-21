module AOC6a.Tests

open Xunit
open AOC6a

[<Fact>]
let ``5934 after 80 days`` () =
    let fish = parseFish "3,4,3,1,2"

    let count = reproduce fish 80
    Assert.Equal(5934, count)