namespace InteropExample.FSharp

// Example 1: Classes and interfaces
type ILogin =
    abstract member IsValid: bool

type Login(id:int, username:string, password:string) =
    member this.Id = id
    member this.UserName = username
    member this.Password = password
    
    interface ILogin with
        member this.IsValid = 
            this.UserName = "admin" && this.Password = "1234"

type Calculator() =
    //member this.Add x y = x + y
    
    member this.CurriedAdd x y = x + y

    member this.TupleAdd(x, y) = x + y

// Example 2: Records
type Car = { brand: string; model: string }

module ModuleExample =
    // Example 3: Static properties in modules
    let staticGetterPropertyExample = 
        "This is an example of a property with a getter"
    
    let mutable staticGetterSetterPropertyExample = 
        "This is an example of a property with a getter and a setter"
    
    // Example 4: Functions in modules
    let times2 x = x * 2

    let times4 x = times2(times2(x))
    //let times4 x = x |> times2 |> times2
    //let times4 x = (times2 >> times2) x
    