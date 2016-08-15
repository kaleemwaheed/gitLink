using BLL;
using BOL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINK.Areas.Admin.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Admin/Category
        private CategoryBs objBs;
        public CategoryController()
        {
            objBs = new CategoryBs();
        }
        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult create(tbl_Category category)
        {


            try
            {
                if (ModelState.IsValid)
                {
                    objBs.Insert(category);
                    TempData["Msg"] = "Inserted Sucessfully";
                    return RedirectToAction("index");
                }else
                {
                    return View("index");
                }
            }


            catch (Exception e1)
            {


                TempData["Msg"] = "Created Failed" + e1.Message;
                return RedirectToAction("index");
            }

          
        }

    }
}