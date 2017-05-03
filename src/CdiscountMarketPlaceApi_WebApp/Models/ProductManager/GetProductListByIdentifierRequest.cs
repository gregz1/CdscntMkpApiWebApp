using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductListByIdentifierRequest : Request
    {
       public IdentifierRequest _IdentifierRequest { get; set; }

        public ProductListMessage _ProductListMessage;

        public GetProductListByIdentifierRequest()
        {
            _IdentifierRequest = new IdentifierRequest();
            _Parameters.Add("IdentifierType", "");
            _Parameters.Add("EAN", "");


        }
    }
}
