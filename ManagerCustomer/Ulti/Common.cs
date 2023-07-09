using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ManagerCustomer.Ulti
{
    internal class Common
    {
        public static string? getDataInSetting(string key)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true);
            IConfigurationRoot configuration = builder.Build();
            var value = configuration.GetSection(key).Value;
            return value;
        }

        public static bool checkStringsIsNullOrEmpty(string[] strings)
        {
            foreach (string s in strings)
            {
                if (string.IsNullOrEmpty(s) || string.IsNullOrWhiteSpace(s))
                {
                    return true;
                }
            }
            return false;
        }

    }
}
