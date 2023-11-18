using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Models.DatabaseModels
{
  public class TransactionEntry
  {
    [Key]
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public DateTime EntryDate { get; set; } = DateTime.Now;
    public double Numberofunit { get; set; }
    public string Particular { get; set; }
    public string VoucherNumber { get; set; }
    public string LedgerFolio { get; set; }
    public double Ammount { get; set; }
    public string PurchaseInvoice { get; set; }
    public string CreditOrDebit { get; set; }

    //Relationships
    public virtual CreditDerbit CreditDerbit { get; set; }
    public int CreditDerbitId { get; set; }


    public virtual User User { get; set; }
    public int UserId { get; set; }


    public virtual TransactionType TransactionType { get; set; }
    public int TransactionTypeId { get; set; }

  }
}
