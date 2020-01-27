# Conta Corrente

## Prerequisites
- [.NET Core 2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- [MySQL](https://dev.mysql.com/downloads)
- [Angular CLI](https://angular.io/guide/setup-local)

## Running the aplication
### API
Open ```appsettings.json``` at the root path (```/conta-corrente-api/src/ContaCorrente.Api/```) and inform your ```ConnectionStrings``` for the database.
Then, open the terminal or command prompt at the API root path (```/conta-corrente-api/src/ContaCorrente.Api/```) and run the following commands, in sequence:
```
dotnet restore
dotnet run
```
API/Swagger will be available at: ```http://localhost:5000```

### APP
Open the terminal or command prompt at the API root path (```/conta-corrente-app/```) and run the following commands, in sequence:
```
npm install
npm start
```
APP will be available at: ```http://localhost:4200```

## Frameworks and Libraries
- [ASP.NET Core 2.2](https://docs.microsoft.com/pt-br/aspnet/core/?view=aspnetcore-2.2)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core) 
- [MySQL](https://dev.mysql.com/doc/connector-net/en/connector-net-entityframework-core.html)
- [Autofac](https://autofac.readthedocs.io/en/latest)
- [Swagger](https://docs.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-2.2&tabs=visual-studio)
- [Entity Framework In-Memory Provider](https://docs.microsoft.com/en-us/ef/core/miscellaneous/testing/in-memory)
- [xUnit](https://xunit.net)
- [Fluent Assertions](https://fluentassertions.com/documentation)
- [Angular](https://angular.io/docs)
