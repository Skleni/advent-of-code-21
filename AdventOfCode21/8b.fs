module AOC8b

open System
open System.IO
open System.Linq

type Display = { Patterns: string list; Outputs: string list }

let parsePatterns(patterns: string) = 
    patterns.Split([|' '|], StringSplitOptions.RemoveEmptyEntries) |>
    List.ofArray |>
    List.map(fun p -> new String(p.OrderBy(fun c -> c).ToArray()))

let parseLine (line: string) =
    let parts = line.Split('|')
    { Patterns = parsePatterns parts[0]; Outputs = parsePatterns parts[1] }

let parseLines lines = 
    lines |>
    List.map parseLine

let deductPatterns (inputs: string list) =
    let one = inputs |> List.find(fun p -> p.Length = 2) 
    let seven = inputs |> List.find(fun p -> p.Length = 3)
    let four = inputs |> List.find(fun p -> p.Length = 4)
    let eight = inputs |> List.find(fun p -> p.Length = 7)
    let three = inputs |> List.find(fun p -> p.Length = 5 && one.All(fun l -> p.Contains(l)))
    let nine = inputs |> List.find(fun p -> p.Length = 6 && three.All(fun l -> p.Contains(l)))
    let topLeft = nine.Except(three).First()
    let five = inputs |> List.find(fun p -> p.Length = 5 && p.Contains(topLeft))
    let two = inputs |> List.find(fun p -> p.Length = 5 && p <> three && p <> five)
    let zero = inputs |> List.find(fun p -> p.Length = 6 && p <> nine && one.All(fun l -> p.Contains(l)))
    let six = inputs |> List.find(fun p -> p.Length = 6 && p <> nine && p <> zero)

    let mapping = seq {
        yield (zero, 0)
        yield (one, 1)
        yield (two, 2)
        yield (three, 3)
        yield (four, 4)
        yield (five, 5)
        yield (six, 6)
        yield (seven, 7)
        yield (eight, 8)
        yield (nine, 9)
    }

    dict mapping

let convertOutputs display = 
    let mapping = deductPatterns display.Patterns
    display.Outputs |>
    List.mapi(fun i o -> mapping.Item(o) * int(Math.Pow(10, float(display.Outputs.Length - 1 - i)))) |>
    List.sum

let aoc =
    let lines = File.ReadLines("8.txt") |> List.ofSeq
    let displays = parseLines lines
    let sum = displays |>
              List.map(convertOutputs) |>
              List.sum

    printfn "%i" sum