using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PhamMinhNhut_DoAnWeb.Models
{
    public class Brand
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int BrandID { get; set; }
        public string BrandName { get; set;}
        public string CountryOfOrigin { get; set;}
        public virtual ICollection<Product> Products { get; set; }
    }
}