using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class SubmitProductPackageMessage : Message
    {
        public Task<ProductIntegrationReportMessage> _ProductIntegrationReportMessage { get; set; }
        string _EndPointAddress;
        ProductPackageRequest _ProductPackageRequest;

        public SubmitProductPackageMessage(Request MyRequest)
        {
            _Environment = MyRequest._EnvironmentSelected;
            GetService();
            _ProductPackageRequest = new ProductPackageRequest();
            _ProductPackageRequest.ZipFileFullPath = MyRequest._Parameters["Values"];
            _ProductIntegrationReportMessage = _MarketplaceAPIService.SubmitProductPackageAsync(MyRequest._HeaderMessage, _ProductPackageRequest);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductIntegrationReportMessage.Result.GetType());

            _RequestXML = _RequestInterceptor.LastRequestXML;
            _MessageXML = _RequestInterceptor.LastResponseXML;

        }

    }
}
