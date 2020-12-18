let numbers = 
    System.IO.File.ReadLines("1.txt")
    |> Seq.map (int)
    |> Seq.toList

let rec pairs (numbers: int list) : (int * int) list =
    match numbers with
    | [] -> []
    | head :: tail ->
        tail 
        |> List.map (fun number -> (head, number))
        |> (fun tuples -> tuples @ pairs tail)


numbers
|> pairs
|> List.find (fun (a,b) -> a + b = 2020)
|> fun (a,b) -> a * b