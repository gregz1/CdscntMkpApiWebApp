using Microsoft.AspNetCore.Mvc;
using CdiscountMarketPlaceApi_WebApp.Models;
using CdiscountMarketPlaceApi_WebApp.Models.OfferManager;
using Microsoft.AspNetCore.Http;
using CdiscountMarketPlaceApi_WebApp.Enumeration;
using System;

// For more information on enabling MVC for empty projects, visit http://go.microsoft.com/fwlink/?LinkID=397860

namespace CdiscountMarketPlaceApi_WebApp.Controllers
{
    public class OfferManagerController : Controller
    {
        // GET: /<controller>/
        const string SessionLogin = "_Login";
        const string SessionToken = "_Token";
        const string SessionEnvironment = "_Environment";

       // OfferManager _OfferManager;
        //Autentication _Autentication;
        /*public IActionResult Index()
        {
            _OfferManager = new OfferManager();
            return View(__OfferManager);
        }*/

        public IActionResult Welcome()
        {
            //ViewData["Message"] = "Hello " + name;
            //ViewData["NumTimes"] = numTimes;

            return View();
        }

        public void GetSessionData(ref Request MyRequest)
        {
            if (HttpContext.Session.GetString(SessionToken) != null)
            {
                MyRequest._Login = HttpContext.Session.GetString(SessionLogin);
                MyRequest._Token = HttpContext.Session.GetString(SessionToken);
                MyRequest._EnvironmentSelected = (EnvironmentEnum)Enum.Parse(typeof(EnvironmentEnum), HttpContext.Session.GetString(SessionEnvironment));
            }

        }
        public void SetSessionData(Request MyRequest)
        {
            if (MyRequest != null)
            {
                HttpContext.Session.SetString(SessionLogin, MyRequest._Login);
                HttpContext.Session.SetString(SessionToken, MyRequest._Autentication._Token);
                HttpContext.Session.SetString(SessionEnvironment, MyRequest._EnvironmentSelected.ToString());
            }
        }
        public ActionResult SubmitOfferPackageRequest()
        {
            Request MyRequest = new SubmitOfferPackageRequest();
            GetSessionData(ref MyRequest);
            return View(MyRequest);
        }
        [HttpPost]
        public ActionResult SubmitOfferPackageMessage(SubmitOfferPackageRequest MyRequest)
        {
            MyRequest.GetHeaderMessage();
            SetSessionData(MyRequest);
            return View(new SubmitOfferPackageMessage(MyRequest));
        }
        public ActionResult GetOfferListPaginatedRequest()
        {
            Request MyRequest = new GetOfferListPaginatedRequest();
            if (HttpContext.Session.GetString(SessionToken) != null)
            {
                MyRequest._Login = HttpContext.Session.GetString(SessionLogin);
                MyRequest._Token = HttpContext.Session.GetString(SessionToken);
                MyRequest._EnvironmentSelected = (EnvironmentEnum)Enum.Parse(typeof(EnvironmentEnum), HttpContext.Session.GetString(SessionEnvironment));
            }
            return View(MyRequest);
        }
        [HttpPost]
        public ActionResult GetOfferListPaginatedMessage(GetOfferListPaginatedRequest MyRequest)
        {
            MyRequest.GetHeaderMessage();
            SetSessionData(MyRequest);
            return View(new GetOfferListPaginatedMessage(MyRequest));
        }
        public ActionResult GetOfferListRequest()
        {
            Request MyRequest = new GetOfferListRequest();
            if (HttpContext.Session.GetString(SessionToken) != null)
            {
                MyRequest._Login = HttpContext.Session.GetString(SessionLogin);
                MyRequest._Token = HttpContext.Session.GetString(SessionToken);
                MyRequest._EnvironmentSelected = (EnvironmentEnum)Enum.Parse(typeof(EnvironmentEnum), HttpContext.Session.GetString(SessionEnvironment));
            }
            return View(MyRequest);
        }
        [HttpPost]
        public ActionResult GetOfferListMessage(GetOfferListRequest MyRequest)
        {
            MyRequest.GetHeaderMessage();
            SetSessionData(MyRequest);
            return View(new GetOfferListMessage(MyRequest));
        }

       
        public ActionResult GetOfferPackageSubmissionResultRequest()
        {
            Request MyRequest = new GetOfferPackageSubmissionResultRequest();
            GetSessionData(ref MyRequest);
            return View(MyRequest);
        }

        [HttpPost]
        public ActionResult GetOfferPackageSubmissionResultMessage(GetProductListRequest MyRequest)
        {
            MyRequest.GetHeaderMessage();
            SetSessionData(MyRequest);
            return View(new GetOfferPackageSubmissionResultMessage(MyRequest));
        }

        
    }
}
