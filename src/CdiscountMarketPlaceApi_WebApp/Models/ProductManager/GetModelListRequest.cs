using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{

    
    public class GetModelListRequest : Request
    {
        public ModelFilter _ModelFilter;
        public GetModelListRequest()
        {
            _ModelFilter = new ModelFilter();
            _Parameters.Add("Code Category", "");
        }

    }
}
