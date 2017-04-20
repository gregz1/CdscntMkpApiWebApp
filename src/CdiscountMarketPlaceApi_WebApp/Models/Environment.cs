using System.Collections.Generic;
using Microsoft.Extensions.Configuration;
using System.IO;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class Environment
    {
        private static readonly List<EnvironmentName> _Environments = new List<EnvironmentName>();
        public static IConfigurationRoot Configuration { get; set; }
        CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient  _MarketplaceAPIService;
        public enum EnvironmentName
        {
            Production,
            Preproduction,
            Recette,
            Dev,
            Sandbox,
            Local
        }

        public Environment()
        {

            _MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            Configuration = builder.Build();
        }
    }

}
