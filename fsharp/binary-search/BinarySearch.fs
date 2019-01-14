module BinarySearch

let find input value: int option =
    let rec search input value start stop =
        if start > stop then 
            None 
        else
            let middle = (start + stop) / 2
            match input |> Array.item middle with
            | el when value > el -> search input value (middle + 1) stop
            | el when value < el -> search input value start (middle - 1)
            | _ -> Some middle

    search input value 0 (Array.length input - 1)