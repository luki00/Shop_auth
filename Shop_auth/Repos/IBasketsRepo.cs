using Shop_auth.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Shop_auth.Repos
{
    public interface IBasketsRepo
    {
        BasketsViewModel GetBasketsListViewModel();

        BasketsViewModel GetBasketViewModel(int? id);
        bool SetBasketsViewModel(int BookId);
        bool AcceptBasketkViewModel(int id);
        bool DeleteBasketViewModel(int? id);
    }
}