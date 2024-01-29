using ForAccountRecords.Domain.Dtos.InnerDtos.EndPointDtos.EntryEndpointDtos;
using ForAccountRecords.Domain.Dtos.InnerDtos.EndPointDtos.UserContactEndpointDtos;
using ForAccountRecords.Domain.Models.DatabaseModels;
using ForAccountRecords.Domain.Models.GeneralModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services.ApiServices.EndpointConsumptionService
{
   
    public interface IUserControlConsumptionService
    {

        //Entry
        IEnumerable<Entry> GetAllEntry(AppSettings appSettings);
        Entry GetSingleEntry(EntryEndpointSingleDto input, AppSettings appSettings);

        string AddEntry(EntryEndpointDataDto input, AppSettings appSettings);

        string EditEntry(EntryEndpointDataDto input, AppSettings appSettings);

        string DeleteEntry(EntryEndpointSingleDto input, AppSettings appSettings);



        //Entry Type
        IEnumerable<EntryType> GetAllEntryType(AppSettings appSettings);


        //SubTransactionCalassification

        IEnumerable<SubTransactionClassification> GetAllSubTransactionCalassification(AppSettings appSettings);


        //TransactionClassification
        IEnumerable<TransactionClassification> GetAllTransactionClassification(AppSettings appSettings);

        //TransactionType
        IEnumerable<TransactionType> GetAllTransactionType(AppSettings appSettings);

        //UserContact
        IEnumerable<UserContact> GetAllUserContact(AppSettings appSettings);

        UserContact GetSingleUserContact(EntryEndpointSingleDto input, AppSettings appSettings);

        string AddUserContact(UserContactEndpointDataDto input, AppSettings appSettings);

        string EditUserContact(UserContactEndpointDataDto input, AppSettings appSettings);

        string DeleteUserContact(UserContactEndpointSingleDto input, AppSettings appSettings);

        //UserContactsCategory
        IEnumerable<UserContactsCategory> GetAllUserContactsCategory(AppSettings appSettings);
    }
}
