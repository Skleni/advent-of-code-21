module AOC5a

open System
open System.IO

let countOverlaps (lines: string list) =
    let parsePoint (coordinates: string) =
        let array = coordinates.Split(',')
        (Int32.Parse(array[0]), Int32.Parse(array[1]))

    let parseLine (line: string) =
        let points = line.Split([|' '; '-'; '>';|], StringSplitOptions.RemoveEmptyEntries) |>
                     Array.map parsePoint
        (points[0], points[1])

    let getCoordinates line =
        match line with
        | ((x1, y1), (x2, y2)) when x1 = x2 -> [min y1 y2..max y1 y2] |> List.map(fun y -> (x1, y))
        | ((x1, y1), (x2, y2)) when y1 = y2 -> [min x1 x2..max x1 x2] |> List.map(fun x -> (x, y1))
        | _ -> List.empty
    
    let overlaps = lines |>
                   List.map parseLine |>
                   List.map getCoordinates |>
                   List.concat |>
                   List.groupBy(fun c -> c) |>
                   List.filter(fun (key, coordinates) -> coordinates.Length > 1) |>
                   List.length

    overlaps

let aoc =
    let lines = List.ofSeq(File.ReadLines("5.txt"))
    let overlaps = countOverlaps lines
    printfn "%i" overlaps