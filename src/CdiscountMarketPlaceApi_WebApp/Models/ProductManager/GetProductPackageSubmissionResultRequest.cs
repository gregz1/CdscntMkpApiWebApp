
using System.Collections.Generic;
using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductPackageSubmissionResultRequest : Request
    {
        public ProductFilter _ProductFilter { get; set; }
        public ProductIntegrationReportMessage _ProductIntegrationReportMessage { get; set; }

        public GetProductPackageSubmissionResultRequest()
        {
            _hasParameters = true;

            _Autentication = new Autentication();

            _ProductFilter = new ProductFilter();

            _Parameters = new Dictionary<string, string>();
            _Parameters.Add("PackageID", "");
        }        
    }
}
