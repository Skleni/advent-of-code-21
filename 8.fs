module AOC8

open System
open System.IO

type Field = { Number: int; Marked: bool }

type Board = { Rows: Field list list } with
    member this.Columns =
        List.transpose(this.Rows)

let calcWinnerScore (lines: string list) =
    let parseLine (line: string) = line.Split([|' '; ','|], StringSplitOptions.RemoveEmptyEntries) |>
                                   List.ofArray |>
                                   List.map(Int32.Parse)
    
    let parseBoard lines =
        let rows = lines |>
                   List.skip 1 |>
                   List.map parseLine |>
                   List.map (fun numbers -> numbers |> List.map(fun n -> { Number = n; Marked = false }))
        { Rows = rows }

    let randomNumbers = parseLine lines.Head
    
    let boards = lines.Tail |>
                 List.chunkBySize(6) |>
                 List.map parseBoard 

    let allMarked fields =
        fields |>
        List.forall(fun f -> f.Marked) 
        
    let hasWon board =
        List.exists allMarked board.Rows ||
        List.exists allMarked board.Columns 
    
    let markBoard board number =
        let rows = board.Rows |>
                   List.map(fun row -> row |> List.map(fun f -> if f.Number = number
                                                                then { f with Marked = true }
                                                                else f))
        { Rows = rows}

    let markBoards boards number = 
        boards |>
        List.map(fun b -> markBoard b number)

    let score board = 
        board.Rows |>
        List.concat |>
        List.filter(fun f -> not f.Marked) |>
        List.sumBy(fun f -> f.Number)

    let rec draw boards (randomNumbers: int list) =
        let newBoards = markBoards boards randomNumbers.Head
        let remainingBoards = newBoards |>
                              List.filter(fun b -> not(hasWon(b)))
        if remainingBoards.IsEmpty
        then score newBoards.Head * randomNumbers.Head
        else draw remainingBoards randomNumbers.Tail

    draw boards randomNumbers

let aoc =
    let lines = List.ofSeq(File.ReadLines("7.txt"))
    let score = calcWinnerScore lines
    printfn "%i" score