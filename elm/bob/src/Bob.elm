module Bob exposing (hey)

fallbackResponse : String
fallbackResponse = "Whatever."

yellResponse : String
yellResponse = "Whoa, chill out!"

questionResponse : String
questionResponse = "Sure."

shoutingQuestionResponse : String
shoutingQuestionResponse = "Calm down, I know what I'm doing!"

silenceResponse : String
silenceResponse = "Fine. Be that way!"

areAllLettersUppercase : String -> Bool
areAllLettersUppercase input =
    -- idea:
    -- string -> array of chars
    -- map over array -> extract all ascii letters (uppercase and lowercase) and create new array; this ensures that all whitespace, non-ascii, and signs are excluded
    -- are all entries uppercase?
    input
    |> String.toList
    |> List.filter Char.isAlpha
    |> List.all Char.isUpper

areAllWordsAcronyms : String -> Bool
areAllWordsAcronyms input =
    False

isShouting : String -> Bool
isShouting input =
     if areAllLettersUppercase input then
        not <| areAllWordsAcronyms input
     else
        False

isQuestion : String -> Bool
isQuestion input =
    input |> String.endsWith "?"

isShoutingQuestion : String -> Bool
isShoutingQuestion input =
    isShouting input && isQuestion input

containsLetters : String -> Bool
containsLetters input =
    input |> String.toList |> List.any Char.isAlpha

isSilence : String -> Bool
isSilence input =
    input 
    |> String.words 
    |> String.concat 
    |> String.isEmpty

hey : String -> String
hey rawRemark =
    let remark = rawRemark |> String.trim
    in
    if containsLetters remark then
        if isShoutingQuestion remark then shoutingQuestionResponse
        else if isShouting remark then yellResponse
        else if isQuestion remark then questionResponse
        else fallbackResponse
    else if isSilence remark then
        silenceResponse
    else
        if isQuestion remark then questionResponse
        else fallbackResponse
