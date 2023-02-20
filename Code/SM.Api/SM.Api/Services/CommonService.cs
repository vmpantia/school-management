using Microsoft.EntityFrameworkCore;
using SM.Api.Commons;
using SM.Api.Contractors;
using SM.Api.DataAccess;
using SM.Api.DataAccess.Models;
using SM.Api.Exceptions;

namespace SM.Api.Services
{
    public class CommonService : ICommonService
    {
        public async Task InsertContactsAsync(SMDbContext db, Guid relationID, List<Contact> contacts)
        {
            if (contacts == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_CONTACTS));

            int result = 0;

            foreach (var contact in contacts)
            {
                contact.InternalID = Guid.NewGuid();
                contact.RelationID = relationID;
                contact.CreatedDate = DateTime.Now;
                contact.ModifiedDate = null;

                await db.Contacts.AddAsync(contact);

                result += await db.SaveChangesAsync();
            }

            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_CONTACTS));
        }

        public async Task UpdateContactsAsync(SMDbContext db, Guid relationID, List<Contact> contacts)
        {
            if (contacts == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_CONTACTS));

            int result = 0;

            foreach (var contact in contacts)
            {
                var currContacts = await db.Contacts.Where(data => data.InternalID == contact.InternalID &&
                                                                   data.RelationID == contact.RelationID).ToListAsync();

                if (currContacts.Any())
                {
                    var currContact = currContacts.First();
                    //currContact.InternalID = contact.InternalID;
                    //currContact.RelationID = contact.RelationID;
                    currContact.Type = contact.Type;
                    currContact.Value = contact.Value;
                    currContact.Status = contact.Status;
                    //currContact.CreatedDate = contact.CreatedDate;
                    currContact.ModifiedDate = Globals.EXEC_DATE;
                }
                else
                {
                    contact.InternalID = Guid.NewGuid();
                    contact.RelationID = relationID;
                    contact.CreatedDate = DateTime.Now;
                    await db.Contacts.AddAsync(contact);
                }

                result += await db.SaveChangesAsync();
            }

            if (result == contacts.Count())
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_CONTACTS));
        }

        public async Task InsertAddressesAsync(SMDbContext db, Guid relationID, List<Address> addresses)
        {
            if (addresses == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_ADDRESSES));

            int result = 0;

            foreach (var address in addresses)
            {
                address.InternalID = Guid.NewGuid();
                address.RelationID = relationID;
                address.CreatedDate = DateTime.Now;
                address.ModifiedDate = null;

                await db.Addresses.AddAsync(address);

                result += await db.SaveChangesAsync();
            }

            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_ADDRESSES));
        }

        public async Task UpdateAddressesAsync(SMDbContext db, Guid relationID, List<Address> addresses)
        {
            if (addresses == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_ADDRESSES));

            int result = 0;

            foreach (var address in addresses)
            {
                var currAddresses = await db.Addresses.Where(data => data.InternalID == address.InternalID &&
                                                                     data.RelationID == address.RelationID).ToListAsync();

                if (currAddresses.Any())
                {
                    var currAddress = currAddresses.First();
                    //currAddress.InternalID = address.InternalID;
                    //currAddress.RelationID = address.RelationID;
                    currAddress.Type = address.Type;
                    currAddress.Line1 = address.Line1;
                    currAddress.Line2 = address.Line2;
                    currAddress.Barangay = address.Barangay;
                    currAddress.City = address.City;
                    currAddress.ZipCode = address.ZipCode;
                    currAddress.Province = address.Province;
                    currAddress.Country = address.Country;
                    currAddress.Status = address.Status;
                    //currAddress.CreatedDate = address.CreatedDate;
                    currAddress.ModifiedDate = Globals.EXEC_DATE;
                }
                else
                {
                    address.InternalID = Guid.NewGuid();
                    address.RelationID = relationID;
                    address.CreatedDate = DateTime.Now;
                    await db.Addresses.AddAsync(address);
                }

                result += await db.SaveChangesAsync();
            }

            if (result == addresses.Count())
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_ADDRESSES));
        }
    }
}
