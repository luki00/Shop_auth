using Shop_auth.Repos;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_auth.Controllers
{
    public class HomeController : Controller
    {
        IBooksRepo booksRepo;

        public HomeController()
        {
            booksRepo = new BooksRepo();
        }
        [AllowAnonymous]
        public ActionResult Index()
        {
            return View(booksRepo.GetBooksListViewModel());
        }


        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}