module Triangle

let (|IsNotValidTriangle|_|) ([a; b; c]: float list)=
    if a + b <= c || a + c <= b || b + c <= a then Some IsNotValidTriangle else None

let equilateral = function
    | IsNotValidTriangle -> false
    | [a; b; c] when a = b && b = c -> true
    | _ -> false

let isosceles = function
    | IsNotValidTriangle -> false
    | [a; b; c] when a = b || a = c || b = c -> true
    | _ -> false

let scalene = function
    | IsNotValidTriangle -> false
    | [a; b; c;] when a <> b && b <> c && c <> a -> true
    | _ -> false