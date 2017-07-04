using DomainModels.Models;
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
            UserRepository = new DomainModels.EF.UserRepository();
        }



        public ActionResult Index()
        {
            ViewBag.Users = UserRepository.GetAll();

            return View();
        }
        public ActionResult Find(long Id)
        {
            return View(UserRepository.Get(Id));
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create([Bind(Include = "Password,Login,FIO")] User user)
        {
            user.Uid = Guid.NewGuid();
            UserRepository.Create(user);
            return RedirectToAction("Index");
        }
        
        public ActionResult Delete(long Id)
        {
            UserRepository.Delete(UserRepository.Get(Id));

            return RedirectToAction("Index");
        }
        
    }
}