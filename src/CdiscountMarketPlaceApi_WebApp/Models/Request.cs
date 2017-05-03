using System.Collections.Generic;
using CdscntMkpApiReference_Prod;
using CdiscountMarketPlaceApi_WebApp.Enumeration;
namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class Request
    {
        public bool _hasParameters;
        public Autentication _Autentication;
        public string _Login { get; set; }
        public string _Password { get; set; }
        public string _Token { get; set; }
        public EnvironmentEnum _EnvironmentSelected { get; set; }
        public Dictionary<string, string> _Parameters { get; set; }

        public HeaderMessage _HeaderMessage;
        public Request()
        {
            _Autentication = new Autentication();
            _Parameters = new Dictionary<string, string>();            
        }

        public void GetHeaderMessage()
        {
            _Autentication._Login = _Login;
            _Autentication._Password = _Password;
            _Autentication._Environment = _EnvironmentSelected;
            _Autentication._Token = _Token;
            _HeaderMessage =  _Autentication.GetDefaultHeaderMessage();
        }
    }
}
