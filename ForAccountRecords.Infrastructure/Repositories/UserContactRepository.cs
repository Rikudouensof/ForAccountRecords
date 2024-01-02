using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Repositories
{
    public class UserContactRepository : GenericRepository<UserContact, long>, IUserContactRepository
    {

        public UserContactRepository(ApplicationDbContext dbContext, ILogHelper logger) : base(dbContext, logger)
        {

        }

        public IEnumerable<UserContact> AllByUserId(long Id, BaseRequestModel userData)
        {
            var methodName = $"UserContactRepository/{nameof(AllByUserId)}";
            try
            {

                var response = _dbSet.Where(x => x.UserId == Id);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return new List<UserContact>();
            }
        }
    }
}
