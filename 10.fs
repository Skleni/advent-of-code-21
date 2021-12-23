module AOC10

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

    let getRange a b =
        [min a b..max a b]

    let getDiagonalCoordinates x1 y1 x2 y2 =
        let rangeX = getRange x1 x2
        let rangeY = getRange y1 y2
        let x = if x1 > x2 then List.rev rangeX else rangeX 
        let y = if y1 > y2 then List.rev rangeY else rangeY
        List.zip x y

    let getCoordinates line =
        match line with
        | ((x1, y1), (x2, y2)) when x1 = x2 -> getRange y1 y2 |> List.map(fun y -> (x1, y))
        | ((x1, y1), (x2, y2)) when y1 = y2 -> getRange x1 x2 |> List.map(fun x -> (x, y1))
        | ((x1, y1), (x2, y2)) -> getDiagonalCoordinates x1 y1 x2 y2
    
    let overlaps = lines |>
                   List.map parseLine |>
                   List.map getCoordinates |>
                   List.concat |>
                   List.groupBy(fun c -> c) |>
                   List.filter(fun (key, coordinates) -> coordinates.Length > 1) |>
                   List.length

    overlaps

let aoc =
    let lines = List.ofSeq(File.ReadLines("9.txt"))
    let overlaps = countOverlaps lines
    printfn "%i" overlaps