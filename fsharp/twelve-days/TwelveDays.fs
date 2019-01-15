module TwelveDays

let recite start stop =
    let gifts = [| 
        "a Partridge in a Pear Tree" 
        "two Turtle Doves";
        "three French Hens";
        "four Calling Birds";
        "five Gold Rings";
        "six Geese-a-Laying";
        "seven Swans-a-Swimming";
        "eight Maids-a-Milking";
        "nine Ladies Dancing";
        "ten Lords-a-Leaping";
        "eleven Pipers Piping";
        "twelve Drummers Drumming";
    |]

    let days = [| "first"; "second"; "third"; "fourth"; "fifth"; "sixth"; 
                  "seventh"; "eighth"; "ninth"; "tenth"; "eleventh"; "twelfth" |]

    let verse n = 
        let currGifts = gifts.[0..n - 1] 
        if n > 1 then currGifts.[0] <- "and " + currGifts.[0]
        let giftsStr = currGifts |> Array.rev |> String.concat ", "
        sprintf "On the %s day of Christmas my true love gave to me: %s." days.[n - 1] giftsStr

    [start..stop] |> List.map verse