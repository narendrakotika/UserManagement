using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
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
        public ActionResult Register(User user)
        {
            if (UserRepository.GetUser(user.Username) != null)
            {
                ViewBag.Message = "Username already exists!";
                return View();
            }

            UserRepository.AddUser(user);
            ViewBag.Message = "Registration successful!";
            return View();
        }

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(string username, string password)
        {
            var user = UserRepository.GetUser(username);
            if (user != null && user.Password == password)
            {
                Session["Username"] = username;
                return RedirectToAction("Index", "Home");
            }

            ViewBag.Message = "Invalid username or password!";
            return View();
        }

        public ActionResult Logout()
        {
            Session.Abandon();
            return RedirectToAction("Login");
        }
    }
}