using System.Collections.Generic;
using System.Threading.Tasks;
using CdscntMkpApiReference_Prod;
using System.Xml.Serialization;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetModelListMessage : Message
    {
        public Task<ProductModelListMessage> _ProductModelListMessage { get; set; }

        public ModelFilter _ModelFilter { get; set; }


        public GetModelListMessage(Request MyRequest)
        {
            _Environment = MyRequest._EnvironmentSelected;
            GetService();
            _ModelFilter = new ModelFilter();
            _ModelFilter.CategoryCodeList = MyRequest._Parameters["Values"].Split(';');
            var _ProductListMessage = _MarketplaceAPIService.GetModelListAsync(MyRequest._HeaderMessage, _ModelFilter);
            XmlSerializer xmlSerializer = new XmlSerializer(_ProductListMessage.Result.GetType());

            _RequestXML = _RequestInterceptor.LastRequestXML;
            _MessageXML = _RequestInterceptor.LastResponseXML;
        }
    }
}
