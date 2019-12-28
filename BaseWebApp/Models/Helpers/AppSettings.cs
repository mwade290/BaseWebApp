using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BaseWebApp.Models.Helpers
{
    /// <summary>
    /// Gets mandatory application settings from 'appsettings.json' and stores in helper properties.
    /// Will throw exception on startup if any required properties are not present.
    /// Properties MUST match appsettings Key EXACTLY for mapping to work correctly.
    /// </summary>
    public class AppSettings
    {
        public AppSettings(IConfiguration configuration)
        {
            Configuration = configuration;
            CommonConnectionString = ParseItem(configuration.GetConnectionString("Common"), "Common connection string");
        }

        public IConfiguration Configuration { get; set; }
        public string CommonConnectionString { get; set; }

        private string ParseItem(string item, string errorToDisplay)
        {
            if (string.IsNullOrWhiteSpace(item))
            {
                throw new ArgumentException($"Missing Application Setting: '{errorToDisplay}'");
            }
            return item;
        }
    }
}

