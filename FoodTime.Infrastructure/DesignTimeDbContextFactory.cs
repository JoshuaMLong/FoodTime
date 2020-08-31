using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTime.Infrastructure
{
    public class DesignTimeDbContextFactory : IDesignTimeDbContextFactory<FoodTimeContext>
    {
        public FoodTimeContext CreateDbContext(string[] args)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var builder = new DbContextOptionsBuilder<FoodTimeContext>();
            string connectionString = configuration.GetConnectionString("FoodTime.API");

            builder.UseSqlServer(connectionString);
            return new FoodTimeContext(builder.Options, configuration);
        }
        private string GetJsonFile()
        {
            string env = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            Console.WriteLine(env);
            switch(env)
            {
                case "Development":
                    return "appsettings.Development.json";
                case "UAT":
                    return "appsettings.UAT.json";
                case "Production":
                    return "appsettings.Production.json";
                default:
                    return null;
            }
        }
    }
}
