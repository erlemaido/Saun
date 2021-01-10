# Saun
University project. This project is a simple ASP.NET online store.

Create migration: 
dotnet ef migrations add InitialDbCreation --project Infra --startup-project WebApp --context SaunaDbContext

Update Database:
dotnet ef database update --project Infra --startup-project WebApp --context SaunaDbContext

Drop Database:
dotnet ef database drop --project Infra --startup-project WebApp --context SaunaDbContext
