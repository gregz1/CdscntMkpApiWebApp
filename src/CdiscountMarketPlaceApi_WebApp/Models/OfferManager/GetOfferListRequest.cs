using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.OfferManager
{
    
    public class GetOfferListRequest:Request
    {
        public OfferFilter _OfferFilter { get; set; }


        public GetOfferListRequest()
        {
            _OfferFilter = new OfferFilter();         
        }

    }
}
