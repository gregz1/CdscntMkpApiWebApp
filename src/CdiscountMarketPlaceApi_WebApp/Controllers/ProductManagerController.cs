using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using CdscntMkpApiReference_Prod;
using CdiscountMarketPlaceApi_WebApp.Models;


// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CdiscountMarketPlaceApi_WebApp.Controllers
{
    public class ProductManagerController : Controller
    {
        // GET: /<controller>/

        ProductManager _ProductManager;
        //Autentication _Autentication;
        public IActionResult Index()
        {
            _ProductManager = new ProductManager();
            return View(_ProductManager);
        }

        public IActionResult Welcome()
        {
            //ViewData["Message"] = "Hello " + name;
            //ViewData["NumTimes"] = numTimes;

            return View();
        }
       
        public ActionResult GetAllAllowedCategoryTreeRequest()
        {
            return View(new GetAllAllowedCategoryTreeRequest());
        }
        [HttpPost]
        public ActionResult GetAllAllowedCategoryTreeMessage(GetAllAllowedCategoryTreeRequest MyGetAllAllowedCategoryTreeRequest)
        {
           return View(new GetAllAllowedCategoryTreeMessage( MyGetAllAllowedCategoryTreeRequest.GetHeaderMessage()));          

        }        


        public ActionResult SubmitProductPackageRequest()
        {
            //Task<OfferIntegrationReportMessage> MyOfferIntegrationReportMessage = SubmitOfferPackageCasino();

            return View(new SubmitProductPackageRequest());

        }
        
        [HttpPost]
        public ActionResult SubmitProductPackageMessage(SubmitProductPackageRequest MySubmitProductPackageRequest)
        {
            return View(new SubmitProductPackageMessage(MySubmitProductPackageRequest.GetHeaderMessage(),MySubmitProductPackageRequest._Parameters["Values"]));

        }

        public ActionResult GetProductListRequest()
        {
          
            return View(new GetProductListRequest());

        }

        [HttpPost]
        public ActionResult GetProductListMessage(GetProductListRequest MyGetProductListRequest)
        {
            return View(new GetProductListMessage(MyGetProductListRequest.GetHeaderMessage(), MyGetProductListRequest._Parameters["Values"]));

        }

        public ActionResult GetProductListByIdentifierRequest()
        {

            return View(new GetProductListByIdentifierRequest());

        }

        [HttpPost]
        public ActionResult GetProductListByIdentifierMessage(GetProductListByIdentifierRequest MyGetProductListByIdentifierRequest)
        {
            return View(new GetProductListByIdentifierMessage(MyGetProductListByIdentifierRequest.GetHeaderMessage(), MyGetProductListByIdentifierRequest._Parameters));

        }

        public ActionResult GetProductPackageSubmissionResultRequest()
        {
            return View(new GetProductPackageSubmissionResultRequest());
        }

        [HttpPost]
        public ActionResult GetProductPackageSubmissionResultMessage(GetProductListRequest MyGetProductListRequest)
        {
            return View(new GetProductPackageSubmissionResultMessage(MyGetProductListRequest.GetHeaderMessage(), MyGetProductListRequest._Parameters["Values"]));
        }

        public ActionResult GetBrandListRequest()
        {
            return View(new GetBrandListRequest());
        }

        [HttpPost]
        public ActionResult GetBrandListMessage(GetBrandListRequest MyGetBrandListRequest)
        {
            return View(new GetBrandListMessage(MyGetBrandListRequest.GetHeaderMessage()));
        }

        /*
         public  ActionResult GetAllModelLisRequest() { }
         public  ActionResult GetModelListRequest() { }
         public  ActionResult GetProductPackageSubmissionResultRequest() { }
         public ActionResult GetProductPackageMatchingFileDataRequest() { }
         */

        /*   public async Task<OfferIntegrationReportMessage> SubmitOfferPackageCasino()

             {
                 Dictionary<HeaderMessage, OfferPackageRequest> rattrapageCasino = new Dictionary<HeaderMessage, OfferPackageRequest>();
                 var MarketplaceAPIService = new CdscntMkpApiReference_Prod.MarketplaceAPIServiceClient();
                 rattrapageCasino.Add(GetHeaderMessageAPI("3dc02f9c28b745179ce8aa68c0fa198b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_05340.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("806e5735ec1243e99bfb0798bfd4a516"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_01341.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("e7a9aa5f32a84406b1e1acc1d91b046e"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_05244.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("8db049d0c9c54392930504f43c581a17"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_06312.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("4ddfb0ce8be8445ea298a1afbf98786a"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_06829.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ee56e6a78daa4761bc8e277516ab9004"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_07317.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("916456fde63f486aa0db4d1d9aa3ea89"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_08919.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("a86c9285872543b5b98a964576fb4ca7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_10201.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("1a1562288ce74557981d1a63fd8222e8"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_11332.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("35e60b533bab470d863201fee9983636"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_11828.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("7ac8f65bf2ad45b285bc76ad05a141c9"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_11843.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("2e282a3896ad4b16befc7b5046e96def"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_11844.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f9c32045624648d1ad37fd137c715367"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_12335.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("c9f48e21944c466fa5996c19150cb3f9"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_12846.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f0fac60f6dd34505a6b96ceceb4e8695"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_12851.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("978d0bc0a1e14fb1bf4741cf84fdbe39"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13314.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("296f9a5336d8415f888f1c1ecd2c2857"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13800.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("92d71139783f46e389f3a33e73af273c"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13805.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("4a02a20f175f4f638a6dae34a9f412a1"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13819.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("633d5f5bebbf489aa6c394763cf21d92"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13840.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("73767ffa3fe245fdbb831583b7e030be"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_13852.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("0b208036156546188d87a4f62da11ab7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_15333.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("81f270823fac4cabb661f3e49bbaf0db"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_16331.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("4e92326c473c4b94bacb6049e9c476e4"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_18236.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("57d106df3628433da4370714ccb00d4f"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_19330.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("9a82df47faf34f8f8504c72652a2a291"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_21834.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ce47c486b31c42f69dfa013e6f38443b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_21837.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("3fee343adc134d368a7315270eeb30f4"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_22300.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("78ffebe63e214de0a083b6822da89554"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_22304.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("abce7dd3c6034ff5861eb13527afabc2"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_25801.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ef653ff72c7c4e19aad496e2240e66a7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_25803.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("519ddd8057ad4aa4957b0fbc517ea06f"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_25838.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("9ecb051fa7d9474ca6bf5a6f28d2c816"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_26315.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("37069d4981614e519158203533ba17a0"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_26316.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("3d93d7578aaf4a59a0aafaebbf895e3b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_26839.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("1ee5c2878a6f46e7b34392ea84ec772c"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_26859.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("2eb394835df449558adc7c069518e0ea"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_28320.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("72e423c2a9144c109a6f530d74217ec2"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_29301.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("64d869946b0d4b2086d1fd885cbe1f32"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_29302.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("8b236c97886f4247b937e83f27ff5eda"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_29307.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("9ae2b18985f4493f976f2e3da4921988"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_31845.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("4b3d135aef6d459ebc0f35a7bdd2c88f"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_31850.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("dbb4b512e7cb47a0bb77860f55d4a0eb"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_33334.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("0b68c93d003f4335875735dccbb5c36b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_33848.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("1781157bb07e4a16951885c0ce6fcb6f"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_33880.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("63a6dbef37ec457e80e383da58e5b4e1"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_34210.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("7663cffad85d4a8099f3b11461b970b2"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_34738.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("6f4a218de23c473c9a821b276893732a"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_34810.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("aeb239c41ca345a984ee774c8897665d"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_34811.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("53a478753476434fa496dd24b8cfe609"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_35303.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("e625f47e9af24d44b830ea87c00eba71"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_37208.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("90839f2efbe04a738f0727e460487b62"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_38206.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("c42e138a41d64c19ac9e35a32cd0df04"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_38336.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("b14f5f7f3e194c10840940691f1b7f0e"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_38337.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ba04a5224b4d47ec84735523aa7b33ad"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_39807.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("370ace8a638f4ccc89f64dcba8a92db6"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_39808.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("caf4417a47374c9c9c18474e5daacdcd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_42311.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("e498e603e41149adba24861504ded1aa"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_42830.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("25650dcd4694455b9d87b51adc553c2c"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_42889.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("40e30fdad42a4f02af3ea3968d0dc43b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_43313.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("dc50d147c5af4ee5a6e8bccfa11d3e5e"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_44281.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("7520bd0e3da94310b12638f1287ca4eb"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_44324.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("635a9ccf3e894ae8ab4eaf2270d7a0dd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_45203.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("2485889493cf4d169d509041349614b5"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_47818.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("d9cc0c455c834620958bb32459c398ec"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_47847.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("079173d82b764b2790c8e4c3c3372aba"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_49209.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ec0e180078e149e395bbd4517e070c10"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_49318.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("75728bee60e24fa59afa64e4d3279dd7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_49350.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("64d69eecc6844396be2baa5f830fed89"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_50566.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("e4be8dcfdb54455194154259cc383656"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_52804.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("4962c1bdc93341c9ae9407b87a88c2f6"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_56305.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("a2d4f27250fe43f9bc34b5e4fccd004d"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_56306.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f0eb29997bbf4891938d38d4e233ff9b"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_58202.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("b89e3472a918441a89c3a1f02dac2397"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_63815.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("0dc8552c751a4e0ab276af196b836e25"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_64853.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("da510cfd75934e1b8246650d211aab78"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_64890.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("ef711cc435504b158f29bc0faea1ecc6"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_65827.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("01b08f1bf46e4029887abf645add75fc"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_68809.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("d18f20ad0cfd40f8b65bdf05fb33d014"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_69879.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("fb7de738094245d3b46f185b67f6cda8"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_71831.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("2ac6c4a8d8ec4d42af92bd2aa2006afd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_71833.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("891044071d46405e9fd17f6dd65bbd5a"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_71836.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f39fb7279c82404ba24db85734f8b43e"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_73338.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("faed7af059d94f8583a3acddc24b8300"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_73342.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("a7ae237c98374b60ae309a059002a10e"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_74339.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("038802b5e47e49f3813b9ac64e1d0156"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_74343.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("5f079cf246814f6381a7dd3d68789acd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75167.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f41dfb7d06954215a98d8fc637fdb5d8"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75272.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("5f94528326274629b715bc78378f2ccd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75327.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("8e874571d9ce4708b89aee54abaf1ac7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75370.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("0459cbcdf4194cf9a4ffaff3fbc439b1"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75385.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("fc5f0cfbd4f840448cd3b30f2c1be018"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_75922.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("66278ba0de1f4945ba896dfdf04d64da"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_79322.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("384c48a3db3340929aaaae8cd25df712"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_80205.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("1a148f234c2d4335906ee05d6c8e9494"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_81824.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("e28ea2a2b8664a2c8e396bfd4ac03875"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_81826.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("55bc926fc5bf432cbe6be5e0872939bd"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_82857.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f7941ad93ba3406f8d86f1f2e879a98f"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_83820.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("d042207eabe649b98c7f9412958a8e66"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_83835.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("bbf01382c3b84aa0b18bc6d0884703ed"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_83863.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("006b2eb9c8ba4b5aa0efc04629d4f1b0"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_84862.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("a7b0d728c0574289a43fdf16d3e751d4"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_85323.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("657851bcd6de45938248a52753afc95a"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_86319.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("6527e75f36b44bdd8e7209767deb26a0"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_87329.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("8a866007c9f1481ca401a3f589f85e4d"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_88832.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("f878ff9ff694434ea52e188da8c50c20"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_89841.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("319a976541b04fd99848656561a126d7"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_91328.zip" });
                 rattrapageCasino.Add(GetHeaderMessageAPI("3d0c7aa0a78247dd9912bb86dd586915"), new OfferPackageRequest() { ZipFileFullPath = "\\\\cdnas04.cdweb.biz\\MarketPlace_RCT\\Reno\\Casino1\\IMA_OFFERS_STOCK_PRICE_92925.zip" });

                 OfferIntegrationReportMessage result = new OfferIntegrationReportMessage();
                 foreach (var maj in rattrapageCasino)
                 {
                     try
                     { result = await MarketplaceAPIService.SubmitOfferPackageAsync(maj.Key, maj.Value); }
                     catch (System.Exception ex)
                     {
                         result.ErrorMessage = ex.Message;
                     }

                 }
                 return result;
             } */

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
        private static HeaderMessage GetHeaderMessageAPI(string token)
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
                    TokenId = token
                },
                Version = "1.0"
            };
        }
    }
}
