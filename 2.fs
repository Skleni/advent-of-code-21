module AOC2
open System
open System.IO

let handle (prevWindow, prevSum, count) curr =
    let currWindow = curr :: prevWindow |> List.truncate 3

    let currSum =
        match currWindow.Length with
            | 3 -> List.sum currWindow
            | _ -> Int32.MaxValue

    if currSum > prevSum
    then (currWindow, currSum, count + 1)
    else (currWindow, currSum, count)

let countWindowIncrements lines =
    let (_, _, count) = 
        lines |>
        List.ofSeq |>
        List.map Int32.Parse |>
        List.fold handle (List.empty, Int32.MaxValue, 0)
    count

let aoc =
    let count =
        File.ReadLines("1.txt") |>
        countWindowIncrements
   
    printfn "%i" count