using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace Oshop.Data
{
    public class OshopDbContextFactory : IDesignTimeDbContextFactory<OshopDbContext>
    {

        public OshopDbContext CreateDbContext(string[] args)
        {
            var configuration = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json")
                    .Build();

            var optionsBuilder = new DbContextOptionsBuilder();

            var connectionString = configuration
                        .GetConnectionString("SqlServer");

            optionsBuilder.UseSqlServer(connectionString);

            return new OshopDbContext(optionsBuilder.Options);
        }
    }
}
