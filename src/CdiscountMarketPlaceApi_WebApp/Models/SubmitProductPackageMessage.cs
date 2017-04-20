using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;

using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class SubmitProductPackageMessage
    {
        public Task<ProductIntegrationReportMessage> _ProductIntegrationReportMessage { get; set; }
        public string _ProductIntegrationReportMessageXML { get; set; }
        public string _ProductIntegrationReportRequestXML { get; set; }

        ProductPackageRequest _ProductPackageRequest;

        public string _Token { get; set; }

        public Dictionary<string, string> _Parameters { get; set; }

        public SubmitProductPackageMessage()
        { }


        public SubmitProductPackageMessage(HeaderMessage MyHeaderMessage, string ZipFilePath)
        {
            _Parameters = new Dictionary<string, string>();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            var MarketplaceAPIServicePP = new CdscntMkpApiReference_Preprod.MarketplaceAPIServiceClient();

            var requestInterceptor = new InspectorBehavior();
            _ProductPackageRequest = new ProductPackageRequest();
            _ProductPackageRequest.ZipFileFullPath = ZipFilePath;
            MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(requestInterceptor);
            _ProductIntegrationReportMessage = MarketplaceAPIService.SubmitProductPackageAsync(MyHeaderMessage, _ProductPackageRequest);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductIntegrationReportMessage.Result.GetType());

            _ProductIntegrationReportRequestXML = requestInterceptor.LastRequestXML;
            _ProductIntegrationReportMessageXML = requestInterceptor.LastResponseXML;

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
