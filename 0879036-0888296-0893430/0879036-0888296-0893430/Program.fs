let zin  beginStr mainStr =
    beginStr + ", " + mainStr

let sayHello = zin "Hello"

let names = ["piet"; "klaas"; "henk"]

let mark m =
    m + "!"

let volleZin = sayHello >> mark

names
|>Seq.map volleZin
|>Seq.sort
|>Seq.iter(printfn "%s")
