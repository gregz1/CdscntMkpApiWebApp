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
        public ValidateOrderListRequest(GetOrderListMessage MyGetOrderListMessage)
        {
            _ValidateOrderListMessage = new ValidateOrderListMessage();
            int i = 0;
            foreach(Order MyOrder in MyGetOrderListMessage._OrderListMessage.Result.OrderList)
            {
                ValidateOrder MyValidateOrder = new ValidateOrder();
                MyValidateOrder.CarrierName = "CarrierName";
                MyValidateOrder.TrackingNumber= "TrackingNumber";
                MyValidateOrder.TrackingUrl= "TrackingUrl";
                MyValidateOrder.OrderNumber = MyOrder.OrderNumber;
                int j = 0;
                foreach (OrderLine MyOrderLine in MyOrder.OrderLineList)
                {
                    ValidateOrderLine MyValidateOrderLine = new ValidateOrderLine();
                    MyValidateOrderLine.SellerProductId = MyOrderLine.SellerProductId;
                    MyValidateOrderLine.ProductCondition = (ProductConditionEnum)MyOrderLine.ProductCondition;
                    MyValidateOrder.OrderLineList[j] = MyValidateOrderLine;
                }

                _ValidateOrderListMessage.OrderList[i] = MyValidateOrder;
            }
            _Token = MyGetOrderListMessage._Token;

        }
    }
}
