module AOC17

open System
open System.IO

let buildArray (lines: string seq) =
    let arrays =
        lines |>
        Seq.map(fun l -> Seq.toArray(Seq.map(fun c -> int(c) - int('0')) l)) |>
        Seq.toArray

    Array2D.init arrays.Length arrays[0].Length (fun i j -> arrays[i][j])

let getNeighbors (array: int[,]) c =
    let (row, column) = c
    seq {
        if column > 0 then
            yield array[row, column - 1]
        if row > 0 then
            yield array[row - 1, column]
        if row < array.GetLength(0) - 1 then
            yield array[row + 1, column]
        if (column < array.GetLength(1) - 1) then
            yield array[row, column + 1]
    }

let at (array: int[,]) c =
    let (x,y) = c
    array[x, y]

let isLowPoint (array: int[,]) c =
    let p = at array c
    getNeighbors array c |>
    Seq.forall(fun v -> v > p)

let sumRiskLevels (array: int[,]) =
    let coordinates = [0..array.GetLength(0) - 1] |>
                      List.map(fun x -> [0..array.GetLength(1) - 1] |> List.map(fun y -> (x, y))) |>
                      List.concat
    coordinates |>
    List.filter(fun c -> isLowPoint array c) |>
    List.sumBy(fun c -> 1 + (at array c))

let aoc =
    let array = buildArray(File.ReadLines("17.txt"))    
    let sum = sumRiskLevels array
    printfn "%i" sum