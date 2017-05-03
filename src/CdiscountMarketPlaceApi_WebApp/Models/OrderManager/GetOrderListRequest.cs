using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.OrderManager
{
    public class GetOrderListRequest : Request
    {
        public OrderFilter _OrderFilter { get; set; }
        public GetOrderListRequest()
        {
            _OrderFilter = new OrderFilter();

        }

    }
}
