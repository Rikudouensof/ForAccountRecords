using ForAccountRecords.Domain.Models.DatabaseModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserContact> Contacts { get; set; }
        public DbSet<UserContactsCategory> ContactsCategories { get; set; }

        public DbSet<Entry> Entries { get; set; }
        public DbSet<EntryType> EntryTypes { get; set; }
        public DbSet<SubTransactionClassification> SubTransactionClassifications { get; set; }
        public DbSet<TransactionClassification> TransactionClassifications { get; set; }

        public DbSet<TransactionType> TransactionTypes { get; set; }

        public DbSet<UserRole> UserRoles { get; set; }
    }
}
