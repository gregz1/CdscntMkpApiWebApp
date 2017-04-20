using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetBrandListMessage
    {


        public Task<BrandListMessage> _BrandListMessage { get; set; }
        public string _BrandListMessageXML { get; set; }
        public string _BrandListRequestXML { get; set; }

        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public GetBrandListMessage()
        { }


        public GetBrandListMessage(HeaderMessage MyHeaderMessage)
        {
            _Parameters = new Dictionary<string, string>();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var requestInterceptor = new InspectorBehavior();
           
            MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _BrandListMessage = MarketplaceAPIService.GetBrandListAsync(MyHeaderMessage);
            XmlSerializer xmlSerializer = new XmlSerializer(_BrandListMessage.Result.GetType());


            _BrandListRequestXML = requestInterceptor.LastRequestXML;
            _BrandListMessageXML = requestInterceptor.LastResponseXML;

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
