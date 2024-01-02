using Azure;
using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Repositories
{
    public class GenericRepository<T, K> : IGenericRepository<T, K> where T : class
    {
        protected ApplicationDbContext _dbContext;
        protected DbSet<T> _dbSet;
        protected readonly ILogHelper _logger;


        public GenericRepository(ApplicationDbContext dbContext, ILogHelper logger)
        {
            _dbContext = dbContext;
            _logger = logger;
            this._dbSet = dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> All( BaseRequestModel userData)
        {
            var methodName = $"GenericRepository/{nameof(All)}";
            try
            {


                var response = await  _dbSet.ToListAsync();
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return response;
            
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed","::1","All",ex);
                return null;
            }
        }

        public async Task<T> GetById(K id, BaseRequestModel userData)
        {
            var methodName = $"GenericRepository/{nameof(GetById)}";
            try
            {


                var response = await _dbSet.FindAsync(id);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return response;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return null;
            }
        }

        public async Task<bool> Add(T entity, BaseRequestModel userData)
        {

            var methodName = $"GenericRepository/{nameof(Add)}";
            try
            {

                await _dbSet.AddAsync(entity);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return false;
            }
        }

        public async  Task<bool> Delete(K id, BaseRequestModel userData)
        {
            var methodName = $"GenericRepository/{nameof(Delete)}";
            try
            {
                var entity =  _dbSet.Find(id);
                _dbSet.Remove(entity);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return false;
            }
        }

        public async Task<bool> Update(T entity, BaseRequestModel userData)
        {

            var methodName = $"GenericRepository/{nameof(Update)}";
            try
            {
                 _dbSet.Update(entity);
                _logger.LogInformation(userData.RequestId, "Db Process successful", userData.Ip, methodName);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError(userData.RequestId, "Db Process failed", userData.Ip, methodName, ex);
                return false;
            }
        }
    }
}
