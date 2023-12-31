using ForAccountRecords.Application.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.IConfiguration
{
    public interface IUnitOfWork
    {
        IEntryRepository Entries { get; } 
        IEntryTypeRepository EntryTypes { get; }
        ISubTransactionClassificationRepository SubTransactionClassifications { get; }
        ITransactionClassificationRepository TransactionClassifications { get; }
        ITransactionTypeRepository TransactionTypes { get; }
        IUserContactRepository UserContacts { get; }
        IUserContactsCategoryRepository UserContactsCategories { get; }
        IUserRepository Users { get; }
        IUserRoleRepository UserRoles { get; }




        Task CompleteAsync();


    }
}
