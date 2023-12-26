using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.EntriesViewModel
{
    public class MakeEntryViewModel
    {

        public int? Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }


        [Required]
        public decimal Amount { get; set; }

        [Required]
        public decimal Units { get; set; }


        public string RefrenceNumber { get; set; }


        //Relationships
  
        public int EntryTypeId { get; set; }
       
        public int SubTransactionClassificationId { get; set; }
    }
}
