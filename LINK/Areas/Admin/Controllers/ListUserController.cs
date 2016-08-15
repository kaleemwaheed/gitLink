﻿using BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LINK.Areas.Admin.Controllers
{
    public class ListUserController : Controller
    {
        // GET: Admin/ListUser
        private AdminBs objBs;
        public ListUserController()
        {
            objBs = new AdminBs();
        }
        public ActionResult Index(string SortOrder, string SortBy, string Page)
        {

            ViewBag.SortOrder = SortOrder;
            ViewBag.OrderBy = SortBy;

            var users = objBs.userBs.GetAll();

            switch (SortBy)
            {
                case "UserEmail":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.UserEmail).ToList();
                            break;
                        default:
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                    }
                    break;
                case "Role":
                    switch (SortOrder)
                    {
                        case "Asc":
                            users = users.OrderBy(x => x.Role).ToList();
                            break;
                        case "Desc":
                            users = users.OrderByDescending(x => x.Role).ToList();
                            break;
                        default:
                            users = users.OrderBy(x => x.UserEmail).ToList();
                            break;
                    }
                    break;
                default:
                    users = users.OrderBy(x => x.UserEmail).ToList();
                    break;

            }
            ViewBag.TotalPages = Math.Ceiling(objBs.userBs.GetAll().Count() / 10.0);


            int page = int.Parse(Page == null ? "1" : Page);
            ViewBag.Page = page;
            users = users.Skip((page - 1) * 10).Take(10).ToList();


            return View(users);
        }

        

    }
}