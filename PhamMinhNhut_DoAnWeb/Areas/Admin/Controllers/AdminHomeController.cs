using PhamMinhNhut_DoAnWeb.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PhamMinhNhut_DoAnWeb.Models;

namespace PhamMinhNhut_DoAnWeb.Areas.Admin.Controllers
{
    public class AdminHomeController : Controller
    {
        // GET: Admin/AdminHome
        public ActionResult Index()
        {
            MyDbContext db = new MyDbContext();
            List<Product> products = db.Product.ToList();

            MyDbContext br = new MyDbContext();
            List<Brand> Brands = br.Brand.ToList();
            ViewBag.Brands = Brands;
            return View(products);
        }

        public ActionResult TK()
        {
            MyDbContext db = new MyDbContext();
            List<User> user = db.User.ToList();
            return View(user);
        }

        public ActionResult Logout()
        {
            HttpCookie authcookie = new HttpCookie("auth");
            authcookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(authcookie);

            HttpCookie roleCookie = new HttpCookie("role");
            roleCookie.Expires = DateTime.Now.AddDays(-1);
            Response.Cookies.Add(roleCookie);

            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
        }

        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(User user, string retypePassword)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            if (user.Password != retypePassword)
            {
                ModelState.AddModelError("retypePassword", "Passwords do not match.");
                return View();
            }

            MyDbContext db = new MyDbContext();
            User myUser = db.User.Where(u => u.UserName == user.UserName).FirstOrDefault();
            if (myUser != null)
            {
                ModelState.AddModelError("UserName", "UserName already exist.");
                return View();
            }

            myUser = db.User.Where(u => u.EmailAddress == user.EmailAddress).FirstOrDefault();
            if (myUser != null)
            {
                ModelState.AddModelError("EmailAddress", "EmailAddress already exist.");
                return View();
            }

            myUser = new User();
            myUser.UserName = user.UserName;
            myUser.Password = BCrypt.Net.BCrypt.HashPassword(user.Password);
            myUser.EmailAddress = user.EmailAddress;
            myUser.Role = "user";
            db.User.Add(myUser);
            db.SaveChanges();

            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
        }

        public ActionResult DeleteUser(int id)
        {
            MyDbContext db = new MyDbContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult DeleteUser(int id, User us)
        {
            MyDbContext db = new MyDbContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            db.User.Remove(user);
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });
        }

        public ActionResult EditUser(int? id)
        {
            MyDbContext db = new MyDbContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();
            return View(user);
        }
        [HttpPost]
        public ActionResult EditUser(int id, User us)
        {
          

           
            MyDbContext db = new MyDbContext();
            User user = db.User.Where(row => row.UserId == id).FirstOrDefault();

            user.UserName = us.UserName;
            user.EmailAddress = us.EmailAddress;     
            db.SaveChanges();
            return RedirectToAction("Index", "AdminHome", new { area = "Admin" });

        }
    }
}