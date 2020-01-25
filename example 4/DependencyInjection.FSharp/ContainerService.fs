module ContainerService
open System
open System.Collections.Generic

type InstanceOrError =
    | Instance of Object
    | NotRegistered

let private typeMapping = new Dictionary<Type, Object>()

let private lookupByGeneric<'I, 'IType> () =
    let typeOfI = typeof<'I>
    if typeMapping.ContainsKey(typeOfI) then
        let instanceAtRuntime = typeMapping.[typeOfI]
        (Instance instanceAtRuntime)
    else
        // Instead of throwing an exception we return a NotRegistered 
        NotRegistered


let registerInterface<'I, 'IType> (instance : 'IType) : (unit -> InstanceOrError) =
    let typeOfI = typeof<'I>
    typeMapping.[typeOfI] <- instance
    // Return the lookup function
    lookupByGeneric<'I, 'IType>

