🚀 **.NET 8 Web API — CRUD Example (EF Core + DI + AutoMapper)**

This project is a clean and simple .NET 8 Web API demonstrating:
    - Dependency Injection
    - Repository Pattern
    - Entity Framework Core 8 (SQL Server)
    - AutoMapper
    - DTO pattern
    - JSON Patch (optional)
    - Swagger
    - Modern .NET 8 minimal hosting model

**📁 Project Structure**
/Controllers
/Models
/DTOs
/Profiles
/Data
    AppDbContext.cs
    IRepository.cs
    Repository.cs
Program.cs
appsettings.json

**🛠️ Technologies**

   - .NET 8 Web API
   - Entity Framework Core 8
   -  SQL Server
   - AutoMapper
   - Newtonsoft.Json (only if using PATCH)
   - Swagger/OpenAPI

**🔧 Setup**
Install Dependencies
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Tools
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.JsonPatch
dotnet add package Microsoft.AspNetCore.Mvc.NewtonsoftJson --version 8.0.6

**🗄️ Database**
Create Migration:
dotnet ef migrations add InitialCreate

Apply Migration:
dotnet ef database update

**🧩 API Endpoints**
Method	Route	Description
GET	/api/items	Get all items
GET	/api/items/{id}	Get a single item
POST	/api/items	Create item
PUT	/api/items/{id}	Update item fully
PATCH	/api/items/{id}	Partial update (JSON Patch)
DELETE	/api/items/{id}	Delete item

**📜 Credits**
- This project was inspired by the tutorial/video I followed:  
  [[Full .NET 8 Web API CRUD Tutorial](https://www.example.com/video-link)](https://www.youtube.com/watch?v=fmvcAzHpsk8&t=9627s) 
