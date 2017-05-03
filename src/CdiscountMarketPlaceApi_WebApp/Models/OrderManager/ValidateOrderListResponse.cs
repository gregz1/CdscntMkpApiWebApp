using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models.OrderManager
{
    public class ValidateOrderListResponse : Message
        {
            public Task<ValidationResultMessage> _ValidationResultMessage { get; set; }

           

            public ValidateOrderListResponse(ValidateOrderListRequest MyRequest)
            {
                _Environment = MyRequest._EnvironmentSelected;
                GetService();
            _ValidationResultMessage = _MarketplaceAPIService.ValidateOrderListAsync(MyRequest._HeaderMessage, MyRequest._ValidateOrderListMessage);
                XmlSerializer xmlSerializer = new XmlSerializer(_ValidationResultMessage.Result.GetType());

                _RequestXML = _RequestInterceptor.LastRequestXML;
                _MessageXML = _RequestInterceptor.LastResponseXML;
            }
        }
    }

