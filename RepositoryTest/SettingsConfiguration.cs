using Microsoft.Extensions.Configuration;
using System.IO;

namespace Repository.Tests
{
    public static class SettingsConfiguration
    {
        public static IConfigurationRoot GetConfigurationRoot =>
            new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.Test.json",
                optional: true,
                reloadOnChange: true)
            .Build();
    }
}
