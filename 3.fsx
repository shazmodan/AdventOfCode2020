// let input : string array = [|
// "..##.........##.........##.........##.........##.........##......."
// "#...#...#..#...#...#..#...#...#..#...#...#..#...#...#..#...#...#.."
// ".#....#..#..#....#..#..#....#..#..#....#..#..#....#..#..#....#..#."
// "..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#..#.#...#.#"
// ".#...##..#..#...##..#..#...##..#..#...##..#..#...##..#..#...##..#."
// "..#.##.......#.##.......#.##.......#.##.......#.##.......#.##....."
// ".#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#.#.#.#....#"
// ".#........#.#........#.#........#.#........#.#........#.#........#"
// "#.##...#...#.##...#...#.##...#...#.##...#...#.##...#...#.##...#..."
// "#...##....##...##....##...##....##...##....##...##....##...##....#"
// ".#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#.#..#...#.#"
// |]


let input : string array =
    System.IO.File.ReadLines("3.txt")
    |> Seq.toArray

// Starting at the top-left corner of your map and following a slope of right 3 and down 1, 
// how many trees would you encounter?
let rec makeMove (map: string array) (right: int) (down: int) (currentPos: int * int) (numberOfTrees: int) : int =
    let (currentRight, currentDown) = currentPos
    let newDown = currentDown + down
    let newRight = (currentRight + right) % (map.[currentDown].Length)
    
    if newDown >= map.Length
    then numberOfTrees
    else 
        let currentRow = map.[newDown]
        let currentChar = currentRow.[newRight]
        let newNumberOfTrees = 
            if currentChar = '#'
            then numberOfTrees + 1
            else numberOfTrees
        
        makeMove map right down (newRight, newDown) newNumberOfTrees

//makeMove input 3 1 (0,0) 0

// Right 1, down 1.
// Right 3, down 1. (This is the slope you already checked.)
// Right 5, down 1.
// Right 7, down 1.
// Right 1, down 2.

let r1d1 = makeMove input 1 1 (0,0) 0
let r3d1 = makeMove input 3 1 (0,0) 0
let r5d1 = makeMove input 5 1 (0,0) 0
let r7d1 = makeMove input 7 1 (0,0) 0
let r1d2 = makeMove input 1 2 (0,0) 0

let result = 
    [r1d1; r3d1; r5d1; r7d1; r1d2]
    |> List.map int64
    |> List.reduce (*)


