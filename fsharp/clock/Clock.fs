module Clock

type Clock =
    {
        Hour: int
        Minute: int
    }

let convertToTotalMinutes hours minutes = (hours * 60) + minutes

let toAnalogHour minute = minute / 60 % 24

let toAnalogMinute minute = minute % 60

let convertToAnalog timePeriodInMinutes toAnalogTimePeriod totalMinutes =
    let analogMinutes = abs totalMinutes % timePeriodInMinutes
    if totalMinutes < 0 then
        timePeriodInMinutes - analogMinutes |> toAnalogTimePeriod 
    else
        analogMinutes |> toAnalogTimePeriod
    
let convertToAnalogClock totalMinutes =
    {
        Hour = totalMinutes |> convertToAnalog 1440 toAnalogHour
        Minute = totalMinutes |> convertToAnalog 60 toAnalogMinute
    }

let create hours minutes =
    convertToTotalMinutes hours minutes
    |> convertToAnalogClock

let add minutes clock =
    convertToTotalMinutes clock.Hour clock.Minute + minutes
    |> convertToAnalogClock 

let subtract minutes clock = add -minutes clock

let display clock = sprintf "%02i:%02i" clock.Hour clock.Minute
