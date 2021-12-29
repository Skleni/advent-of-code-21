module AOC2b
open System
open System.IO
open System.Collections.Generic

let handle (hor, depth, aim) (command, i) =
    match command with
        | "forward" -> (hor + i, depth + aim * i, aim)
        | "down" -> (hor, depth, aim + i)
        | "up" -> (hor, depth, aim - i)
        | _ -> (hor, depth, aim)

let calcPosition (lines: IEnumerable<string>) =
    lines |>
    List.ofSeq |>
    List.map(fun l -> l.Split(' ')) |>
    List.map(fun a -> (a[0], Int32.Parse(a[1]))) |>
    List.fold handle (0, 0, 0)

let aoc =
    let (hor, depth, aim) =
        File.ReadLines("2.txt") |>
        calcPosition
   
    printfn "%i" (hor * depth)