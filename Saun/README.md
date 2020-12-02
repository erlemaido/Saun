# Saun
University project. This project is a simple ASP.NET online store.

Create migration: 
dotnet ef migrations add InitialDbCreation --project WebApp --startup-project WebApp --context ApplicationDbContext

Update Database: 
dotnet ef database update --project WebApp --startup-project WebApp --context ApplicationDbContext
Drop Database:
dotnet ef database drop --project WebApp --startup-project WebApp --context ApplicationDbContext
