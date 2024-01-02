using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IRepository
{
    public interface IUserContactRepository : IGenericRepository<UserContact, long>
    {

        public IEnumerable<UserContact> AllByUserId(long Id, BaseRequestModel userData);
    }
}
 