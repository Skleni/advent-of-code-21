module AOC5
open System.IO
open System.Collections.Generic

let fromBinary bits =
    bits |>
    List.fold(fun n bit -> (n <<< 1) ||| bit) 0 

let handle bits =
    if (List.filter(fun bit -> bit = '1') bits).Length > bits.Length / 2 then 1 else 0
    
let calcRates (lines: IEnumerable<string>) =
    let gamma = lines |>
                List.ofSeq |>
                List.map(List.ofSeq) |>
                List.transpose |>
                List.map(handle)

    let epsilon = List.map(fun bit -> if bit = 0 then 1 else 0) gamma

    (fromBinary gamma, fromBinary epsilon)

let aoc =
    let (g, e) = 
        File.ReadLines("5.txt") |>
        calcRates
   
    printfn "%i" (g * e)