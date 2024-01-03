using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
    public class Entry
    {
        [Key]
        public long Id { get; set; }

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
        public virtual EntryType EntryType { get; set; }
        public int EntryTypeId { get; set; }

        public virtual SubTransactionClassification SubTransactionClassification { get; set; }
        public int SubTransactionClassificationId { get; set; }


        public User User { get; set; }
        public long UserId { get; set; }


    }
}
