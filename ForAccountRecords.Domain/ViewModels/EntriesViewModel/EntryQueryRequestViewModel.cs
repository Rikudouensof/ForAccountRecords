using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.EntriesViewModel
{
    public class EntryQueryRequestViewModel : BaseRequestModel
    {

        public long? userId { get; set; }
         
        public int? TransactionTypeId { get; set; }

        public int? TransactionClassificationId { get; set; }

        public int? SubTransactionClassificationId { get; set; }

        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }
    }
}
