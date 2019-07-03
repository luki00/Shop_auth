using Shop_auth.Repos;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_auth.Controllers
{
    public class RolesController : Controller
    {

        IRolesRepo rolesRepo;

        public RolesController()
        {
            rolesRepo = new RolesRepo();
        }
        // GET: Roles
        public ActionResult Index()
        {
            return View(rolesRepo.GetRolesListViewModel());
        }

       

        // POST: Roles/Index/5
        [HttpPost]
        public ActionResult Index(string UserId, string[] RolesIds)
        {
                rolesRepo.SetRoleViewModel(UserId, RolesIds);

                return RedirectToAction("Index");


        }
        
        
    }
}
