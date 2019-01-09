module TwoFer

let twoFer (input: string option): string =
    let str = sprintf "One for %s, one for me."
    match input with
    | Some name -> str name
    | None -> str "you"