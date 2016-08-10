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
        public ActionResult Index(String SortOrder,String OrderBy,String Page)
        {
            ViewBag.SortOrder = SortOrder;
            ViewBag.OrderBy = OrderBy;
            
            var urls = objurlbs.GetALL().Where(x => x.IsApproved=="A").ToList();
            switch (OrderBy)
            {
            case "Title":
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
                    }

                    break;
               case "Url":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.Url).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.Url).ToList();
                            break;
                        default:
                            break;
                    }

                    break;
               case "UrlDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.UrlDesc).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.UrlDesc).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                case "CategoryNAme":
                    switch (SortOrder)
                    {
                        case "Asc":
                            urls = urls.OrderBy(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        case "Desc":
                            urls = urls.OrderByDescending(x => x.tbl_Category.CategoryName).ToList();
                            break;
                        default:
                            break;
                    }
                    break;

                default:
                    urls = urls.OrderBy(x => x.UrlTitle).ToList();
                    break;

            }

            ViewBag.TotalPages = Math.Ceiling(objurlbs.GetALL().Where(x => x.IsApproved == "A").Count() / 10.0);


            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            urls = urls.Skip((page - 1) * 10).Take(10).ToList();


            return View(urls);
        }
    }
}