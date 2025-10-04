using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using Microsoft.Extensions.Configuration;

namespace HttpMethod_DAL.DBContext
{
    public static class DBContext
    {
        public static IConfigurationRoot? configuration;
        public static string? GetConnectionString()
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            configuration = builder.Build();
            var connectionString = configuration["ConnectionStrings:DefaultConnection"];
            return connectionString;
        }

        public static string GetConfiguration(string key, string value)
        {
            var builder = new ConfigurationBuilder()
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .AddJsonFile("appsettings.json");

            configuration = builder.Build();

            var data = configuration[key + ":" + value];
            return data;
        }
    }
}
