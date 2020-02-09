// Learn more about F# at http://fsharp.org
// Bookshelf is now a type pointing to a function
//
// on the right hand side of =
// we have a function taking in a int32 and returning a list of int32
//
// Bookshelf is checked as compile time
// It serves as a replacement for an interface
type Bookshelf = int32 -> int32 list



let reserveBookshelf iterator capacity  = // (unit -> int32) -> int -> int32 list
    let ienumerableDocumentIds = seq {
        for _ in 0..capacity do
            let documentId = iterator()
            yield documentId
    }
    Seq.toList<int32> ienumerableDocumentIds


let createReserveBookshelf() =
    let fileName = "database.sqlite"    
    let connectionString = SQLite.setup fileName
    let getNextFromSQLite() =
        // connectionString is declared in factory().
        // we can pass getNextFromSQLite() on to other functions,
        // but the value of connectionString below is lives inside the scope of
        // createReserveBookshelf(). It is not garbage collected.
        //
        // This way of storing values inside functions is called clojure.
        SQLite.NextDocumentId(connectionString)

    // notice how the function below is missing parameter capacity
    (reserveBookshelf getNextFromSQLite)
    
[<EntryPoint>]
let main argv =
    printfn "Hello World from F#!"
    
    // this assignment proves that Bookshelf contract is met
    let bookshelfOnSQLite:Bookshelf = createReserveBookshelf()
    let documentIds = (bookshelfOnSQLite 10)

    printfn "These are the new Document-IDs we have just reserved"
    for documentId in documentIds do
        printf "%d " documentId
    printfn ""

    0 // return an integer exit code
