using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{
    public class OperationResultController : Controller
    {
        private IOperationResultRepository OperationResultRepository { get; set; }
        public OperationResultController()
        {
            OperationResultRepository = new OperationResultRepository();
        }
        // GET: OperationResult
        public ActionResult Index()
        {
            ViewBag.OperationResult = OperationResultRepository.GetAll();

            return View();
        }
    }
}