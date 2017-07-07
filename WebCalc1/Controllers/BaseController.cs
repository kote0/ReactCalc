using DomainModels.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebCalc1.Controllers
{

    public class BaseController : Controller
    {
        protected IORepository ORRepository { get; set; }
        protected IUserRepository UserRepository { get; set; }
        protected IOperationRepository OperationRepository { get; set; }
        protected ILikeRepository LikeRepository { get; set; }


        public BaseController(IORepository ORRepository,
            IUserRepository UserRepository,
            IOperationRepository OperationRepository,
            ILikeRepository LikeRepository)
        {
            this.ORRepository = ORRepository;
            this.UserRepository = UserRepository;
            this.OperationRepository = OperationRepository;
            this.LikeRepository = LikeRepository;
        }
        
    }
}