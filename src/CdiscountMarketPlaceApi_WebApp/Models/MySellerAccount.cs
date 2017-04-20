using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace CdiscountMarketPlaceApi_WebApp.Models
{
    public class MySellerAccount
    {
        public string _Username { get; set; }
        public string _Password { get; set; }

        public string _Token { get; set; }
        public int _Sellerid { get; set; }

        public enum _Environment
        {
            Production,
            Preproduction            
        }
        public static IConfigurationRoot Configuration { get; set; }

        public MySellerAccount()
        {
            
            var builder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json");

            Configuration = builder.Build();

            Console.WriteLine($"option1 = {Configuration["option1"]}");
            Console.WriteLine($"option2 = {Configuration["option2"]}");
            Console.WriteLine(
                $"option1 = {Configuration["subsection:suboption1"]}");


        }

        public string GetToken(string username, string password, int environment)
        {
            string token = string.Empty;
            try
            {
                /*switch 
                var environment = _environmentRepository.GetCurrentEnvironment();
                string svcIssue = ConfigurationManager.AppSettings.Get(environment + ".svc");
                string realm = ConfigurationManager.AppSettings.Get(environment + ".realm");

                string encoded = Convert.ToBase64String(Encoding.Default.GetBytes(string.Format("{0}:{1}", username, password)));

                var stsUri = new Uri(string.Format("{0}/?realm={1}", svcIssue, realm));
                var request = (HttpWebRequest)WebRequest.Create(stsUri);

                request.Headers.Add("Authorization", string.Format("Basic={0}", encoded));
                request.Method = "GET";

                var response = request.GetResponse();
                var tokenStream = response.GetResponseStream();

                if (tokenStream != null)
                {
                    var dataContractSerializer = new DataContractSerializer(typeof(string));
                    token = (string)dataContractSerializer.ReadObject(tokenStream);
                }*/
            }
            catch (System.Exception ex)
            {
                var m = ex.Message;
            }

            return token;
        }
    }
}
