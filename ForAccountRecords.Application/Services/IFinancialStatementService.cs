using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Domain.Dtos.ServiceDtos.FinancialStatementsDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.FinancialStatementsDtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services
{
    public interface IFinancialStatementService
    {
       
        public Task<IncomeStatementResponseDto> IncomeStatement(IncomeStatementRequestDto requestDto);
    }
}
