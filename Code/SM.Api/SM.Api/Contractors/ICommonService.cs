using SM.Api.DataAccess;
using SM.Api.DataAccess.Models;
using SM.Api.Models.Requests;

namespace SM.Api.Contractors
{
    public interface ICommonService
    {
        Task InsertAddressesAsync(SMDbContext db, Guid relationID, List<Address> addresses);
        Task InsertContactsAsync(SMDbContext db, Guid relationID, List<Contact> contacts);
        Task UpdateAddressesAsync(SMDbContext db, Guid relationID, List<Address> addresses);
        Task UpdateContactsAsync(SMDbContext db, Guid relationID, List<Contact> contacts);
        Task InsertContacts_TRNAsync(SMDbContext db, List<Contact> contacts, string requestID);
        Task InsertAddress_TRNAsync(SMDbContext db, List<Address> addresses, string requestID);
        Task<string> InsertRequestAsync(SMDbContext db, RequestBase requestInfo);
    }
}