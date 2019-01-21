module ParallelLetterFrequency

let frequency texts =
    let frequencyAsync (text: string) =
        async {
            return text.ToLower()
            |> Seq.filter System.Char.IsLetter
            |> Seq.countBy id
        }

    texts
    |> List.map frequencyAsync
    |> Async.Parallel
    |> Async.RunSynchronously
    |> Seq.concat
    |> Seq.groupBy fst
    |> Seq.map (fun (letter, occurences) -> letter, occurences |> Seq.sumBy snd)
    |> Map.ofSeq
