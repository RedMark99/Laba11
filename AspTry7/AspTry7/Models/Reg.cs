using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace AspTry7.Models
{
    public class Reg
    {
        [Key]
        public int idReg { get; set; }
        public int idEmp { get; set; }
        public int idPost { get; set; }
        [Required]

        public int WageRate { get; set; }
        public string Status { get; set; }

        [Column(TypeName = "date")]
        public DateTime dateTake { get; set; }

        [Column(TypeName = "date")]
        public DateTime? dateLeave { get; set; }
        public int Price { get; set; }
        public string Desc { get; set; }

        public string MonthOfSalary { get; set; }
        public int YearOfSalary { get; set; }

    }
}