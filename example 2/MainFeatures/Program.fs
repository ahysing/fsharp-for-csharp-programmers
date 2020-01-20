// Learn more about F# at http://fsharp.org

open System

let rec printNumbers (i:int32, limit:int32) =
    if i < limit then
        printf " %d" i
        let next = i + 1
        printNumbers(next, limit)
    else
        () // this last statement is the return type. () means void in C#

[<EntryPoint>]
let main argv = 
    printfn "This program demonstrates the key features over Object Oriented Programming; Higher order functions and immutability"
    
    let x = 10
    printfn "In F# all variables are immutable. They are set on creation, and can never change again."

    let mutable y = 5
    y <- 2
    printfn "You can still change a value after a variable is declared, but you have to explicitly ask for it."
    printfn "For the record. Variable y=%d\n" 2

    
    printfn ""
    printfn ""
    printfn ""
    
    printfn "When changing variables is bad behavior. In F# we use functions to achieve loops"
   
    let start = 1
    let limit = 10
    printfn "printNumbers(%d, %d) prints the numbers:" start limit
    printNumbers(start, limit) |> ignore    
    0 // return an integer exit coden
