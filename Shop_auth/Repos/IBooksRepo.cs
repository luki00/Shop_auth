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
        bool SetBooksViewModel(BooksEditViewModel book);
        BooksViewModel GetAuthorCategoryListsViewModel();
        BooksViewModel GetBooksViewModel(int? id);
    }
}