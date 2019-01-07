module RnaTranscription

open System

let toRna (dna: string): string =
    let transcribe = function
    | 'G' -> 'C'
    | 'C' -> 'G'
    | 'T' -> 'A'
    | 'A' -> 'U'
    | _ -> Char.MinValue

    dna |> Seq.map transcribe |> String.Concat