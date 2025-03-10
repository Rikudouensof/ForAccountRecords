﻿using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IRepository
{
    public interface IEntryRepository : IGenericRepository<Entry, long>
    {
        public IEnumerable<Entry> AllByUserId(long Id, BaseRequestModel userData);


        public bool IsUserEntry(long itemId,long userId , BaseRequestModel userData);

    }
}
