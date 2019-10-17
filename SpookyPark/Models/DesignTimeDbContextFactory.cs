using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace SpookyPark.Models
{
  public class SpookyParkContextFactory : IDesignTimeDbContextFactory<SpookyParkContext>
  {

    SpookyParkContext IDesignTimeDbContextFactory<SpookyParkContext>.CreateDbContext(string[] args)
    {
      IConfigurationRoot configuration = new ConfigurationBuilder()
          .SetBasePath(Directory.GetCurrentDirectory())
          .AddJsonFile("appsettings.json")
          .Build();

      var builder = new DbContextOptionsBuilder<SpookyParkContext>();
      var connectionString = configuration.GetConnectionString("DefaultConnection");

      builder.UseMySql(connectionString);

      return new SpookyParkContext(builder.Options);
    }
  }
}