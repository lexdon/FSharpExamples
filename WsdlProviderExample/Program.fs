// Learn more about F# at http://fsharp.org
// See the 'F# Tutorial' project for more help.

open System
open FSharp.Data.TypeProviders

type calculatorService = WsdlService<"http://www.dneonline.com/calculator.asmx?wsdl">

type helloService = WsdlService<"http://localhost:8080/hello?wsdl">

[<EntryPoint>]
let main _ = 
    
    // Hello Service
    printf "Hello Service\n"
    printf "-------------\n"

    use helloClient = helloService.GetBasicHttpBinding_IHelloWorldService()

    let helloWorldResult = helloClient.SayHelloWorld()

    printf "SayHelloWorld(): %A\n" helloWorldResult

    let sayHelloResult = helloClient.SayHelloTo "terje"

    printf "SayHello(\"terje\"): %A\n" sayHelloResult

    let getGreetingResult = helloClient.GetGreetingFor "terje"

    printf "GetGreetingFor(\"terje\"): %A, %A\n" getGreetingResult.Content getGreetingResult.TimeStamp

    let newGreeting = 
        helloService.ServiceTypes.WcfServiceLibraryExample.Greeting(
            Content = "Hello, beautiful!", 
            TimeStamp = DateTime.Now)

    let formatGreetingResult = helloClient.FormatGreeting newGreeting

    printf "FormatGreeting(newGreeting): %A\n" formatGreetingResult 

    // Calculator Service
    printf "\nCalculator Service\n"
    printf "------------------\n"

    use calculatorClient = calculatorService.GetCalculatorSoap()

    let additionResult = calculatorClient.Add(10, 15)

    printf "Result: %A\n" additionResult
    
    Console.WriteLine("Press any key to continue...");
    Console.ReadLine() |> ignore
    0 // return an integer exit code
