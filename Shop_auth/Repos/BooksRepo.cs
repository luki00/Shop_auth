using Shop_auth.Models;
using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Data.Entity;
using System.Web.Mvc;
using System.IO;

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

                Details = new BooksListViewModel
                {
                    SelectAuthor = new SelectList(db.Authors, "Id", "Name"),
                    SelectCategory = new SelectList(db.Categories, "Id", "Name")
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

        public BooksViewModel GetBooksWithListsViewModel(int? id)
        {
            SelectList AuthorList = new SelectList(db.Authors, "Id", "Name");
            SelectList CategoryList = new SelectList(db.Categories, "Id", "Name");
            return new BooksViewModel
            {
                Details = db.Books.Where(r => r.Id == id).Select(e => new BooksListViewModel
                {
                    Id = e.Id,
                    Cover = e.Cover,
                    Title = e.Title,
                    ReleaseDate = e.ReleaseDate,
                    Author = e.Author.Name + " " + e.Author.LastName,
                    Category = e.Category.Name,
                    SelectAuthor = AuthorList,
                    SelectCategory = CategoryList
                }).First()

            };
        }

        public bool SetBooksViewModel(BooksViewModel book) {


            Book b = new Book
                {
                    Id = book.Details.Id,
                    Title = book.Details.Title,
                    ReleaseDate = book.Details.ReleaseDate,
                    AuthorId = book.Details.AuthorId,
                    CategoryId = book.Details.CategoryId
                };

            byte[] bytes;

            if (book.Details.File != null && book.Details.File.ContentLength > 0)
            {

                using (BinaryReader br = new BinaryReader(book.Details.File.InputStream))
                {
                    bytes = br.ReadBytes(book.Details.File.ContentLength);
                }
                b.Cover = bytes;
            }

            

            db.Books.Add(b);
            db.SaveChanges();
                 


            return true;
        }




        public bool EditBookViewModel(BooksViewModel book)
        {

            Book b = db.Books.Find(book.Details.Id);
            b.Title = book.Details.Title;
            b.ReleaseDate = book.Details.ReleaseDate;
            b.AuthorId = book.Details.AuthorId;
            b.CategoryId = book.Details.CategoryId;


            byte[] bytes;

            if (book.Details.File != null && book.Details.File.ContentLength > 0)
            {

                using (BinaryReader br = new BinaryReader(book.Details.File.InputStream))
                {
                    bytes = br.ReadBytes(book.Details.File.ContentLength);
                }
                b.Cover = bytes;
            }
            //throw new HttpException(404, "Not found");
            db.SaveChanges();



            return true;
        }


        public bool DeleteBookViewModel(int? id)
        {

            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return true;
        }
    }
}