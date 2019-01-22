module NucleotideCount

let nucleotideCounts (strand : string) : Option<Map<char, int>> =
    let nucleotides = [| 'A'; 'C'; 'G'; 'T' |]

    if strand |> Seq.exists (fun ch -> not <| Array.contains ch nucleotides) then
        None
    else
        nucleotides
        |> Array.map (fun ch -> ch, strand |> Seq.filter ((=) ch) |> Seq.length)
        |> Map.ofArray
        |> Some
