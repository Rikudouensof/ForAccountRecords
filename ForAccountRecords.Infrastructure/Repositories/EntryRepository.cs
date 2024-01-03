using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Data;


namespace ForAccountRecords.Infrastructure.Repositories
{
    public class EntryRepository : GenericRepository<Entry,long>, IEntryRepository
    {

        public EntryRepository(ApplicationDbContext dbContext, ILogHelper logger): base(dbContext,logger)
        {
        }

        public  IEnumerable<Entry> AllByUserId(long Id, BaseRequestModel userData)
        {
            var methodName = $"EntryRepository/{nameof(AllByUserId)}";
            try
            {

                var response =  _dbSet.Where(x => x.UserId == Id);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed",userData.Ip, methodName, ex);
                return new List<Entry>();
            }
        }
    }
}
 