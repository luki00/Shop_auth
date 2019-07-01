using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Shop_auth.ViewModels
{
    public class BooksViewModel
    {
        public List<BooksListViewModel> List { get; set; }
        public BooksEditViewModel Create { get; set; }
        public BooksListViewModel Details { get; set; }
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
        public string Author { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }

    }

    public class BooksEditViewModel
    {
        public int Id { get; set; }
        [Display(Name = "Okładka")]
        public byte[] Cover { get; set; }
        [Display(Name = "Okładka")]
        public byte[] Photo { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Data wydania")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Autor")]
        public SelectList Author { get; set; }
        [Display(Name = "Kategoria")]
        public SelectList Category { get; set; }
    }
}