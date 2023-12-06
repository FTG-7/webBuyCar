using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;
using PhamMinhNhut_DoAnWeb.Models;
using static System.Net.WebRequestMethods;

namespace PhamMinhNhut_DoAnWeb.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<Product> products = db.Product.ToList();
            return View(products);
        }

        public ActionResult detail(int? id)
        {
            MyDbContext db = new MyDbContext();
            Product products = db.Product.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        public ActionResult Product(int? brandid, string search = "null", string SortColumn = " ", string Iconclass = "fa-sort-asc", int page = 1)
        {
            MyDbContext db = new MyDbContext();

            List<PhamMinhNhut_DoAnWeb.Models.Product> products = db.Product.ToList();
            List<Brand> brands = db.Brand.ToList();
            ViewBag.BR = brands;
           
            string hiddenSearchValue = Request.Form["search"];
            if (!string.IsNullOrEmpty(hiddenSearchValue))
            {
                search = hiddenSearchValue;
            }
            if (search != "null")
            {
               products = db.Product.Where(row => row.ProductName.Contains(search)).ToList();
            }

            if (brandid != null)
            {
                products = db.Product.Where(row => row.Brand.BrandID == brandid).ToList();
            }
            ViewBag.SortColumn = SortColumn;
            ViewBag.Iconclass = Iconclass;
            if (SortColumn == "Price")
            {
                if (Iconclass == "fa-sort-asc")
                    products = products.OrderBy(row => row.Price).ToList();
                else
                    products = products.OrderByDescending(row => row.Price).ToList();
            }
            else if(SortColumn =="Power")
            {
                if (Iconclass == "fa-sort-asc")
                    products = products.OrderBy(row => row.Power).ToList();
                else
                    products = products.OrderByDescending(row => row.Power).ToList();
            }
            int NoOfRecorPerPage = 3; // 3 sp trong 1 trang
            int NoOfPages = Convert.ToInt32(Math.Ceiling(Convert.ToDouble(products.Count) / Convert.ToDouble(NoOfRecorPerPage)));
            int NoOfRecordToShip = (page - 1) * NoOfRecorPerPage;
            ViewBag.Page = page;
            ViewBag.NoOfPage = NoOfPages;
            products = products.Skip(NoOfRecordToShip).Take(NoOfRecorPerPage).ToList();
            return View(products);
        }
        public ActionResult AddImage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddImage(ProductImage image, List<HttpPostedFileBase> uploadFile)
        {
            string abc = "";
            string def = "";
            foreach (var item in uploadFile)
            {

                string filePath = Path.Combine(HttpContext.Server.MapPath("~/Image"), Path.GetFileName(item.FileName));
                item.SaveAs(filePath);

                //abc = string.Format("Upload {0} file thành công", uploadFile.Count);

                //def += item.FileName + "; ";


            }
            //TempData["Msg"] = abc + "</br>" + def;
            return RedirectToAction("Index");
         
        }

        public ActionResult Create()
        {


            return View();
        }
        [HttpPost]
        public ActionResult Create( Product product, List<HttpPostedFileBase> uploadFile)
        {

            MyDbContext db = new MyDbContext();

            db.Product.Add(product);
            db.SaveChanges();
            Product pro = db.Product.ToList().Last();
            ProductImage image= new ProductImage();
            foreach (var item in uploadFile)
            {
                //if (item.ContentLength > 2000000)
                //{
                //    ModelState.AddModelError("Image", "Kích thước file phải nhỏ hơn 2MB.");
                //    return View();
                //}

                //var allowEx = new[] { ".jpg", ".png" };
                //var fileEx = Path.GetExtension(item.FileName).ToLower();
                //if (!allowEx.Contains(fileEx))
                //{
                //    ModelState.AddModelError("Image", "Chỉ chấp nhận file ảnh jpg hoặc png.");
                //    return View();
                //}

                string filePath = Path.Combine(HttpContext.Server.MapPath("~/Images"), Path.GetFileName(item.FileName));
                item.SaveAs(filePath);

                string fileName = item.FileName;
                image.ImageUrl = fileName;
                image.ProductID = pro.ProductID;
                db.ProductImage.Add(image);
                db.SaveChanges();

            }
         
        
      
            db.SaveChanges();
            return RedirectToAction("index");


        }

        public ActionResult Delete(int id)
        {
            MyDbContext db = new MyDbContext();
            Product products = db.Product.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        [HttpPost]
        public ActionResult Delete(int id, Product product)
        {
            MyDbContext db = new MyDbContext();
            Product products = db.Product.Where(row => row.ProductID == id).FirstOrDefault();
            ProductImage image = db.ProductImage.Where(row => row.ProductID == id).FirstOrDefault();
            db.Product.Remove(products);
            db.ProductImage.Remove(image);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
        }
        public ActionResult Edit(int? id)
        {
            MyDbContext db = new MyDbContext();
            Product products = db.Product.Where(row => row.ProductID == id).FirstOrDefault();
            return View(products);
        }
        [HttpPost]
        public ActionResult Edit(int id, Product product)
        {
            MyDbContext db = new MyDbContext();
            Product pr = db.Product.Where(row => row.ProductID == id).FirstOrDefault();

            pr.ProductName = product.ProductName;
            pr.BodyColor = product.BodyColor;
            pr.BodyType = product.BodyType;
            pr.TransmissionType = product.TransmissionType;
            pr.Consumption = product.Consumption;
            pr.Power = product.Power;
            pr.Price = product.Price;
            pr.Fuel = product.Fuel;
            pr.BrandId= product.BrandId;   
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });

        }

    }
}