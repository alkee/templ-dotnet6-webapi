# templ-dotnet6-webapi

ASP.NET 6 web api service template.

## Feature

 * Minimal running environment for Visual Studio Code
 * [Swagger UI](https://swagger.io/tools/swagger-ui/) support. (only in _development_ environment)
 * [Custom configuration sample](./AppSettings.cs) for web service
     1. read from `appsettings.json`
     2. read from `appsettings.{ASPNETCORE_ENVIRONMENT}.json`
     3. read form OS environment
     4. read from command line argument

