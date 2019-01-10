module ArmstrongNumbers

let isArmstrongNumber (number: int): bool =
    let digits = 
        number 
        |> Array.unfold (function 
            | 0 -> None 
            | x -> Some (x % 10, x / 10))

    let n = Seq.length digits

    digits 
    |> Array.sumBy (fun x -> pown x n) 
    |> (=) number