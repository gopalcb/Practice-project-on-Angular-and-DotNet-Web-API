using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace app.data.Domains
{
    public class Hero
    {
        [Key]
        public long Id { get; set; }
        public string Name { get; set; }
    }
}