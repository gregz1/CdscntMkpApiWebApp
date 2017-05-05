using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models.CrmManager
{
    public class CloseDiscussionListMessage:Message
    {
        public Task<CloseDiscussionResultMessage> _CloseDiscussionResultMessage;
        public CloseDiscussionListMessage(CloseDiscussionListRequest MyRequest)
        {
            _Environment = MyRequest._EnvironmentSelected;
            GetService();
            _CloseDiscussionResultMessage = _MarketplaceAPIService.CloseDiscussionListAsync(MyRequest._HeaderMessage, MyRequest._CloseDiscussionRequest);
            XmlSerializer xmlSerializer = new XmlSerializer(_CloseDiscussionResultMessage.GetType());

            _RequestXML = _RequestInterceptor.LastRequestXML;
            _MessageXML = _RequestInterceptor.LastResponseXML;
        }
    }
}
