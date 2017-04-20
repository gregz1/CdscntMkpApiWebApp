using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
//using MarketplaceAPIServiceReference;
//using CdscntMkpAPIServiceReference1;
using System.Runtime.CompilerServices;
using CdscntMkpApiReference_Prod;
using CdiscountMarketPlaceApi_WebApp.Models;

namespace CdiscountMarketPlaceApi_WebApp.Controllers
{
    public class GetAllAllowedCategoryTreeController : Controller
    {

         public ActionResult Index(string Token)
        {
            return View(new MyCategoryTreeMessage(Token));
        }
    

        public IActionResult Welcome(string name, int numTimes = 1)
        {
            ViewData["Message"] = "Hello " + name;
            ViewData["NumTimes"] = numTimes;

            return View();
        }
        public async Task<CategoryTreeMessage> ProductActions(string ProductMethod)
        {
            //return View();
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            HeaderMessage MyHeaderMessage = GetDefaultHeaderMessage();

            switch (ProductMethod)
            {

                case "GetAllAllowedCategoryTree":
                    return await MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage);
                    break;
                    /*  case "GetAllowedCategoryTree":
                          break;
                      case "GetModelList":
                          break;
                      case "GetAllModelList":
                          break;
                      case "GetProductList":
                          break;
                      case "SubmitProductList":
                          break;
                      case "GetProductPackageSubmissionResult":
                          break;
                      case "GetProductPackageProductMatchingFileData":
                          break;*/

            }
            return await MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage);

        }


        public async Task<CategoryTreeMessage> GetAllAllowedCategoryTree()
        {
            var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
            CdscntMkpApiReference_Prod.HeaderMessage MyHeaderMessage = GetDefaultHeaderMessage();
            //MarketplaceAPIService.Endpoint.Address.Uri.AbsoluteUri = "https://wsvc.cdiscount.com/MarketplaceAPIService.svc";
            int len = 1111;
            //Task[] tasks = new Task[1];
            //tasks[0] = await MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage);
            //  try { len = ((await MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage)).ToString()).Length; }


            return await MarketplaceAPIService.GetAllAllowedCategoryTreeAsync(MyHeaderMessage);
        }


        private static HeaderMessage GetDefaultHeaderMessage()
        {
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
                    TokenId = "adb79e2bce38495eb453eddd31b4790f"
                },
                Version = "1.0"
            };
        }

    }
}
