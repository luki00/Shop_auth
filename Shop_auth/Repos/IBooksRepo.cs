using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_auth.Repos
{
    public interface IBooksRepo
    {
        BooksViewModel GetBooksListViewModel();
        BooksViewModel GetBooksWithListsViewModel(int? id);
        BooksViewModel GetAuthorCategoryListsViewModel();
        BooksViewModel GetBooksViewModel(int? id);

        bool SetBooksViewModel(BooksViewModel book);
        bool EditBookViewModel(BooksViewModel book);
        bool DeleteBookViewModel(int? id);
    }
}