using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace ContaCorrente.Infrastructure.Data
{
    public class ContaCorrenteDbContextFactory : IDesignTimeDbContextFactory<ContaCorrenteDbContext>
    {
        public ContaCorrenteDbContext CreateDbContext(string[] args)
        {
            var configurationBuilder = new ConfigurationBuilder()
               .SetBasePath(Directory.GetCurrentDirectory())
               .AddJsonFile("appsettings.Development.json")
               .Build();

            var dbContextOptionsBuilder = new DbContextOptionsBuilder();
            dbContextOptionsBuilder.UseMySQL(configurationBuilder.GetConnectionString("ContaCorrente"));

            return new ContaCorrenteDbContext(dbContextOptionsBuilder.Options);
        }
    }
}
