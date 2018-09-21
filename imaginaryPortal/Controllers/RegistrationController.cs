using imaginaryPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using imaginaryPortal.ViewModel;
using System.IO;

namespace imaginaryPortal.Controllers
{
    public class RegistrationController : Controller
    {
        private imaginaryDbContext _context;

        public RegistrationController()
        {
            _context = new imaginaryDbContext();
        }
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Index(userViewModel registration)
        {
            if (ModelState.IsValid)
            {
                User user = new User();
                user.FullName = "Yasa";
                user.Country = registration.Country;
                user.State = registration.State;
                user.City = registration.City;
                user.Email = registration.Email;
                user.Gender = registration.Gender;
                user.Password = registration.Password;
                user.Mobile = registration.Mobile;
                user.CreatedOn = DateTime.Now;
                if (registration.Photo != null)
                {
                    user.Photo = registration.Photo.FileName;
                    registration.Photo.SaveAs(Server.MapPath("~/Content/" + user.Photo));
                }
                _context.Users.Add(user);
                _context.SaveChanges();
                ModelState.Clear();
            }
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(loginViewModel user)
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        [HttpGet]
       
        public JsonResult loadUsers()
        {
            return Json(_context.Users.ToList(),JsonRequestBehavior.AllowGet);
        }
    }
   
}