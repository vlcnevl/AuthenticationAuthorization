
using Microsoft.Extensions.Configuration;

namespace AuthenticationAuthorization.Persistance
{
    public static class Configuration
    {
         public static string ConnectionString
        {
            get{

                ConfigurationManager configurationManager = new();
                configurationManager.SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../../Presentation/AuthenticationAuthorization.API"));
                configurationManager.AddJsonFile("appsettings.json");
                return configurationManager.GetConnectionString("PostgreSql");
            }
        }
    }
}
