using Shop_auth.Models;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;


namespace Shop_auth.Repos
{
    public class RolesRepo : IRolesRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        public RolesViewModel GetRolesListViewModel()
        {
            return new RolesViewModel
            {
                List = db.Users.Select(e => new RolesListViewModel
                {
                    UserName = e.UserName,
                    UserId = e.Id
                }).ToList(),

                SelectRoleList = db.Users.Select(e => new SelectRoleViewModel
                {
                    SelectRole = e.Roles
                }).First()
            };
        }

        public bool SetRoleViewModel(RolesViewModel role)
        {
/*
            Basket b = new Basket
            {
                UserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                BookId = BookId,
                Accepted = false,
                BuyTime = DateTime.Now
            };


            db.Baskets.Add(b);
            db.SaveChanges();

    */

            return true;
        }

    }
}