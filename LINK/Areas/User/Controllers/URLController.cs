using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINK.Areas.User.Controllers
{
    public class URLController : Controller
    {
        // GET: User/URL
        private CategoryBs objcatbs;
        private UrlBs objurlbs;
        private UserBs objuserbs;
        public URLController()
        {
            objcatbs = new CategoryBs();
            objurlbs = new UrlBs();
            objuserbs = new UserBs();
        }



        public ActionResult Index()
        {
            //LinkHubDbEntities db = new LinkHubDbEntities();
            //ViewBag.CategoryId = new SelectList(db.tbl_Category, "CategoryId", "CategoryName");

            ViewBag.CategoryId = new SelectList(objcatbs.GetALL().ToList(), "CategoryId", "CategoryName");
            ViewBag.UserId = new SelectList(objuserbs.GetAll().ToList(), "UserId", "UserEmail");

            return View();
        }
        [HttpPost]
        public ActionResult Create(tbl_Url objurl)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    objurlbs.Insert(objurl);
                    TempData["Msg"] = "Created Successfully";
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CategoryId = new SelectList(objcatbs.GetALL().ToList(), "CategoryId", "CategoryName");
                    return View("Index");
                }
            }
            catch (Exception e1)
            {
                TempData["Msg"] = "Create Failed : " + e1.Message;
                return RedirectToAction("Index");
            }
        }
    }
}
