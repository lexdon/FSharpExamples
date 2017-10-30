// # Demo of JsonProvider
//
// The JsonProvider is an erasing type provider, 
// which means you can't consume the generated
// types directly from C#. Make wrapper types 
// (classes or records) if you need to expose 
// types to C#.

open System
open FSharp.Data

type PostFromUrl = 
    JsonProvider<"https://jsonplaceholder.typicode.com/posts/1", RootName="post">

type AllPostsFromUrl = 
    JsonProvider<"https://jsonplaceholder.typicode.com/posts">

[<EntryPoint>]
let main _ = 
    
    let post2 = PostFromUrl.Load("https://jsonplaceholder.typicode.com/posts/2")
    let allPosts = AllPostsFromUrl.GetSamples()

    let newPost = PostFromUrl.Post(1, 1, "title!", "body!")

    printfn "%A" post2
    
    Console.ReadKey() |> ignore
    0 // return an integer exit code
