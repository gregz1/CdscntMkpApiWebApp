using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.OfferManager
{

       public class GetOfferListPaginatedRequest : Request
    {
        public OfferFilterPaginated _OfferFilterPaginated { get; set; }
        public GetOfferListPaginatedRequest()
        {
            _OfferFilterPaginated = new OfferFilterPaginated();
            
            _Parameters.Add("IdentifierType", "");
            _Parameters.Add("EAN", "");
        }
    }
}
