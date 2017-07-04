using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{
    public class OperationController : Controller
    {
        private IOperationRepository OperationRepository { get; set; }

        public OperationController()
        {
            OperationRepository = new OperationRepository();
        }

        // GET: Operation
        public ActionResult Index()
        {
            ViewBag.Operation = OperationRepository.GetAll();

            return View();
        }
    }
}