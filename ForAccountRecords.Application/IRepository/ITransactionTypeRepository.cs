﻿using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IRepository
{
    public interface ITransactionTypeRepository : IGenericRepository<TransactionType, int>
    {
    }
}
  