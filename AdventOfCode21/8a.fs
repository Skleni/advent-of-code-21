module AOC8a

open System
open System.IO

type Display = { Patterns: string list; Outputs: string list }

let parsePatterns(patterns: string) = 
    patterns.Split(' ') |>
    List.ofArray

let parseLine (line: string) =
    let parts = line.Split('|')
    { Patterns = parsePatterns parts[0]; Outputs = parsePatterns parts[1] }

let parseLines lines = 
    lines |>
    List.map parseLine

let countUnique (displays: Display list) =
    displays |>
    List.map(fun d -> d.Outputs) |>
    List.concat |>
    List.sumBy(fun o -> match o.Length with
                        | 2 | 3 | 4 | 7 -> 1
                        | _ -> 0)

let aoc =
    let lines = File.ReadLines("8.txt") |> List.ofSeq
    let displays = parseLines lines
    let count = countUnique displays

    printfn "%i" count