using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models.OfferManager
{
    public class GetOfferListMessage : Message
    {
        public Task<OfferListMessage> _OfferListMessage { get; set; }



        public GetOfferListMessage(GetOfferListRequest MyRequest)
        {
            _Environment = MyRequest._EnvironmentSelected;
            GetService();
            _OfferListMessage = _MarketplaceAPIService.GetOfferListAsync(MyRequest._HeaderMessage, MyRequest._OfferFilter);
            XmlSerializer xmlSerializer = new XmlSerializer(_OfferListMessage.Result.GetType());

            _RequestXML = _RequestInterceptor.LastRequestXML;
            _MessageXML = _RequestInterceptor.LastResponseXML;
        }
    }
}
