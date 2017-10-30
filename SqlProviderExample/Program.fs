// Comparison of different SQL type providers:
// http://fsprojects.github.io/FSharp.Data.SqlClient/comparison.html

open System
open FSharp.Data.Sql

let [<Literal>] connectionString = 
    @"Data Source=(LocalDB)\MSSQLLocalDB;
      AttachDbFilename=C:\dev\dotnet\FSharpExamples\Databases\TestDatabase.mdf;
      Integrated Security=True;
      Connect Timeout=30"

type sql = SqlDataProvider<
            DatabaseVendor = Common.DatabaseProviderTypes.MSSQLSERVER,
            ConnectionString = connectionString,
            IndividualsAmount = 1000,
            UseOptionTypes = true>

[<EntryPoint>]
let main _ = 

    let ctx = sql.GetDataContext()

    let cars = ctx.Dbo.Cars

    // "Truncate" table
    query {
        for car in cars do
            where (true)
    } 
    |> Seq.``delete all items from single table`` 
    |> Async.RunSynchronously
    |> ignore

    // Insert some cars
    let teslaS = cars.Create("Tesla", "S")
    let tesla3 = cars.Create("Tesla", "3")
    let teslaX = cars.Create("Tesla", "X")

    ctx.SubmitUpdates()

    // Get all cars
    printfn "Get all cars"
    printfn "------------"

    let allCars = ctx.Dbo.Cars |> Seq.toArray

    for car in allCars do
        printfn "%A %A %A" car.Id car.Brand car.Model

    // Get all cars with model name "X"
    printfn "\nGet all cars with model name \"X\""
    printfn "--------------------------------"

    let carQuery = 
        query {
            for car in cars do
                where (car.Model = "X")
                select car
        }

    let queryResult = carQuery |> Seq.toArray

    for car in queryResult do
        printfn "%A %A %A" car.Id car.Brand car.Model

    // Call stored procedure (kinda ugly)
    printfn "\nCall stored procedure"
    printfn "---------------------"

    let result = ctx.Procedures.GetCarsByModel.Invoke "X"

    result.ResultSet 
    |> Array.map(fun x -> x.ColumnValues |> Map.ofSeq)
    |> Array.iter(fun i ->
        printfn "%A %A %A" i.["Id"] i.["Brand"] i.["Model"]
    )

    // Wait for user input before closing the command prompt
    Console.ReadLine() |> ignore
    0 // return an integer exit code
