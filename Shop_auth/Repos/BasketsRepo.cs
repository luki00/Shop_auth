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

            string UserId = System.Web.HttpContext.Current.User.Identity.GetUserId();
            return new BasketsViewModel
            { List = db.Baskets.Where(r => r.UserId == UserId).Select(e => new BasketsListViewModel
            {
                Id = e.Id,
                Cover = e.Book.Cover,
                Title = e.Book.Title,
                Accepted = e.Accepted,
                BuyTime = e.BuyTime
            }).ToList()

            };
        }



        public BasketsViewModel GetBasketViewModel(int? id)
        {

            return new BasketsViewModel
            {
                Details = db.Baskets.Where(r => r.Id == id).Select(e => new BasketsListViewModel
                {
                    Id = e.Id,
                    Cover = e.Book.Cover,
                    Title = e.Book.Title,
                    Accepted = e.Accepted,
                    BuyTime = e.BuyTime
                }).First()

            };
        }

        public bool SetBasketsViewModel(int BookId)
        {

            Basket b = new Basket
            {
                UserId = System.Web.HttpContext.Current.User.Identity.GetUserId(),
                BookId = BookId,
                Accepted = false,
                BuyTime = DateTime.Now
            };


            db.Baskets.Add(b);
            db.SaveChanges();



            return true;
        }




        public bool AcceptBasketkViewModel(int id)
        {

            Basket b = db.Baskets.Find(id);
            b.Accepted = true;

            db.SaveChanges();



            return true;
        }


        public bool DeleteBasketViewModel(int? id)
        {

            Basket basket = db.Baskets.Find(id);
            db.Baskets.Remove(basket);
            db.SaveChanges();
            return true;
        }
    }
}