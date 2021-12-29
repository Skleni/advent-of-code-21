module AOC9b

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
            yield (row, column - 1)
        if row > 0 then
            yield (row - 1, column)
        if row < array.GetLength(0) - 1 then
            yield (row + 1, column)
        if (column < array.GetLength(1) - 1) then
            yield (row, column + 1)
    }

let at (array: int[,]) c =
    let (x,y) = c
    array[x, y]

let isLowPoint (array: int[,]) c =
    let p = at array c
    getNeighbors array c |>
    Seq.forall(fun n -> at array n > p) 

let getBasin (array: int[,]) lowPoint =
    let rec getBasinRec (basin: (int * int) list) (coordinates: (int * int) list) =
        let newCoordinates = coordinates |>
                             List.filter(fun c -> at array c < 9 && not (List.contains c basin))

        if newCoordinates.IsEmpty then
            basin
        else
            let newBasin = List.append basin newCoordinates
            let newNeighbors = newCoordinates |>
                               List.map(fun c -> getNeighbors array c) |>
                               Seq.concat |>
                               Seq.distinct |>
                               Seq.toList
            getBasinRec newBasin newNeighbors
        
    let neighbors = getNeighbors array lowPoint |> Seq.toList
    getBasinRec [lowPoint] neighbors

let findBasins (array: int[,]) =
    let lowPoints = [0..array.GetLength(0) - 1] |>
                    List.map(fun x -> [0..array.GetLength(1) - 1] |> List.map(fun y -> (x, y))) |>
                    List.concat |>
                    List.filter(fun c -> isLowPoint array c) 

    lowPoints |>
    List.map(fun c -> getBasin array c)

let findLargestBasins (array: int[,]) n =
    findBasins array |>
    List.sortByDescending(fun b -> b.Length) |>
    List.take n

let getResult (array: int[,]) =
    findLargestBasins array 3 |>
    List.map(fun b -> b.Length) |>
    List.fold(*) 1

let aoc =
    let array = buildArray(File.ReadLines("9.txt"))
    let result = getResult array
    printfn "%i" result