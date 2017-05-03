using System.Collections.Generic;
using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class Message
    {

        public string _MessageXML { get; set; }
        public string _RequestXML { get; set; }

        public string _Token { get; set; }

        protected MarketplaceAPIServiceClient _MarketplaceAPIService;

        protected InspectorBehavior _RequestInterceptor;
        public Dictionary<string, string> _Parameters { get; set; }
        protected Enumeration.EnvironmentEnum _Environment;
        string _EndPointAddress;
        protected ServiceBaseAPIMessage ApiMessage;
        

        public Message()
        {
            _Parameters = new Dictionary<string, string>();
            _RequestInterceptor = new InspectorBehavior();  
        }


        public void GetService()
        {
            if (_Environment == Enumeration.EnvironmentEnum.Production)
                _EndPointAddress = "https://wsvc.cdiscount.com/MarketplaceAPIService.svc";
            else if (_Environment == Enumeration.EnvironmentEnum.Local)
                _EndPointAddress = "http://localhost:8030/MarketplaceAPIService.svc";
            else
                _EndPointAddress = "https://wsvc.preprod-cdiscount.com/MarketplaceAPIService.svc";

            _MarketplaceAPIService = new MarketplaceAPIServiceClient(MarketplaceAPIServiceClient.EndpointConfiguration.BasicHttpBinding_IMarketplaceAPIService, "https://wsvc.cdiscount.com/MarketplaceAPIService.svc");
            _MarketplaceAPIService.Endpoint.EndpointBehaviors.Add(_RequestInterceptor);


        }


    }
}
