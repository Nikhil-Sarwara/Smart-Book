using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using SmartBook.Database.Data;
using System.IO;

namespace SmartBook.Database.Factories
{
    public class ApplicationDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            // Get the directory where the solution file (.sln) is located
            var solutionDirectory = Directory.GetParent(Directory.GetCurrentDirectory())?.Parent?.FullName;

            if (string.IsNullOrEmpty(solutionDirectory))
            {
                // Fallback if we can't easily find the solution root
                solutionDirectory = Directory.GetCurrentDirectory();
            }

            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(solutionDirectory) // Set the base path to the solution root
                .AddJsonFile("Smart Book/SmartBook.Api/appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<ApplicationDbContext>();
            var connectionString = configuration.GetConnectionString("DefaultConnection");

            builder.UseSqlServer(connectionString); // Or UseNpgsql if you're using PostgreSQL

            return new ApplicationDbContext(builder.Options);
        }
    }
}