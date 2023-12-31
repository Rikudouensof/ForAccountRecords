using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Domain.Models.DatabaseModels;
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
            _dbSet = _dbContext.Set<T>();
        }

        public async Task<IEnumerable<T>> All()
        {


            try
            {


                return await _dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed","::1","All",ex);
                return null;
            }
        }

        public async Task<T> GetById(K id)
        {

            try
            {


                return await _dbSet.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed", "::1", "All", ex);
                return null;
            }
        }

        public async Task<bool> Add(T entity)
        {
            try
            {

                await _dbSet.AddAsync(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed", "::1", "All", ex);
                return false;
            }
        }

        public async  Task<bool> Delete(K id)
        {
            try
            {
                var entity =  _dbSet.Find(id);
                _dbSet.Remove(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed", "::1", "All", ex);
                return false;
            }
        }

        public async Task<bool> Update(T entity)
        {
            try
            {

                 _dbSet.Update(entity);
                return true;
            }
            catch (Exception ex)
            {
                _logger.LogError("0", "Db Process failed", "::1", "All", ex);
                return false;
            }
        }
    }
}
