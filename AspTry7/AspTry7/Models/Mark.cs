using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AspTry7.Models
{
    public class Mark
    {
        public string NamePost { get; set; }
        public System.DateTime? dateTake { get; set; }
        public System.DateTime? dateLeave { get; set; }
        public string Desc   { get; set; }

    }
}