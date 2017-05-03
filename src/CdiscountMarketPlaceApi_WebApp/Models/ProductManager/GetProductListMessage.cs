using System.Threading.Tasks;
using System.Xml.Serialization;
using CdscntMkpApiReference_Prod;
namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductListMessage : Message
    {
        public Task<ProductListMessage> _ProductListMessage { get; set; }
     
        public ProductFilter _ProductFilter { get; set; }
             
 
        public GetProductListMessage(Request MyRequest)
        {
            _Environment = MyRequest._EnvironmentSelected;
            GetService();
            _ProductFilter = new ProductFilter();
            _ProductFilter.CategoryCode = MyRequest._Parameters["Values"];
            _ProductListMessage = _MarketplaceAPIService.GetProductListAsync(MyRequest._HeaderMessage, _ProductFilter);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductListMessage.Result.GetType());

            _RequestXML = _RequestInterceptor.LastRequestXML;
            _MessageXML = _RequestInterceptor.LastResponseXML;
        }
    }
}
