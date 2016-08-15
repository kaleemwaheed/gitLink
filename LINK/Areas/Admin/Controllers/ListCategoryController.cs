using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BLL;
using System.Web.Mvc;

namespace LINK.Areas.Admin.Controllers
{
    public class ListCategoryController : Controller
    {
        // GET: Admin/ListCategory
        private CategoryBs objBs;
        public ListCategoryController()
        {
            objBs = new CategoryBs();
        }

        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {
            ViewBag.sortOrder = SortOrder;
            ViewBag.sortBy = SortBy;

            var category = objBs.GetALL().ToList();





            switch (SortBy)
            {
                case "CategoryName":
                    switch (SortOrder)
                    {
                        case "Asc":
                            category = category.OrderBy(x => x.CategoryName).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryName).ToList();
                            break;
                        default:
                            category = category.OrderBy(x => x.CategoryName).ToList();
                            break;
                    }
                    break;
                case "CategoryDesc":
                    switch (SortOrder)
                    {
                        case "Asc":
                            category = category.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                        case "Desc":
                            category = category.OrderByDescending(x => x.CategoryDesc).ToList();
                            break;
                        default:
                            category = category.OrderBy(x => x.CategoryDesc).ToList();
                            break;
                    }
                    break;
                default:
                    category = category.OrderBy(x => x.CategoryName).ToList();
                    break;

            }
            ViewBag.TotalPages = Math.Ceiling(objBs.GetALL().Count() / 10.0);


            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.page = page;
            category = category.Skip((page - 1) * 10).Take(10).ToList();



            return View(category);
        }

        public ActionResult Delete(int Id)
        {
            try
            {
                objBs.Delete(Id);
                TempData["Msg"] = "Deleted Sucessfully";
                return RedirectToAction("index");
            }


            catch (Exception e1)
            {


                TempData["Msg"] = "Deletion Failed" + e1.Message;
                return RedirectToAction("index");
            }

        }
    }

}
