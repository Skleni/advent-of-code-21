module AOC2a
open System
open System.IO
open System.Collections.Generic

let handle (hor, depth) (command, i) =
    match command with
        | "forward" -> (hor + i, depth)
        | "down" -> (hor, depth + i)
        | "up" -> (hor, depth - i)
        | _ -> (hor, depth)

let calcPosition (lines: IEnumerable<string>) =
    lines |>
    List.ofSeq |>
    List.map(fun l -> l.Split(' ')) |>
    List.map(fun a -> (a[0], Int32.Parse(a[1]))) |>
    List.fold handle (0, 0)

let aoc =
    let (hor, depth) =
        File.ReadLines("2.txt") |>
        calcPosition
   
    printfn "%i" (hor * depth)