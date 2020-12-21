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
        |> fun tuples -> tuples @ pairs tail

let rec triples (numbers: int list) : (int * int * int) list =
    match numbers with
    | [] -> []
    | head :: tail ->
        pairs numbers
        |> List.map (fun (x, y) -> (head, x, y))
        |> fun threes -> threes @ triples tail

numbers
|> pairs
|> List.find (fun (a,b) -> a + b = 2020)
|> fun (a,b) -> a * b


numbers
|> triples
|> List.find (fun (a,b,c) -> a + b + c = 2020)
|> fun (a,b,c) -> a * b * c