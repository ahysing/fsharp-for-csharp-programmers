module Person

open System

type Person(firstName:String, lastName:String) =
    member this.FirstName = firstName
    member this.LastName = lastName