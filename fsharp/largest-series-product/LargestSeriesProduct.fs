module LargestSeriesProduct

open System

let largestProduct input seriesLength : int option =
    match seriesLength with
    | 0 -> Some 1
    | len when len > Seq.length input || len < 0 -> None
    | _ when input |> Seq.forall Char.IsDigit ->
        input
        |> Seq.map Globalization.CharUnicodeInfo.GetDigitValue
        |> Seq.windowed seriesLength
        |> Seq.map (Seq.reduce (*))
        |> Seq.max
        |> Some
    | _ -> None