using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductPackageSubmissionResultMessage
    {

        public Task<ProductIntegrationReportMessage> _ProductIntegrationReportMessage { get; set; }
        public string _GetProductPackageSubmissionResultMessageXML { get; set; }
        public string _GetProductPackageSubmissionResultRequestXML { get; set; }

        public PackageFilter _PackageFilter { get; set; }
        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public GetProductPackageSubmissionResultMessage()
        { }


        public GetProductPackageSubmissionResultMessage(HeaderMessage MyHeaderMessage,string Packageid)
        {
            _Parameters = new Dictionary<string, string>();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var requestInterceptor = new InspectorBehavior();
            _PackageFilter = new PackageFilter();
            long j;
            if (long.TryParse(Packageid, out j))
                _PackageFilter.PackageID = j ;

            MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _ProductIntegrationReportMessage = MarketplaceAPIService.GetProductPackageSubmissionResultAsync(MyHeaderMessage, _PackageFilter);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductIntegrationReportMessage.Result.GetType());

            _GetProductPackageSubmissionResultRequestXML = requestInterceptor.LastRequestXML;
            _GetProductPackageSubmissionResultMessageXML = requestInterceptor.LastResponseXML;

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
