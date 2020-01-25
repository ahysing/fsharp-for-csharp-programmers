open ContainerService

type Document = { Id:int32 }

type IProvider =
    abstract member Lookup: int32 -> Document
 
type Provider() =

    interface IProvider with
        member x.Lookup(documentId:int32) =
            let document = { Id=documentId }
            document


[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    let instance = Provider()

    let lookupFunction = registerInterface<IProvider, Provider>(instance)
    let result = lookupFunction()
    match result with
        | Instance instanceRightBack ->
            printfn "This list was registered %A is acutally the same as %A" instance instanceRightBack
        | NotRegistered _ ->
            printfn "List type is not registered!"
    0 // return an integer exit code
