# Type providers

## What is a type provider?

- A component that provides types, properties and methods for use in your program

## Why is it cool?

- It eliminates the barriers to working with diverse information sources found on the Internet and in modern enterprise environments

## How does it do it?

- By automatically generating the types, properties and methods needed to interact with different data sources

## How does it differ from regular code generation?

- Type providers are supported on the language and compiler level, removing the need to use external (e.g. IDE) tools 

## Some useful type providers

- [JSON Type Provider](http://fsharp.github.io/FSharp.Data/library/JsonProvider.html)
- [CSV Type Provider](http://fsharp.github.io/FSharp.Data/library/CsvProvider.html)
- [XML Type Provider](http://fsharp.github.io/FSharp.Data/library/XmlProvider.html)
- [HTTP Type Provider](http://fsharp.github.io/FSharp.Data/library/XmlProvider.html)
- [Azure Storage Type Provider](https://github.com/fsprojects/AzureStorageTypeProvider)
- [WorldBank Provider](http://fsharp.github.io/FSharp.Data/library/XmlProvider.html)
- [Swagger 2.0 Type Provider](https://github.com/fsprojects/SwaggerProvider)

## SQL

[Comparison of SQL Type Providers](http://fsprojects.github.io/FSharp.Data.SqlClient/comparison.html)

- [FSharp.Data.SqlClient](http://fsprojects.github.io/FSharp.Data.SqlClient/) - *"Not you grandfather's ORM"*
	- **SqlCommandProvider** -  type-safe access to full set of T-SQL language
	- **SqlProgrammabilityProvider** - quick access to Sql Server functions, **stored procedures** and tables in idiomatic F# way
	- **SqlEnumProvider** - generates enumeration types based on static lookup data from any ADO.NET compliant source
- [SQLProvider](http://fsprojects.github.io/SQLProvider/)
- [SqlDataConnection](https://docs.microsoft.com/en-us/dotnet/fsharp/tutorials/type-providers/accessing-a-sql-database)

## Azure

- [Azure Storage Type Provider](https://github.com/fsprojects/AzureStorageTypeProvider)

## Bonus: Using F# on Azure

[Using F# on Azure](https://docs.microsoft.com/en-us/dotnet/fsharp/using-fsharp-on-azure/)