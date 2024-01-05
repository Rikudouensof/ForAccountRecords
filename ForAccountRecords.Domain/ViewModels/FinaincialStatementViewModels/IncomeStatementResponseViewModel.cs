using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.ViewModels.FinaincialStatementViewModels
{
    public class IncomeStatementResponseViewModel
    {

        public List<IncomeStatementRevenueViewModel> Revenues { get; set; }
        public List<IncomeStatementExpenseViewModel> Expenses { get; set; }
        public decimal TotalRevenue { get; set; }
        public decimal ToTalExpense { get; set; }

        public decimal NetIncome { get; set; }



    }
}
