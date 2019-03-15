module DndCharacter

open System

let modifier x =
    (float (x - 10)) / 2.0
    |> Math.Floor
    |> int

let ability() =
    let rnd = Random()

    [ 1..4 ]
    |> List.map (fun _ -> rnd.Next(1, 7))
    |> List.sort
    |> List.skip 1
    |> List.sum

type DndCharacter() =
    member val Strength = ability()
    member val Dexterity = ability()
    member val Constitution = ability()
    member val Intelligence = ability()
    member val Wisdom = ability()
    member val Charisma = ability()
    member this.Hitpoints with get() = 10 + modifier(this.Constitution)