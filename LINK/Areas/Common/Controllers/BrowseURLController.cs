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
        public ActionResult Index(String SortOrder,String SortBy)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.SortBy = SortBy;
            var urls = objurlbs.GetALL().Where(x => x.IsApproved=="A").ToList();
            switch (SortOrder)
            {
                case "Asc":
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;
                case "Desc":
                    urls = urls.OrderByDescending(x => x.UrlTitle).ToList();
                    break;
                default:
                    break;
                    
            }//
            return View(urls);
        }
    }
}