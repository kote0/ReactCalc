﻿using DomainModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DomainModels.Repository
{
    public interface IOperationRepository : IEntityRepository<Operation>
    {
        Operation GetByName(string name);
    }
}
