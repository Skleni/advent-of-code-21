module AOC12

open System
open System.IO
open System.Linq
open System.Collections.Generic

let parseFish (line: string) =
    line.Split(',') |>
    List.ofArray |>
    List.map Int32.Parse

/// The function creates a function that calls the argument 'f'
/// only once and stores the result in a mutable dictionary (cache)
/// Repeated calls to the resulting function return cached values.
let memoize f =    
  // Create (mutable) cache that is used for storing results of 
  // for function arguments that were already calculated.
  let cache = new Dictionary<_, _>()
  (fun x ->
      // The returned function first performs a cache lookup
      let succ, v = cache.TryGetValue(x)
      if succ then v else 
        // If value was not found, calculate & cache it
        let v = f(x) 
        cache.Add(x, v)
        v)

let rec descendants = memoize (fun(day) ->
    match day with
    | d when d <= 0 -> 1L
    | d when d > 0 && d <= 7 -> 2L
    | _ -> descendants(day - 7) + descendants(day - 9))

let descendantsAfter fish days = 
    descendants (days - fish)

let countFish fish days =
    fish |>
    List.map(fun f -> descendantsAfter f days) |>
    List.sum

let aoc =
    let fish = parseFish(File.ReadAllText("11.txt"))

    let count = countFish fish 256

    printfn "%i" count