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
    public class BasketsRepo : IBasketsRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public BasketsViewModel GetBasketsListViewModel() {

            return new BasketsViewModel
            { List = db.Baskets.Where(r => r.User == System.Web.HttpContext.Current.User.Identity.Name).Select(e => new BasketsListViewModel
            {
                Id = e.Id,
                Cover = e.Book.Cover,
                Title = e.Book.Title,
                Accepted = e.Accepted,
                BuyTime = e.BuyTime
            }).ToList()

            };
        }

        
    }
}