using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;


namespace AspTry7.Models
{
    public class Employees
    {
        [Key]
        public int idEmp { get; set; }

        [Required]
        public string name { get; set; }

        public string surname { get; set; }

        public string lastname { get; set; }

        public string gender { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateOfBirth { get; set; }
    }
}