using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.EntriesViewModel
{
    public class GetAllTransactionTypeResponseViewModel
    {
        

        public IEnumerable<TransactionType> TransactionTypes { get; set; }
    }

   
}
