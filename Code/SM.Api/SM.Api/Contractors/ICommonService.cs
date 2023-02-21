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
        Task<string> InsertRequestAsync(SMDbContext db, RequestBase requestInfo);
    }
}