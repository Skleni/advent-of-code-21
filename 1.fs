module AOC1
open System
open System.IO

let aoc1 = 
    let handle (prev, count) curr =
        if curr > prev
        then (curr, count + 1)
        else (curr, count)

    let countIncrements lines =
        let (_, count) = 
            lines |>
            List.ofSeq |>
            List.map Int32.Parse |>
            List.fold handle (Int32.MaxValue, 0)
        count

    let count =
        File.ReadLines("1.txt") |>
        countIncrements
   
    printfn "%i" count