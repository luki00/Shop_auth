using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Shop_auth.ViewModels
{
    public class BooksViewModel
    {
        public List<BooksListViewModel> List { get; set; }
    }

    public class BooksListViewModel {
        public int Id { get; set; }
        [Display(Name="Okładka")]
        public byte[] Cover { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Data wydania")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Autor")]
        public String Author { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

    }
}