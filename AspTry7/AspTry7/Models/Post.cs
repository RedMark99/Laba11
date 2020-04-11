using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspTry7.Models
{
    public class Post
    {
        [Key]
        public int idPost { get; set; }
        [Required]
        public string name { get; set; }
        public int price { get; set; }
    }
}