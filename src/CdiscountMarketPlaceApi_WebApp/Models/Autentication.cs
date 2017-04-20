using System;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Net.Http;
using System.Runtime.Serialization;
using CdscntMkpApiReference_Prod;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class Autentication
    {
        public enum EnvironmentName
        {
            Production,
            Preproduction
         }
        public string _Login { get; set; }
        public string _Password { get; set; }
        public string _Environment { get; set; }
        public string _Token { get; set; }
        public static IConfigurationRoot Configuration { get; set; }

        public Autentication() {
       
        }

    public string GetToken()
        {
            string token = string.Empty;
            try
            {
                string svcIssue= "";
                string realm="";

                switch (_Environment)
                {
                    case "Production":
                        svcIssue = "https://sts.cdiscount.com/users/httpIssue.svc";
                        realm = "https://wsvc.cdiscount.com/MarketplaceAPIService.svc";

                        break;


                    case "Préproduction":
                        svcIssue = "https://sts.preprod-cdiscount.com/users/httpIssue.svc";
                        realm = "https://wsvc.preprod-cdiscount.com/MarketplaceAPIService.svc";
                        break;
                }


                
                string encoded = Convert.ToBase64String(Encoding.UTF8.GetBytes(string.Format("{0}:{1}", _Login, _Password)));

                var stsUri = new Uri(string.Format("{0}/?realm={1}", svcIssue, realm));
               Stream  myttokenStreamoken;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encoded);
                    var data =  client.GetAsync(stsUri).Result;
                    myttokenStreamoken =  data.Content.ReadAsStreamAsync().Result;
                   
                }

                if (myttokenStreamoken != null)
                {
                    var dataContractSerializer = new DataContractSerializer(typeof(string));
                    token = (string)dataContractSerializer.ReadObject(myttokenStreamoken);
                }
            }
            catch (System.Exception ex)
            {
                var m = ex.Message;
            }

                return token;
        }

        public HeaderMessage GetDefaultHeaderMessage()
        {
            if (_Token == null)
                _Token = GetToken();
            return new HeaderMessage()
            {
                Context = new ContextMessage
                {
                    CatalogID = 1,
                    SiteID = 100
                },
                Localization = new LocalizationMessage
                {
                    Country = Country.Fr,
                    Currency = Currency.Eur,
                    DecimalPosition = 2,
                    Language = Language.Fr
                },
                Security = new SecurityContext
                {
                    TokenId = _Token
                },
                Version = "1.0"
            };

        }
    }


    }
