// let numbers = 
//     [
//         1721
//         979
//         366
//         299
//         675
//         1456
//     ]

let numbers = 
    System.IO.File.ReadLines("1.txt")
    |> Seq.map (int)
    |> Seq.toList

let pairs (lst : 'a list) =
    match lst with
    | [] -> []
    | [x] -> []
    | xs ->
        xs
        |> List.splitAt (lst.Length / 2)
        |> fun (lst1, lst2) -> List.allPairs lst1 lst2


numbers
|> pairs
|> List.find (fun (a,b) -> a + b = 2020)
|> fun (a,b) -> a * b