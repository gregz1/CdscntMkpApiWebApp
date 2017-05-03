using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.OrderManager
{
    public class ValidateOrderListRequest :Request
    {
        public ValidateOrderListMessage _ValidateOrderListMessage { get; set; }
        public ValidateOrderListRequest()
        {
            _ValidateOrderListMessage = new ValidateOrderListMessage();
            
        }
    }
}
