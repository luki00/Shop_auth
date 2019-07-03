using Shop_auth.Models;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Web.Security;

namespace Shop_auth.Repos
{
    public class RolesRepo : IRolesRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public RolesViewModel GetRolesListViewModel()
        {
            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);

            return new RolesViewModel
            {
                List = db.Users.Select(e => new RolesListViewModel
                {
                    UserName = e.UserName,
                    UserId = e.Id,
                    SelectedRolesNames = db.Roles.Where(r => r.Users.Select(x => x.UserId).Contains(e.Id)).Select(y => y.Name).ToList()
                }).ToList(),

                 AllRoles = db.Roles.Select(e => new SelectRoleListViewModel
                    {
                        RoleName = e.Name,
                        RoleId = e.Id

                    }).ToList()



            };
        }

        public bool SetRoleViewModel(string UserId, string[] RolesIds)
        {

            var userStore = new UserStore<ApplicationUser>(db);
            var userManager = new UserManager<ApplicationUser>(userStore);
            string[] oldRoles = userManager.GetRoles(UserId).ToArray();

            userManager.RemoveFromRoles(UserId, oldRoles);

            userManager.AddToRoles(UserId, RolesIds);


            return true;
        }

    }
}