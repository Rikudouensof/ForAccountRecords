using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
    public class SubTransactionClassification
    {

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        //Relationships
        public virtual TransactionClassification TransactionClassification { get; set; }
        public int TransactionClassificationId { get; set; }
    }
}
