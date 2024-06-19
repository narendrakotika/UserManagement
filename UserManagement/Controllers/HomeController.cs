//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using UserManagement.Models;

//namespace UserManagement.Controllers
//{
//    public class HomeController : Controller
//    {
//        public ActionResult Index()
//        {
//            if (Session["Username"] == null)
//            {
//                return RedirectToAction("Login", "Account");
//            }

//            ViewBag.Username = Session["Username"].ToString();
//            return View(UserRepository.Users);
//        }

//        public ActionResult Edit(string username)
//        {
//            var user = UserRepository.GetUser(username);
//            return View(user);
//        }

//        [HttpPost]
//        public ActionResult Edit(User user)
//        {
//            UserRepository.UpdateUser(user);
//            return RedirectToAction("Index");
//        }

//        public ActionResult Delete(string username)
//        {
//            UserRepository.DeleteUser(username);
//            return RedirectToAction("Index");
//        }

//        public ActionResult Add()
//        {
//            return View();
//        }

//        [HttpPost]
//        public ActionResult Add(User user)
//        {
//            UserRepository.AddUser(user);
//            return RedirectToAction("Index");
//        }
//    }
//}


using System.Web.Mvc;
using UserManagement.Models;

namespace UserManagement.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (Session["Username"] == null)
            {
                return RedirectToAction("Login", "Account");
            }

            ViewBag.Username = Session["Username"].ToString();
            return View(UserRepository.Users);
        }

        public ActionResult Edit(string username)
        {
            var user = UserRepository.GetUser(username);
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.UpdateUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }

        public ActionResult Delete(string username)
        {
            UserRepository.DeleteUser(username);
            return RedirectToAction("Index");
        }

        public ActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(User user)
        {
            if (ModelState.IsValid)
            {
                UserRepository.AddUser(user);
                return RedirectToAction("Index");
            }
            return View(user);
        }
    }
}


