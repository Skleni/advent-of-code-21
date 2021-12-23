module AOC11

open System
open System.IO

let parseFish (line: string) =
    line.Split(',') |>
    List.ofArray |>
    List.map Int32.Parse

let rec reproduce (fish: int list) days =
    if days = 0 then
        fish.Length
    else
        let intermediateFish = fish |> List.map(fun f -> f - 1)
        
        let newFish = intermediateFish |>
                      List.filter(fun f -> f < 0) |>
                      List.map(fun f -> 8)
        
        let updatedFish = intermediateFish |>
                          List.map(fun f -> if f < 0 then 6 else f)

        reproduce (updatedFish @ newFish) (days - 1)

let aoc =
    let fish = parseFish(File.ReadAllText("11.txt"))
    printfn "%i" (reproduce fish 80)