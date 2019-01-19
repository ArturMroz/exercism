module Yacht

type Category = 
    | Ones
    | Twos
    | Threes
    | Fours
    | Fives
    | Sixes
    | FullHouse
    | FourOfAKind
    | LittleStraight
    | BigStraight
    | Choice
    | Yacht

type Die =
    | One = 1
    | Two = 2 
    | Three = 3 
    | Four = 4
    | Five = 5
    | Six = 6

let score category dice =
    let dice' = dice |> List.map int
    let counted = dice' |> List.countBy id |> List.sortByDescending snd 
    let sumOfDice diceValue = dice |> List.filter ((=) diceValue) |> List.sumBy int

    match category with
    | Ones ->   sumOfDice Die.One
    | Twos ->   sumOfDice Die.Two
    | Threes -> sumOfDice Die.Three
    | Fours ->  sumOfDice Die.Four
    | Fives ->  sumOfDice Die.Five
    | Sixes ->  sumOfDice Die.Six
    | FullHouse when counted.Length > 1 && snd counted.[0] = 3 && snd counted.[1] = 2 -> List.sum dice'
    | FourOfAKind when snd counted.[0] >= 4 -> fst counted.[0] * 4
    | LittleStraight when List.sort dice' = [1..5] -> 30
    | BigStraight when List.sort dice' = [2..6] -> 30
    | Choice -> List.sum dice'
    | Yacht when counted.Length = 1 && snd counted.[0] = 5 -> 50
    | _ -> 0