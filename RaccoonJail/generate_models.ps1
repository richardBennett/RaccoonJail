dotnet ef dbcontext scaffold "Server=(local);Database=RaccoonJail;Trusted_Connection=True;" --project "Database.Models" Microsoft.EntityFrameworkCore.SqlServer -o "..\Database.Models" --use-database-names