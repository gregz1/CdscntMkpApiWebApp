
using System.Collections.Generic;
using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class GetProductListRequest
    {
        bool _hasParameters;
        public Autentication _Autentication;
        public string _Login { get; set; }
        public string _Password { get; set; }
        public string _Token { get; set; }
        public string _EnvironmentSelected { get; set; }
        public Dictionary<string, string> _Parameters { get; set; }
        public List<string> _EnvironementList { get; set; }

        public ProductFilter _ProductFilter { get; set; }

        public ProductListMessage _ProductListMessage;

        public GetProductListRequest()
        {
            _hasParameters = true;
            _EnvironementList = new List<string>() { "Préproduction", "Production" };

            _Autentication = new Autentication();

            _ProductFilter = new ProductFilter();

            _Parameters = new Dictionary<string, string>();
            _Parameters.Add("Code Category", "");


        }
        public HeaderMessage GetHeaderMessage()
        {

            _Autentication._Login = _Login;
            _Autentication._Password = _Password;
            _Autentication._Environment = _EnvironmentSelected;
            //  _Autentication._Token =  _Autentication.GetToken();
            /*if (_Token != null)
                _Autentication._Token = _Token;
            else if (_Login != null && _Password != null)
                _Autentication.GetToken();*/
            return _Autentication.GetDefaultHeaderMessage();
        }
    }
}
