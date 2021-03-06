﻿module Hamming

let distance (strand1: string) (strand2: string): int option =
    if String.length strand1 <> String.length strand2 then
        None
    else
        (strand1, strand2)
        ||> Seq.zip
        |> Seq.map (fun (a, b) -> a <> b)
        |> Seq.filter id
        |> Seq.length
        |> Some
        