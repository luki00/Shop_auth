using Shop_auth.Models;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Web.Mvc;

namespace Shop_auth.Repos
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
                Author = e.Author.Name + " " + e.Author.LastName,
                Category = e.Category.Name
            }).ToList()

            };
        }


        public BooksViewModel GetAuthorCategoryListsViewModel()
        {

            return new BooksViewModel {

                Create = new BooksEditViewModel
                {
                    Author = new SelectList(db.Authors, "Id", "Name"),
                    Category = new SelectList(db.Categories, "Id", "Name")
                }

            };
        }


        public BooksViewModel GetBooksViewModel(int? id)
        {

            return new BooksViewModel
            {
                Details = db.Books.Where(r => r.Id == id).Select(e => new BooksListViewModel
                {
                    Id = e.Id,
                    Cover = e.Cover,
                    Title = e.Title,
                    ReleaseDate = e.ReleaseDate,
                    Author = e.Author.Name + " " + e.Author.LastName,
                    Category = e.Category.Name
                }).First()

            };
        }



        public bool SetBooksViewModel(BooksEditViewModel book) {

            try {
                /*
                Book b = new Book
                {
                    Id = book.Id,
                    Cover = book.Cover,
                    Title = book.Title,
                    ReleaseDate = book.ReleaseDate,
                    Author = book.Author,
                    Category = book.Category

                }
                */
            } catch { }

            return true;
        }
    }
}