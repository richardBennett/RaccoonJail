#To use the dotnet ef tools you'll need to install them https://docs.microsoft.com/en-us/ef/core/cli/dotnet

dotnet ef dbcontext scaffold "Server=(local);Database=RaccoonJail;Trusted_Connection=True;" --project "Database.Models" Microsoft.EntityFrameworkCore.SqlServer -o "..\Database.Models" --use-database-names --force