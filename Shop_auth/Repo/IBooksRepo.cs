using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_auth.Repo
{
    public interface IBooksRepo
    {
        BooksViewModel GetBooksListViewModel();
    }
}