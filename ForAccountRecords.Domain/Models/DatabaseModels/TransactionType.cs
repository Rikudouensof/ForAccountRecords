using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
  public class TransactionType
  {
    [Key]
    public int Id { get; set; }

    [Required]
    public string Name { get; set; }

    //Relationships
    public virtual EntryType EntryType { get; set; }
    public int EntryTypeId { get; set; }

    
  }
}
