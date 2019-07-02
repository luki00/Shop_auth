using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Shop_auth.Models;
using Shop_auth.Repos;
using Shop_auth.ViewModels;

namespace Shop_auth.Controllers
{
    public class BooksController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        IBooksRepo booksRepo;

        public BooksController()
        {
            booksRepo = new BooksRepo();
        }

        // GET: Books
        [Authorize(Roles = "Admin")]
        public ActionResult Index()
        {
            
            return View(booksRepo.GetBooksListViewModel());
        }

        // GET: Books/Details/5
        [AllowAnonymous]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksViewModel book = booksRepo.GetBooksViewModel(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        [Authorize(Roles = "Admin")]
        public ActionResult Create()
        {
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name");
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name");
            return View();
            /*
            BooksViewModel lists = booksRepo.GetAuthorCategoryListsViewModel();
            ViewBag.AuthorId = lists.Details.SelectAuthor;
            ViewBag.CategoryId = lists.Details.SelectAuthor;
            */
        return View();
        }


        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Create(BooksViewModel book, int AuthorId, int CategoryId)
        {
            book.Details.AuthorId = AuthorId;
            book.Details.CategoryId = CategoryId;
            booksRepo.SetBooksViewModel(book);

            return RedirectToAction("Index");


            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.Details.AuthorId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", book.Details.CategoryId);
            return View(book);
        }

        // GET: Books/Edit/5
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
             BooksViewModel book = booksRepo.GetBooksViewModel(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            ViewBag.AuthorId = new SelectList(db.Authors, "Id", "Name", book.Details.CategoryId);
            ViewBag.CategoryId = new SelectList(db.Categories, "Id", "Name", book.Details.CategoryId);
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public ActionResult Edit(BooksViewModel book, int AuthorId, int CategoryId)
        {
            book.Details.AuthorId = AuthorId;
            book.Details.CategoryId = CategoryId;

            booksRepo.EditBookViewModel(book);
            return RedirectToAction("Index");
           
        }

        // GET: Books/Delete/5
        [Authorize(Roles = "Admin")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            BooksViewModel book = booksRepo.GetBooksViewModel(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [Authorize(Roles = "Admin")]
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int? id)
        {
            booksRepo.DeleteBookViewModel(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
