using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Shop_auth.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        public byte[] Cover { get; set; }
        public string Title { get; set; }
        public DateTime ReleaseDate { get; set; }
       

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public virtual ICollection<Category> Category { get; set; }
        public virtual ICollection<Basket> Baskets { get; set; }
    }
}