using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PhamMinhNhut_DoAnWeb.Models
{
    public class ProductImage
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ImageId { get; set; }
        public string ImageUrl { get; set; }

        public int ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}