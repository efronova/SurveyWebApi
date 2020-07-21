# Survey WEB API

This Web API has a smilpe Survey application which in turn contains two parameters: "name" and "description"

## Technologies Used

- .NET Core
- MySQL
- Postman
- Swagger


In order to launch Survey
1) Clone into repository
2) Launch MySQL Workbench and create table with parameters (int id auto increment, "name" char 20, "description" char 200)
3) Make sure SQL Server is running and open Visual Studio
4) in both appsettings.json and Connector.cs change connection string to database to your local credentials
5) In Visual Studio terminal change directory to project root folder and type "dotnet run"
6) Now everything is up and running! 
7) You can access endpoints at "http://localhost:5000/swagger/index.html"
8) Use of Postman is recommended!