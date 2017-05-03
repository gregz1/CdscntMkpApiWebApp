using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models.OfferManager
{
    public class SubmitOfferPackageRequest:Request
    {
        public OfferPackageRequest _OfferPackageRequest { get; set; }

        public SubmitOfferPackageMessage _SubmitOfferPackageMessage;
        public SubmitOfferPackageRequest()
        {
            _hasParameters = true;
            _OfferPackageRequest = new OfferPackageRequest();
            _Parameters.Add("zipfilepath", "");
        }

    }
}
