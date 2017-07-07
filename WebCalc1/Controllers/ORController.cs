using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{
    public class ORController : BaseController
    {
        public ORController(IORepository orrepository, IUserRepository UserRepository, IOperationRepository OperationRepository, ILikeRepository LikeRepository) : base(orrepository, UserRepository, OperationRepository, LikeRepository)
        {
        }

        // GET: OR
        public ActionResult Index()
        {
            var currUser = UserRepository.GetByName(User.Identity.Name);
            var result = ORRepository.GetByUser(currUser);

            var likes = LikeRepository.GetAll()
                .Where(u => u.Users == currUser)
                .Select(it => it.Result);

            foreach(var r in result)
            {
                r.IsLiked = likes.Contains(r);
            }

            return View(result);
        }
        [HttpPost]
        public JsonResult Like(long id)
        {
            var result = ORRepository.Get(id);
            if (result == null)
            {
                //ViewBag.Message = "Не удалось найти результат";
                return Json(new { Success = false, Error = "Не удалось найти результат" });
            }

            var currUser = UserRepository.GetByName(User.Identity.Name);

            var like = LikeRepository.GetAll().
                FirstOrDefault(i => i.Users == currUser && i.Id == id);
            if (like != null)
            {
                LikeRepository.Delete(like);
                return Json(new { Success = true, Name = "Like" });
            }

            like = LikeRepository.Create();
            like.Users = currUser;
            like.Result = result;
            LikeRepository.Update(like);

            //ViewBag.Message = string.Format("Пользователь\"{0}\" лайкнул результат операции \"{1}\"", currUser.FIO, result.Operation.Name );

            return Json(new { Success = true, Name = "DisLike" });
        }
    }
}