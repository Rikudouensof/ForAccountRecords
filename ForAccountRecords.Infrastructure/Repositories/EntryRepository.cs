using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Repositories
{
    public class EntryRepository : GenericRepository<Entry,long>, IEntryRepository
    {

        public EntryRepository(ApplicationDbContext dbContext, ILogHelper logger): base(dbContext,logger)
        {
                
        }
    }
}
 