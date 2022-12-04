# Shelter Buddy Api - Code Test

This is an Animals API that can be used to query and insert pet data. In this branch, there is real data manipulation, using EF Core and SQL Server to query and persist the pets data.

## Running the application

1. The first thing you need to do is to create a new SQL Server Database instance on your machine. After doing that, get your connection string and change the one that is located on ShelterBuddy.CodePuzzle.Api/appsettings.json.

2. Now you need to use the Migrations of this project to update the database you are using, you can do it using the following command:

With Visual Studio:
```
Update-Database
```

With .NET CLI:
```
dotnet ef database update --project ShelterBuddy.CodePuzzle.Core -s ShelterBuddy.CodePuzzle.Api
```

3. Now you can finally run the application. You can do using Visual Studio or, using .NET CLI, typing the following commands:

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
