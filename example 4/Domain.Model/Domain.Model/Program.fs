module Program
open Person
open Customer

[<EntryPoint>]
let main argv =

    let person = Person("John", "Doe")

    // record Customer is assigned in a "record expression".
    let customer = { Id="ID"; Name="NAME"; }


    // The labels of the most recently declared type take precedence over
    // those of the previously declared type, so in the preceding example,
    // mypoint3D is inferred to be Point3D. You can explicitly specify the
    // record type, as in the following code.
    let customerExplicit = { Customer.Id="ID"; Customer.Name="NAME"; }
    printfn "Hello World from F#!"
    0 // return an integer exit code
    