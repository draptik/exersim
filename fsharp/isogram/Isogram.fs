﻿module Isogram

open System
open System.Text.RegularExpressions

let isIsogramInternalV2 (str: string) =

    let toLetters (s: string) =
        s
        |> Seq.map Char.ToLowerInvariant
        |> Seq.filter Char.IsLetter

    let inputLength = str |> toLetters |> Seq.length 
    
    str
    |> toLetters
    |> Seq.sort
    |> Seq.distinct
    |> Seq.length = inputLength 
    
let isIsogramInternalV1 (str: string) =
    str
    |> Seq.map Char.ToLowerInvariant // map all strings to lowercase char array
    |> Seq.filter Char.IsLetter // we only care about letters
    |> Seq.toList
    |> List.groupBy id // group by identity (duplicates are grouped: "aba" -> [('a', ['a'; 'a']); ('b', ['b'])])
    |> List.map snd // we only care about duplicate entries (array within array): "aba" -> [['a'; 'a']; ['b']]
    |> List.filter (fun set -> set.Length > 1) // strip all non-duplicates: "aba" -> [['a'; 'a']]
    |> List.map (fun set -> set.[0]) // only take the first entry
    |> List.length = 0 // length > 0 means we have duplicates (not an isogram)

let isIsogram str =
    isIsogramInternalV2 str