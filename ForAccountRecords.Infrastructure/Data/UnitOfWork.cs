using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Application.IRepository;
using ForAccountRecords.Infrastructure.Repositories;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ILogHelper _logger;
        public IEntryRepository Entries { get; private set; }
        public IEntryTypeRepository EntryTypes { get; private set; }
        public ISubTransactionClassificationRepository SubTransactionClassifications { get; private set; }
        public ITransactionClassificationRepository TransactionClassifications { get; private set; }
        public ITransactionTypeRepository TransactionTypes { get; private set; }
        public IUserContactRepository UserContacts { get; private set; }
        public IUserContactsCategoryRepository UserContactsCategories { get; private set; }
        public IUserRepository Users { get; private set; }
        public IUserRoleRepository UserRoles { get; private set; }


        public UnitOfWork(ApplicationDbContext dbContext, ILogHelper logger)
        {
            _dbContext = dbContext;
            _logger = logger;

            //Add Repository

            Entries = new EntryRepository(_dbContext, _logger);
            EntryTypes = new EntryTypeRepository(_dbContext, _logger);
            SubTransactionClassifications = new SubTransactionClassificationRepository(_dbContext, _logger);
            TransactionClassifications = new TransactionClassificationRepository(_dbContext, _logger);
            TransactionTypes = new TransactionTypeRepository(_dbContext, _logger);  
            UserContacts = new UserContactRepository(_dbContext, _logger);
            UserContactsCategories = new UserContactsCategoryRepository(dbContext, _logger);
            Users = new UserRepository(_dbContext, _logger);
            UserRoles = new UserRoleRepository(dbContext, _logger);

        }

        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }

        public async void Dispose()
        {
           await _dbContext.DisposeAsync();
        }
    }
}
