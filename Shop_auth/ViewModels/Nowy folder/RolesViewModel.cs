using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_auth.ViewModels
{
    public class RolesViewModel
    {
        public List<RolesListViewModel> List { get; set; }
        public SelectRoleViewModel SelectRoleList { get; set; }
        public RolesListViewModel Details { get; set; }
    }

    public class RolesListViewModel {
        public int RoleId { get; set; }
        [Display(Name = "Rola")]
        public int RoleName { get; set; }
        public string UserId { get; set; }
        [Display(Name = "Użytkownik")]
        public string UserName { get; set; }

    }


    public class SelectRoleViewModel
    {
        [Display(Name = "Rola")]
        public ICollection<Microsoft.AspNet.Identity.EntityFramework.IdentityUserRole> SelectRole { get; set; }

    }
}