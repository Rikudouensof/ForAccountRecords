using ForAccountRecords.Domain.ViewModels.InternalViewModels.FinaincialStatementViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Domain.Dtos.InnerDtos.ServiceDtos.FinancialStatementsDtos.Request
{
    public class IncomeStatementRequestDto : BaseRequestDto<FinancialStatementRequestViewModel>
    {

        public long? UserId { get; set; }
    }
}
