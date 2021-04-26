# 🦝 RACCOON JAIL 🦝
### Simple CRUD Api 

----------------------
### To Use
* Deploy Database Project using (double clicking) Database/localhost.publish.xml
* Build and run API

* Has Swagger, default access is localhost:5000
* Postman collection included 

----------------------
### Layers
* Database
    * Simple SQL Db Project
* Database Models
    * EF Core
    * Includes Database Context
    * Includes Database POCOs
    * Generated using EF Core Scaffolding
* Models
    * DTOs
    * Requests
    * Any Models that are used by multiple layers
* Database Services
    * Dotnet Core
    * Returns Data using DTOs
* API
    * MVC
    * Can deploy as Windows Service
    * Simple CRUD endpoints