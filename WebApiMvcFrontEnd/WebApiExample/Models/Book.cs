using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiExample.Models
{
    public class Book
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        public string Title { get; set; }
        public string Authers { get; set; }

        [Column("Year")]
        [Display(Name = "Publish Year")]
        public string publishYear { get; set; }

        [Column("Price")]
        [Display(Name = "Price")]
        public decimal BasePrice { get; set; }
    }
}