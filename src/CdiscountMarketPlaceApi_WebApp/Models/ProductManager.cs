using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CdiscountMarketPlaceApi_WebApp.Models;


namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class ProductManager
    {

        public List<string> _FeaturesList { get; set; }
        public string _SelectedFeature { get; set; }
        public GetAllAllowedCategoryTreeRequest _GetAllAllowedCategoryTreeRequest;
        public string _MessageXML { get; set; }
        public string _RequestXML { get; set; }
        public List<string> _ParametersList { get; set; }
        public string _Login { get; set; }
        public string _Password { get; set; }
        public string _Token { get; set; }
        
        public ProductManager()
        {
            _FeaturesList = new List<string> { "GetAllAllowedCategoryTree", "GetAllowedCategoryTree", "GetAllModelList", "GetProductList", "SubmitProductPackage", "GetProductPackageSubmissionResult", "GetProductPackageMatchingFileData", "GetBrandList" };
        }

        public void ProductActions()
        {

            switch (_SelectedFeature)
            {

                case "GetAllAllowedCategoryTree":
                    var message = new MyCategoryTreeMessage(_Token);
                    if (message._Parameters != null)
                    {
                        _ParametersList = new List<string>();                        
                    }
                    break;
            }
        }


    }
}
