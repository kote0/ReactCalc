using DomainModels.Repository;
using ReactCalc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebCalc1.Models;

namespace WebCalc1.Controllers
{
    public class CalcController : Controller
    {
        private IORepository ORRepository { get; set; }
        private IOperationRepository OperationRepository { get; set; }
        private IUserRepository UserRepository { get; set; }
        private Calc Calc { get; set; }
        
        public CalcController(IORepository orrepository, IUserRepository userRepository, IOperationRepository operationRepository)
        {
            Calc = new Calc();
            this.ORRepository = orrepository;
            this.UserRepository = userRepository;
            this.OperationRepository = operationRepository;
        }
        // GET: Calc
        public ActionResult Index()
        {
            var model = new CalcModel();
            ViewBag.s = new SelectList(OperationRepository.GetAll(), "Name", "FullName");
            return View(model);
        }
        [HttpPost]
        public ActionResult Index(CalcModel model)
        {
            ViewBag.s = new SelectList(OperationRepository.GetAll(), "Name", "FullName");

            var operation = Calc.Operations.FirstOrDefault(o => o.Name == model.Operation);
            if (operation != null)
            {
                
                //operation.Name 
                var OperationId = OperationRepository.GetByName(operation.Name).Id;
                var inputData = string.Join(";", model.Arguments);

                var oldResult = ORRepository.GetOldResult(OperationId, inputData);
                if (!double.IsNaN( oldResult))
                {
                    model.Result = oldResult;
                }
                else
                {
                    var result = operation.Execute(model.Arguments);
                    var rec = ORRepository.Create();
                    //ХАК №1
                    var currUser = UserRepository.GetByName(User.Identity.Name);
                    rec.AuthorId = currUser.Id;
                    //rec.AuthorId = 5;
                    //ХАК
                    rec.OperationId = OperationId;

                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = string.Join(";", model.Arguments);
                    model.Result = result;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                }

                return View(model);
            }
            return View();
        }
        public ActionResult OperationResult()
        {
            return View(ORRepository.GetAll());
        }
    }
}