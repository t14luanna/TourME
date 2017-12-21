using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TourMe.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin Page
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ManageUserPage()
        {
            return PartialView();
        }

        public ActionResult ManagePlacePage()
        {
            return PartialView();
        }

        public ActionResult ManagePlaceKindPage()
        {
            return PartialView();
        }

        public ActionResult ManageImagePage()
        {
            return PartialView();
        }

        public ActionResult ManageImageKindPage()
        {
            return PartialView();
        }

        public ActionResult ManageTripBookPage()
        {
            return PartialView();
        }

        public ActionResult ManageTripBookHasPlacePage()
        {
            return PartialView();
        }

        public ActionResult Crawling()
        {
            return PartialView();
        }
    }
}