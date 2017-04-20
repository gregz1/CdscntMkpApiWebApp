using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductListMessage
    {

        public Task<ProductListMessage> _ProductListMessage { get; set; }
        public string _ProductListMessageXML { get; set; }
        public string _ProductListRequestXML { get; set; }

        public ProductFilter _ProductFilter { get; set; }
        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public GetProductListMessage()
        { }


        public GetProductListMessage(HeaderMessage MyHeaderMessage,string CategoryCode)
        {
            _Parameters = new Dictionary<string, string>();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var requestInterceptor = new InspectorBehavior();
            _ProductFilter = new ProductFilter();
            _ProductFilter.CategoryCode = CategoryCode;

            MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _ProductListMessage = MarketplaceAPIService.GetProductListAsync(MyHeaderMessage, _ProductFilter);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductListMessage.Result.GetType());


            _ProductListRequestXML = requestInterceptor.LastRequestXML;
            _ProductListMessageXML = requestInterceptor.LastResponseXML;

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
