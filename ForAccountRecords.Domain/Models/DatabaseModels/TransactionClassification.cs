using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
    public class TransactionClassification
    {
        [Key]
        public int Id { get; set; }


        [Required]
        public string Name { get; set; }

        //Relationships
        public virtual TransactionType TransactionType { get; set; }
        public int TransactionTypeId { get; set; }
    }
}
