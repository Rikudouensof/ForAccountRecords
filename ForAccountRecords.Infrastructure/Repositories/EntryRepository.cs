using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Domain.ViewModels.EntriesViewModel;
using ForAccountRecords.Infrastructure.Data;
using System.Net.Http.Headers;
using System.Reflection;


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

        

        public bool IsUserEntry(long itemId, long userId, BaseRequestModel userData)
        {
            var methodName = $"EntryRepository/{nameof(IsUserEntry)}";
            try
            {
                var response = _dbSet.Where(x => x.Id == itemId).First();
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                if (response.UserId == userId)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return false;
            }
        }


        public IEnumerable<Entry> GetEntryByFilter(EntryQueryRequestViewModel input)
        {
            var methodName = $"EntryRepository/{nameof(GetEntryByFilter)}";
            var request = _dbSet.AsQueryable();
            try
            {
                if (input.userId.HasValue)
                {
                    request = request.Where(x => x.UserId == input.userId);
                }
                if (input.EndDate is not null && input.StartDate is not null)
                {
                    request = request.Where(x => x.Date >= input.StartDate && x.Date <= input.EndDate);
                }
                if (input.SubTransactionClassificationId.HasValue)
                {
                    request = request.Where(x => x.SubTransactionClassificationId == input.SubTransactionClassificationId);
                }
                if (input.TransactionClassificationId.HasValue)
                {
                    request = request.Where(x => x.SubTransactionClassification.TransactionClassificationId == input.SubTransactionClassificationId);
                }
                if (input.TransactionTypeId.HasValue)
                {
                    request = request.Where(x => x.SubTransactionClassification.TransactionClassification.TransactionTypeId == input.SubTransactionClassificationId);
                }
                _logger.LogInformation(input.RequestId, "Db Process successful", input.Ip, methodName);
                return request.AsEnumerable();
            }
            catch (Exception ex)
            {
                _logger.LogError(input.RequestId, "Db Process failed", input.Ip, methodName, ex);
                return request.AsEnumerable();
            }
        }
    }
}
 