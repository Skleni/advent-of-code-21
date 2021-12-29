module AOC7a

open System
open System.IO

let parsePositions (line: string) =
    line.Split(',') |>
    List.ofArray |>
    List.map Int32.Parse

let calculateFuel positions position =
    positions |>
    List.sumBy(fun p -> abs(position - p))

let calculatePositionWithLeastAmountOfFuel positions =
    let min = List.min positions
    let max = List.max positions
    
    [min..max] |>
    List.minBy(calculateFuel positions)

let aoc =
    let line = File.ReadAllText("7.txt")
    let positions = parsePositions line
    let position = calculatePositionWithLeastAmountOfFuel positions
    let fuel = calculateFuel positions position
    printfn "%i" fuel