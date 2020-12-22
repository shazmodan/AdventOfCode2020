open System.Text.RegularExpressions

// let input = [
//     "1-3 a: abcde"
//     "1-3 b: cdefg"
//     "2-9 c: ccccccccc"
// ]

let input =
    System.IO.File.ReadLines("2.txt")
    |> Seq.toList

let inputToQuadruple (input: string list) : (int * int * char * string) list =
    let interpretRow (row: string) =
        (row, "(\d\d?)-(\d\d?)\s([a-z]):\s(.*)")
        |> Regex.Match
        |> (fun regexMatch ->
            if regexMatch.Success
            then
                let min = regexMatch.Groups.[1].Value |> int
                let max = regexMatch.Groups.[2].Value |> int
                let char = regexMatch.Groups.[3].Value |> char
                let password = regexMatch.Groups.[4].Value
                min, max, char, password
            else failwith "Could not regexMatch correctly.")
    
    List.map interpretRow input

let isValidPassword (min: int) (max: int) (char: char) (password: string) : bool =
    let occurances = 
        password
        |> String.filter (fun s -> s = char)
        |> String.length
    
    occurances >= min && occurances <= max

let isValidPosition (min: int) (max: int) (char: char) (password: string) : bool =
    (password.[min-1] = char) <> (password.[max-1] = char)


input
|> inputToQuadruple
|> List.map (fun (min, max, char, password) -> isValidPassword min max char password)
|> List.filter id
|> List.length

input
|> inputToQuadruple
|> List.map (fun (min, max, char, password) -> isValidPosition min max char password)
|> List.filter id
|> List.length