// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open FSharp.Data
open System

type Stocks = CsvProvider<"
Date,Open,High,Low,Close,Volume,Adj Close
2012-01-27,29.45,29.53,29.17,29.23,44187700,29.23
2012-01-26,29.61,29.70,29.40,29.50,49102800,29.50
2012-01-25,29.07,29.65,29.07,29.56,59231700,29.56
2012-01-24,29.47,29.57,29.18,29.34,51703300,29.34
">

type MSFT = CsvProvider<"http://www.google.com/finance/historical?q=MSFT&output=csv">

[<EntryPoint>]
let main _ = 

    // Get hardcoded sample
    printfn "#### Hardcoded sample ####"
    printfn "--------------------------"

    let sample = Stocks.GetSample()

    for row in sample.Rows do
        printfn "(date, open, close): %A, %A, %A" row.Date row.Open row.Close

    // Get data from Google
    let msft = MSFT.GetSample()

    printfn "\n#### MSFT (live from Google) ####"
    printfn "----------------------------------"

    for row in msft.Take(10).Rows do
        printfn "(date, open, close): %A, %A, %A" row.Date row.Open row.Close

    Console.ReadLine() |> ignore
    0 // return an integer exit code
