//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using UserManagement.Models;

//namespace UserManagement.Controllers
//{
//    public class AccountController : Controller
//    {
//        public ActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Register(User user)
//        {
//            if (UserRepository.GetUser(user.Username) != null)
//            {
//                ViewBag.Message = "Username already exists!";
//                return View();
//            }

//            UserRepository.AddUser(user);
//            ViewBag.Message = "Registration successful!";
//            return View();
//        }

//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Login(string username, string password)
//        {
//            var user = UserRepository.GetUser(username);
//            if (user != null && user.Password == password)
//            {
//                Session["Username"] = username;
//                return RedirectToAction("Index", "Home");
//            }

//            ViewBag.Message = "Invalid username or password!";
//            return View();
//        }

//        public ActionResult Logout()
//        {
//            Session.Abandon();
//            return RedirectToAction("Login");
//        }
//    }
//}



/////******************88
//using System.Web.Mvc;
//using UserManagement.Models;

//namespace UserManagement.Controllers
//{
//    public class AccountController : Controller
//    {
//        public ActionResult Register()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Register(User user)
//        {
//            if (ModelState.IsValid)
//            {
//                if (UserRepository.GetUser(user.Username) != null)
//                {
//                    ViewBag.Message = "Username already exists!";
//                    return View();
//                }

//                user.Password = EncryptPassword(user.Password); // Encrypt password
//                UserRepository.AddUser(user);
//                ViewBag.Message = "Registration successful!";
//                return View();
//            }
//            return View(user);
//        }

//        public ActionResult Login()
//        {
//            return View();
//        }

//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public ActionResult Login(string username, string password)
//        {
//            var user = UserRepository.GetUser(username);
//            if (user != null && user.Password == EncryptPassword(password))
//            {
//                Session["Username"] = username;
//                return RedirectToAction("Index", "Home");
//            }

//            ViewBag.Message = "Invalid username or password!";
//            return View();
//        }

//        public ActionResult Logout()
//        {
//            Session.Abandon();
//            return RedirectToAction("Login");
//        }

//        private string EncryptPassword(string password)
//        {
//            // Implement a password encryption method
//            using (var sha256 = System.Security.Cryptography.SHA256.Create())
//            {
//                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
//                var builder = new System.Text.StringBuilder();
//                foreach (var b in bytes)
//                {
//                    builder.Append(b.ToString("x2"));
//                }
//                return builder.ToString();
//            }
//        }
//    }
//}



////////////
using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class AccountController : Controller
    {
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(User user)
        {
            if (ModelState.IsValid)
            {
                if (UserRepository.GetUser(user.Username) != null)
                {
                    ViewBag.Message = "Username already exists!";
                    return View();
                }

                user.Password = EncryptPassword(user.Password); // Encrypt password
                UserRepository.AddUser(user);
                ViewBag.Message = "Registration successful!";
                return View();
            }
            return View(user);
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Login(string username, string password)
        {
            var user = UserRepository.GetUser(username);
            if (user != null)
            {
                string encryptedPassword = EncryptPassword(password);
                if (user.Password == encryptedPassword)
                {
                    Session["Username"] = username;
                    return RedirectToAction("Index", "Home");
                }
            }

            ViewBag.Message = "Invalid username or password!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }

        private string EncryptPassword(string password)
        {
            using (var sha256 = System.Security.Cryptography.SHA256.Create())
            {
                byte[] bytes = sha256.ComputeHash(System.Text.Encoding.UTF8.GetBytes(password));
                var builder = new System.Text.StringBuilder();
                foreach (var b in bytes)
                {
                    builder.Append(b.ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
}

