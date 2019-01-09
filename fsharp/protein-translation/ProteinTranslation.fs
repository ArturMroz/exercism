module ProteinTranslation

open System

let proteins (rna: string): string list =
    let translate = function
    | "AUG"                         -> Some "Methionine"
    | "UUU" | "UUC"                 -> Some "Phenylalanine"
    | "UUA" | "UUG"                 -> Some "Leucine"
    | "UCU" | "UCC" | "UCA" | "UCG" -> Some "Serine"
    | "UAU" | "UAC"                 -> Some "Tyrosine"
    | "UGU" | "UGC"                 -> Some "Cysteine"
    | "UGG"                         -> Some "Tryptophan"
    | "UAA" | "UAG" | "UGA"         -> None
    | _                             -> None

    let codons = rna |> Seq.chunkBySize 3 |> Seq.map String

    codons
    |> Seq.map translate
    |> Seq.takeWhile ((<>) None)
    |> Seq.choose id
    |> Seq.toList