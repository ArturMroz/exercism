module KindergartenGarden

type Plant = Grass | Clover | Radishes | Violets

let students = 
    [| "Alice"; "Bob"; "Charlie"; "David"; 
    "Eve"; "Fred"; "Ginny"; "Harriet"; 
    "Ileana"; "Joseph"; "Kincaid"; "Larry" |]

let charToPlant = function
    | 'G' -> Grass
    | 'C' -> Clover
    | 'R' -> Radishes
    | 'V' -> Violets
    | _ -> failwith "Some unknown abomination of a flower."

let plants (diagram: string) (student: string) =
    let ind = Array.findIndex ((=) student) students

    diagram.Split '\n'
    |> Seq.collect (Seq.skip (ind * 2) >> Seq.take 2)
    |> Seq.map charToPlant
    |> Seq.toList