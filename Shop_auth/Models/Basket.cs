using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using Microsoft.AspNet.Identity;

namespace Shop_auth.Models
{
    public class Basket
    {
        [Key]
        public int Id { get; set; }
        public bool Accepted { get; set; }
        public DateTime BuyTime { get; set; }


        public virtual ApplicationUser User { get; set; }

        public int BookId { get; set; }
        [ForeignKey("BookId")]
        public Book Book { get; set; }
    }
}