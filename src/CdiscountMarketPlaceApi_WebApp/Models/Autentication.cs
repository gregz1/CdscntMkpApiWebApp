using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.IO;
using System.Text;
using System.Net;
using Microsoft.Extensions.DependencyInjection;
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
            Preproduction/*,
            Recette,
            Dev,
            Sandbox,
            Local*/
        }
        public string _Login { get; set; }
        public string _Password { get; set; }
        public string _Environment { get; set; }
        public string _Token { get; set; }
        public static IConfigurationRoot Configuration { get; set; }

        public Autentication() {
            /*var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");
            Configuration = builder.Build();
            */
           
            //  _MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();

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
                /*   var request = (HttpWebRequest)WebRequest.Create(stsUri);

                   request.Headers["HttpRequestHeader"].Add("Authorization", string.Format("Basic={0}", encoded));
                   request.Method = "GET";

                   var response = await request.GetResponseAsync();
                   var tokenStream = response.GetResponseStream();
                  */
                Stream  myttokenStreamoken;
                using (HttpClient client = new HttpClient())
                {
                    client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Basic", encoded);
                    //.Add("Authorization", string.Format("Basic={0}", encoded));
                    var data =  client.GetAsync(stsUri).Result;
                     //myttokenStreamoken = await data.Content.ReadAsStringAsync();
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
