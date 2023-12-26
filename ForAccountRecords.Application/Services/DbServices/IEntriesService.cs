using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.ViewModels.EntriesViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services.DbServices
{
    public interface IEntriesService
    {

        public IEnumerable<TransactionType> GetAllTransactionTypes();

        public IEnumerable<Entry> GetAllEntries();

        public string NewEntry(MakeEntryViewModel input);
        public string EditEntry(MakeEntryViewModel input);
        public string DeleteEntry(MakeEntryViewModel input);
    }
}
