using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{
    public class HomeController : Controller
    {
        private IUserRepository UserRepository { get; set; }

        public HomeController()
        {
            UserRepository = new UserRepository();
        }
        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();

            return View();
        }
        
        public ActionResult Find(long Id)
        {
            ViewBag.Name = UserRepository.Get(Id);
            ViewBag.Users = UserRepository.Find(Id);

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}