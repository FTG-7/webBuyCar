using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations.Schema;
namespace PhamMinhNhut_DoAnWeb.Models
{
    public class Carts
    {
        [Key]
        public int CartID { get; set; }

        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public virtual Product Product { get; set; }
    }
}