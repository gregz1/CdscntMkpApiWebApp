using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
//using MarketplaceAPIServiceReference;
//using CdscntMkpAPIServiceReference1;
using System.Xml.Serialization;
using System.IO;
using System.ServiceModel.Dispatcher;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class MyCategoryTreeMessage
    {

        public Task<CategoryTreeMessage> _CategoryTreeMessage { get; set; }
        public string _CategoryTreeMessageXML { get; set; }
        public string _CategoryTreeRequestXML { get; set; }

        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public MyCategoryTreeMessage()
        { }
        public MyCategoryTreeMessage(string Token)
        {
            _Parameters = new Dictionary<string, string>();
            _Token = Token;
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            HeaderMessage MyHeaderMessage = GetDefaultHeaderMessage(Token);
            var requestInterceptor = new InspectorBehavior();
             MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _CategoryTreeMessage = MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage);
            XmlSerializer xmlSerializer = new XmlSerializer(_CategoryTreeMessage.Result.GetType());

            _CategoryTreeRequestXML = requestInterceptor.LastRequestXML;
            _CategoryTreeMessageXML = requestInterceptor.LastResponseXML;

        }
        private static HeaderMessage GetDefaultHeaderMessage(string Token)
        {
            return new HeaderMessage()
            {
                Context = new ContextMessage
                {
                    CatalogID = 1,
                    SiteID = 100
                },
                Localization = new LocalizationMessage
                {
                    Country = Country.Fr,
                    Currency = Currency.Eur,
                    DecimalPosition = 2,
                    Language = Language.Fr
                },
                Security = new SecurityContext
                {
                    TokenId = Token
                },
                Version = "1.0"
            };
        }
        
    }
}
