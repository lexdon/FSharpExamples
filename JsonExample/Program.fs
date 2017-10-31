// # Demo of JsonProvider
//
// The JsonProvider is an erasing type provider, 
// which means you can't consume the generated
// types directly from C#. Make wrapper types 
// (classes or records) if you need to expose 
// types to C#.

open System
open FSharp.Data

[<Literal>]
let getPostURL = "https://jsonplaceholder.typicode.com/posts/1"

[<Literal>]
let getAllPostsURL = "https://jsonplaceholder.typicode.com/posts"

type GetPostFromURL = JsonProvider<getPostURL, RootName="post">

type GetAllPostsFromURL = JsonProvider<getAllPostsURL>

[<EntryPoint>]
let main _ = 
    
    // Get post with ID 1
    printfn "Get Post with ID 1"
    printfn "------------------"

    let post1 = GetPostFromURL.Load(getPostURL)
    
    printfn "%A" post1

    // Get all posts (and take 3)
    printfn "\nGet all posts (and take 3)"
    printfn "----------------------------"

    GetAllPostsFromURL.Load(getAllPostsURL) 
    |> Array.take 3
    |> Array.iter (printfn "%A")

    // Create new post
    printfn "\nCreate new post"
    printfn "----------------"

    let newPost = GetPostFromURL.Post(1, 1, "title!", "body!")

    let postResponse = newPost.JsonValue.Request "https://jsonplaceholder.typicode.com/posts"

    printfn "PostResponse: %A" postResponse
    
    Console.ReadKey() |> ignore
    0 // return an integer exit code
