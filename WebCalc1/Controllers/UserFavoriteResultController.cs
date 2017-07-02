using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{
    public class UserFavoriteResultController : Controller
    {
        private IUserFavoriteRepository UserFavoriteRepository { get; set; }
        public UserFavoriteResultController()
        {
            UserFavoriteRepository = new UserFavoriteRepository();
        }
        // GET: UserFavoriteResult
        public ActionResult Index()
        {
            ViewBag.FavoriteRes = UserFavoriteRepository.GetAll();
            return View();
        }
    }
}