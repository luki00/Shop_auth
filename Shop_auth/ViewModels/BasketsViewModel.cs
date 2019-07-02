using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_auth.ViewModels
{
    public class BasketsViewModel
    {
        public List<BasketsListViewModel> List { get; set; }
        public BasketsListViewModel Details { get; set; }
    }

    public class BasketsListViewModel {
        public int Id { get; set; }
        [Display(Name = "Okładka")]
        public byte[] Cover { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Zaakceptowano")]
        public bool Accepted { get; set; }
        [Display(Name = "Czas utworzenia")]
        public DateTime BuyTime { get; set; }


        [Display(Name = "Użytkownik")]
        public string User { get; set; }
        [Display(Name = "Książka")]
        public int BookId { get; set; }
    }
}