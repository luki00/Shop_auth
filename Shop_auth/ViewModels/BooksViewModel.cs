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
        public BooksListViewModel Details { get; set; }
    }

    public class BooksListViewModel {
        public int Id { get; set; }
        [Display(Name="Okładka")]
        public byte[] Cover { get; set; }
        [Display(Name = "Okładka")]
        public HttpPostedFileBase File { get; set; }
        [Display(Name = "Tytuł")]
        public string Title { get; set; }
        [Display(Name = "Data wydania")]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "Autor")]
        public string Author { get; set; }
        [Display(Name = "Kategoria")]
        public string Category { get; set; }
        [Display(Name = "Autor")]
        public SelectList SelectAuthor { get; set; }
        [Display(Name = "Kategoria")]
        public SelectList SelectCategory { get; set; }
        [Display(Name = "AutorId")]
        public int AuthorId { get; set; }
        [Display(Name = "KategoriaId")]
        public int CategoryId { get; set; }

    }
}