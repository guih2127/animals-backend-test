# Shelter Buddy Api - Code Test

This is an Animals API that can be used to query and insert pet data. In the main branch, the code just have the logic implementation and the tests. It does not have real data persistence, because the methods read data from a json file and work with it.

If you want to test this API with real data, using EF Core and SQL Server, please checkout to the "back-end-test-with-entity-framework" branch.

## Running the application

You can run this application from Visual Studio or, using .NET CLI, typing the following commands:

```
cd .\ShelterBuddy.CodePuzzle.Api
```

```
dotnet run
```

To access the actual API documentation, you can go to the swagger url:
```
http://localhost:{yourlocalhostnumber}/swagger
```
