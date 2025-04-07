# General Information

**Only for Testing Development purpose**, simple .NET Web API, **without ORM** and with database schema project.

# Technical Stack
- .NET 6.0
-  MS SQL Server 2022

# Project First Run

1. Populate database
  - (optional) If you don't have MS SQL Server, run it from container (localhost:1433).
  - Deploy DB project to MS SQL Server.  
2. Run ContractorsWebAPI
3. SwaggerUI https://localhost:7176/swagger/index.html

# MS SQL Server (Docker Container)

`docker pull mcr.microsoft.com/mssql/server:2022-CU18-ubuntu-22.04`

`docker run -e "ACCEPT_EULA=Y" -e "MSSQL_SA_PASSWORD=Password123!" -p 1433:1433 --name sql1  --hostname sql1 -d --rm mcr.microsoft.com/mssql/server:2022-CU18-ubuntu-22.04`