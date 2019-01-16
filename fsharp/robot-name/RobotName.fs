module RobotName

let rnd = System.Random()
let letters = [| 'A'..'Z' |]
let lettersLen = Array.length letters - 1

let nameGenerator() =
    let number = rnd.Next(999)
    let letter () = letters.[rnd.Next(lettersLen)]

    sprintf "%c%c%03i" (letter ()) (letter ()) number

let mkRobot() = nameGenerator()
let name robot = robot
let reset robot = nameGenerator()
