using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductListByIdentifierMessage
    {

        public Task<ProductListByIdentifierMessage> _ProductListByIdentifierMessage { get; set; }
        public string _ProductListByIdentifierMessageXML { get; set; }
        public string _ProductListByIdentifierRequestXML { get; set; }

        public IdentifierRequest _IdentifierRequest { get; set; }
        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public GetProductListByIdentifierMessage()
        { }


        public GetProductListByIdentifierMessage(HeaderMessage MyHeaderMessage, Dictionary<string,string> ValuesList )
        {
            _Parameters = new Dictionary<string, string>();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var requestInterceptor = new InspectorBehavior();
            _IdentifierRequest = new IdentifierRequest();
            //_IdentifierRequest.IdentifierType = ValuesList["IdentifierType"];

            MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _ProductListByIdentifierMessage = MarketplaceAPIService.GetProductListByIdentifierAsync(MyHeaderMessage, _IdentifierRequest);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductListByIdentifierMessage.Result.GetType());


            _ProductListByIdentifierRequestXML = requestInterceptor.LastRequestXML;
            _ProductListByIdentifierMessageXML = requestInterceptor.LastResponseXML;

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
