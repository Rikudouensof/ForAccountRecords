using ForAccountRecords.Application.Helpers;
using ForAccountRecords.Application.IConfiguration;
using ForAccountRecords.Application.Services;
using ForAccountRecords.Domain.Constants;
using ForAccountRecords.Domain.Dtos.ServiceDtos.FinancialStatementsDtos.Request;
using ForAccountRecords.Domain.Dtos.ServiceDtos.FinancialStatementsDtos.Response;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using ForAccountRecords.Domain.ViewModels.EntriesViewModel;
using ForAccountRecords.Domain.ViewModels.FinaincialStatementViewModels;
using ForAccountRecords.Infrastructure.Data;
using ForAccountRecords.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Infrastructure.Services
{
    public class FinancialStatementService : IFinancialStatementService
    {

        private readonly ILogHelper _logger;
        readonly string classname = nameof(FinancialStatementService);
        private readonly IUnitOfWork _uow;
        private readonly IEmailService _emailService;

        public FinancialStatementService(ILogHelper logger,
          IUnitOfWork dbcontext,
          IEmailService emailService
          )
        {
            _logger = logger;
            _uow = dbcontext;
            _emailService = emailService;

        }



        public async Task<IncomeStatementResponseDto> IncomeStatement(IncomeStatementRequestDto input)
        {
            var methodName = $" {nameof(classname)}/{nameof(IncomeStatement)}";
            var response = new IncomeStatementResponseDto();
            try
            {
                var revenues = await GetIncomeStatementByRevenues(input);
                var expenses = await GetIncomeStatementByExpense(input);
                decimal totalRevenues = 0, totalExpenses = 0;
                foreach (var item in revenues)
                {
                    totalRevenues = totalRevenues + item.Amount;
                }
                foreach (var item in expenses)
                {
                    totalExpenses = totalExpenses + item.Amount;
                }
                response = new IncomeStatementResponseDto()
                {
                    Response = new IncomeStatementResponseViewModel()
                    {
                        Expenses = expenses.ToList(),
                        Revenues = revenues.ToList(),
                        ToTalExpense = totalExpenses,
                        TotalRevenue = totalRevenues,
                        NetIncome = totalRevenues - totalExpenses
                    },
                    ResponseCode = GeneralResponse.sucessCode,
                    ResponseMessage = GeneralResponse.sucessMessage
                };
                _logger.LogInformation(input.RequestId, "Process successful", input.Ip, methodName);
            }
            catch (Exception ex)
            {
                response = new IncomeStatementResponseDto()
                {
                    ResponseMessage = GeneralResponse.failureMessage,
                    ResponseCode = GeneralResponse.failureCode,
                };
                _logger.LogError(input.RequestId, "Process failed", input.Ip, methodName, ex);
            }
            _logger.LogInformation(input.RequestId, $"Service Response:{response}", input.Ip, methodName);
            return response;
        }






        #region Income Statement Control Region
        private async Task<IEnumerable<IncomeStatementRevenueViewModel>> GetIncomeStatementByRevenues(IncomeStatementRequestDto input)
        {
            var methodName = $" {nameof(classname)}/{nameof(IncomeStatement)}";
            _logger.LogInformation(input.RequestId, "New Process successful", input.Ip, methodName);
            var response = new List<IncomeStatementRevenueViewModel>();
            try
            {
                var payload = new EntryQueryRequestViewModel()
                {
                    TransactionTypeId = 4,
                    StartDate = input.InputData.StartDate,
                    EndDate = input.InputData.EndDate,
                    userId = input.UserId
                };
                var basePayload = new BaseRequestModel()
                {
                    Ip = input.Ip,
                    RequestId = input.RequestId
                };
                var entriesWithinDateRange = _uow.Entries.GetEntryByFilter(payload);
                var geroupedByName = entriesWithinDateRange.GroupBy(x => x.SubTransactionClassificationId);
                foreach (var revenueGroup in geroupedByName)
                {
                    decimal amount = 0;
                    var subCategoryName = await _uow.SubTransactionClassifications.GetById(revenueGroup.Key, basePayload);
                    foreach (var itemEntry in revenueGroup)
                    {
                        amount = amount + itemEntry.Amount;
                    }
                    var innerResponse = new IncomeStatementRevenueViewModel()
                    {
                        Name = subCategoryName.Name,
                        Amount = amount
                    };
                    response.Add(innerResponse);
                }
                _logger.LogInformation(input.RequestId, "Process successful", input.Ip, methodName);
            }
            catch (Exception ex)
            {
                _logger.LogError(input.RequestId, "Process failed", input.Ip, methodName, ex);
            }
            return response;
        }

        private async Task<IEnumerable<IncomeStatementExpenseViewModel>> GetIncomeStatementByExpense(IncomeStatementRequestDto input)
        {
            var methodName = $" {nameof(classname)}/{nameof(IncomeStatement)}";
            _logger.LogInformation(input.RequestId, "New Process successful", input.Ip, methodName);
            var response = new List<IncomeStatementExpenseViewModel>();
            try
            {
                var payload = new EntryQueryRequestViewModel()
                {
                    TransactionTypeId = 3,
                    StartDate = input.InputData.StartDate,
                    EndDate = input.InputData.EndDate,
                    userId = input.UserId
                };
                var basePayload = new BaseRequestModel()
                {
                    Ip = input.Ip,
                    RequestId = input.RequestId
                };
                var entriesWithinDateRange = _uow.Entries.GetEntryByFilter(payload);
                var geroupedByName = entriesWithinDateRange.GroupBy(x => x.SubTransactionClassificationId);
                foreach (var expenseGroup in geroupedByName)
                {
                    decimal amount = 0;
                    var subCategoryName = await _uow.SubTransactionClassifications.GetById(expenseGroup.Key, basePayload);
                    foreach (var itemEntry in expenseGroup)
                    {
                        amount = amount + itemEntry.Amount;
                    }
                    var innerResponse = new IncomeStatementExpenseViewModel()
                    {
                        Name = subCategoryName.Name,
                        Amount = amount
                    };
                    response.Add(innerResponse);
                }
                _logger.LogInformation(input.RequestId, "Process successful", input.Ip, methodName);
            }
            catch (Exception ex)
            {
                _logger.LogError(input.RequestId, "Process failed", input.Ip, methodName, ex);
            }
            return response;
        }

        #endregion




    }
}
