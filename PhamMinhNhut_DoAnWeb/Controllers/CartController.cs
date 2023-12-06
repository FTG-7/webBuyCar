using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhamMinhNhut_DoAnWeb.Models;
namespace PhamMinhNhut_DoAnWeb.Controllers
{
    public class CartController : Controller
    {
        // GET: Cart
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<Carts> carts = db.Carts.ToList();
            return View(carts);
        }
        public ActionResult Add(int? id)
        {
            if (id.HasValue)
            {
                MyDbContext db = new MyDbContext();
                Carts cartitem = db.Carts.Where(row => row.ProductID == id).FirstOrDefault();
                if (cartitem != null)
                {
                    cartitem.Quantity += 1;
                }
                else
                {
                    Carts cart = new Carts();
                    cart.ProductID = (int)id;
                    cart.Quantity = 1;
                    db.Carts.Add(cart);
                }
                db.SaveChanges();
            }
            return RedirectToAction("index");
        }
        public ActionResult UpdateQuantity(int quan,int proid) 
        {
            MyDbContext db = new MyDbContext();
            if(quan>0)
            {
                Carts carts = db.Carts.Where(row => row.ProductID == proid).FirstOrDefault();
                if(carts != null)
                {
                    carts.Quantity = quan;
                    db.SaveChanges();
                }
            }
            return RedirectToAction("index");
        }
    }
}