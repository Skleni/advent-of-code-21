module AOC3b

open System.IO
open System.Collections.Generic

let fromBinary bits =
    bits |>
    List.fold(fun n bit -> (n <<< 1) ||| bit) 0 

let handle bits =
    if float (List.filter(fun bit -> bit = 1) bits).Length >= float bits.Length / 2.0 then 1 else 0
    
let calcRates (lines: IEnumerable<string>) =
    let lists =
        lines |>
        List.ofSeq |>
        List.map(List.ofSeq) |>
        List.map(fun number -> List.map(fun bit -> if bit = '0' then 0 else 1) number)
    
    let rec filter (lists: int list list) (useGamma: bool) (digit: int) =
        if lists.Length = 1
        then lists.Head
        else
            let columns =
                lists |>
                List.transpose

            let gamma = List.map handle columns
            let epsilon = List.map(fun bit -> if bit = 0 then 1 else 0) gamma
            let compareTo = if useGamma then gamma else epsilon
        
            let filteredList =
                lists |>
                List.filter(fun (number: int list) -> number.Item(digit) = compareTo.Item(digit))
                
            filter filteredList useGamma (digit + 1)

    (fromBinary(filter lists true 0), fromBinary(filter lists false 0))

let aoc =
    let (oxygenGenerator, o2Scrubber) = 
        File.ReadLines("3.txt") |>
        calcRates
   
    printfn "%i" (oxygenGenerator * o2Scrubber)