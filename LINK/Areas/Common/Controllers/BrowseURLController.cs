using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINK.Areas.Common.Controllers
{
    public class BrowseURLController : Controller
    {
        private UrlBs objurlbs;
        public BrowseURLController()
        {
            objurlbs = new UrlBs();

        }

        // GET: Common/BrowseURL
        public ActionResult Index()
        {
            var urls = objurlbs.GetALL();
            return View(urls);
        }
    }
}