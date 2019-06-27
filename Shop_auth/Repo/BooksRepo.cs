using Shop_auth.Models;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace Shop_auth.Repo
{
    public class BooksRepo : IBooksRepo
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public BooksViewModel GetBooksListViewModel() {

            return new BooksViewModel
            { List = db.Books.Select(e => new BooksListViewModel
            {
                Id = e.Id,
                Cover = e.Cover,
                Title = e.Title,
                ReleaseDate = e.ReleaseDate,
                Author = e.Author.Name + e.Author.LastName,
                Category = e.Category.FirstOrDefault().Name
            }).ToList()

            };
        }
    }
}