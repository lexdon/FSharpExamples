// http://fsprojects.github.io/FSharp.Data.SqlClient/

open FSharp.Data.SqlClient
open FSharp.Data
open System

let [<Literal>] connectionString = 
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\dev\dotnet\FSharpExamples\Databases\TestDatabase.mdf;
      Integrated Security=True;
      Connect Timeout=30"


type sql = SqlProgrammabilityProvider<connectionString> 

[<EntryPoint>]
let main argv = 

    do
        use cmd = new sql.dbo.GetCarsByModel(connectionString)
        for x in cmd.Execute("X") do
            printfn "%A" x

    Console.ReadLine() |> ignore
    0 // return an integer exit code
