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
                var OperationId = OperationRepository.GetByName(operation.Name);
                var inputData = string.Join(";", model.Arguments);

                var oldResult = ORRepository.GetOldResult(OperationId, inputData);
                if (!double.IsNaN( oldResult))
                {

                    if (model.IsCompute)
                    {
                        // пересчитываем и присваеваем в model.Result
                        oldResult = operation.Execute(model.Arguments);
                        // находим польхователя и по входным данным и id операции ищем запись в ORRepository
                        var currUserId = UserRepository.GetByName(User.Identity.Name).Id;
                        var t = ORRepository.GetRecord(currUserId, OperationId, inputData);
                        // передаем изменения в ORRepository
                        t.Result = oldResult;
                        ORRepository.Update(t);
                    }

                    model.Result = oldResult;
                }
                else
                {
                    #region Вычисление
                    var result = operation.Execute(model.Arguments);
                    var rec = ORRepository.Create();
                    //ХАК №1
                    var currUser = UserRepository.GetByName(User.Identity.Name);
                    rec.Author = currUser;
                    //rec.AuthorId = 5;
                    //ХАК
                    rec.Operation = OperationId;

                    rec.ExecutionDate = DateTime.Now;
                    rec.ExecutionTime = new Random().Next(0, 100);
                    rec.InputData = string.Join(";", model.Arguments);
                    model.Result = result;
                    rec.Result = model.Result ?? Double.NaN;

                    ORRepository.Update(rec);
                    #endregion
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