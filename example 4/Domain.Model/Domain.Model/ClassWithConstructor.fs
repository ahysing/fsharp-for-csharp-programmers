module ClassWithConstructor

type ClassWithConstructor(seed) =   
    let privateValue = seed + 1
    
    // some code to be done at construction time
    do printfn "hello world"

    // must come BEFORE the do block that calls it
    let printPrivateValue() = 
        do printfn "the privateValue is now %i" privateValue 

    // more code to be done at construction time
    do printPrivateValue()
