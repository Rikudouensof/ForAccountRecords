using ForAccountRecords.Domain.Dtos.InnerDtos.EndPointDtos.EntryEndpointDtos;
using ForAccountRecords.Domain.Dtos.InnerDtos.EndPointDtos.UserContactEndpointDtos;
using ForAccountRecords.Domain.Models.DatabaseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ForAccountRecords.Application.Services.ApiServices.EnpointCreationService
{
    public interface IUserControlCreationService
    {

        //Entry
        IEnumerable<Entry> GetAllEntry();
        Entry GetSingleEntry(EntryEndpointSingleDto input);

        string AddEntry(EntryEndpointDataDto input);

        string EditEntry(EntryEndpointDataDto input);

        string DeleteEntry(EntryEndpointSingleDto input);



        //Entry Type
        IEnumerable<EntryType> GetAllEntryType();


        //SubTransactionCalassification

        IEnumerable<SubTransactionClassification> GetAllSubTransactionCalassification();


        //TransactionClassification
        IEnumerable<TransactionClassification> GetAllTransactionClassification();

        //TransactionType
        IEnumerable<TransactionType> GetAllTransactionType();

        //UserContact
        IEnumerable<UserContact> GetAllUserContact();

        UserContact GetSingleUserContact(EntryEndpointSingleDto input);

        string AddUserContact(UserContactEndpointDataDto input);

        string EditUserContact(UserContactEndpointDataDto input);

        string DeleteUserContact(UserContactEndpointSingleDto input);

        //UserContactsCategory
        IEnumerable<UserContactsCategory> GetAllUserContactsCategory();
    }
}
