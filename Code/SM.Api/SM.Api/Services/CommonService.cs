using Microsoft.EntityFrameworkCore;
using SM.Api.Commons;
using SM.Api.Contractors;
using SM.Api.DataAccess;
using SM.Api.DataAccess.Models;
using SM.Api.DataAccess.Models.Transaction;
using SM.Api.Exceptions;
using SM.Api.Models.Requests;

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
                contact.CreatedDate = Globals.EXEC_DATETIME;
                contact.ModifiedDate = null;

                await db.Contacts.AddAsync(contact);

                result += await db.SaveChangesAsync();
            }

            if (result != contacts.Count())
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
                    currContact.ModifiedDate = Globals.EXEC_DATETIME;
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

            if (result != contacts.Count())
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_CONTACTS));
        }

        public async Task InsertContacts_TRNAsync(SMDbContext db, List<Contact> contacts, string requestID)
        {
            if (contacts == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_CONTACTS));

            int result = 0, number = 1;

            foreach (var contact in contacts)
            {
                var trn = new Contact_TRN
                {
                    RequestID = requestID,
                    Number = number,
                    InternalID = contact.InternalID,
                    RelationID = contact.RelationID,
                    Type = contact.Type,
                    Value = contact.Value,
                    Status = contact.Status,
                    CreatedDate = contact.CreatedDate,
                    ModifiedDate = contact.ModifiedDate
                };

                await db.Contact_TRN.AddAsync(trn);

                result += await db.SaveChangesAsync();

                number++;
            }

            if (result != contacts.Count())
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_CONTACTS_TRN));
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
                address.CreatedDate = Globals.EXEC_DATETIME;
                address.ModifiedDate = null;

                await db.Addresses.AddAsync(address);

                result += await db.SaveChangesAsync();
            }

            if (result != addresses.Count())
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
                    currAddress.ModifiedDate = Globals.EXEC_DATETIME;
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

            if (result != addresses.Count())
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_ADDRESSES));
        }

        public async Task InsertAddress_TRNAsync(SMDbContext db, List<Address> addresses, string requestID)
        {
            if (addresses == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_ADDRESSES));

            int result = 0, number = 1;

            foreach (var address in addresses)
            {
                var trn = new Address_TRN
                {
                    RequestID = requestID,
                    Number = number,
                    InternalID = address.InternalID,
                    RelationID = address.RelationID,
                    Type = address.Type,
                    Line1 = address.Line1,
                    Line2 = address.Line2,
                    Barangay = address.Barangay,
                    City = address.City,
                    ZipCode = address.ZipCode,
                    Province = address.Province,
                    Country = address.Country,
                    Status = address.Status,
                    CreatedDate = address.CreatedDate,
                    ModifiedDate = address.ModifiedDate
                };

                await db.Address_TRN.AddAsync(trn);

                result += await db.SaveChangesAsync();

                number++;
            }

            if (result != addresses.Count())
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_CONTACTS_TRN));
        }

        public async Task<string> InsertRequestAsync(SMDbContext db, RequestBase requestInfo)
        {
            var newRequest = new Request
            {
                RequestID = await GetNewRequestIDAsync(db),
                FunctionID = requestInfo.FunctionID,
                RequestDate = Globals.EXEC_DATE,
                RequestBy = requestInfo.UserID,
                ApprovedDate = null,
                ApprovedBy = null,
                Status = requestInfo.RequestStatus,
                CreatedDate = DateTime.Now,
                ModifiedDate = null
            };

            await db.Requests.AddAsync(newRequest);

            var result = await db.SaveChangesAsync();
            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_REQUEST));

            return newRequest.RequestID;
        }

        private async Task<string> GetNewRequestIDAsync(SMDbContext db)
        {
            var requestIDs = await db.Requests.Where(data => data.RequestDate == Globals.EXEC_DATE)
                                                 .OrderByDescending(data => data.RequestID)
                                                 .Select(data => data.RequestID)
                                                 .ToListAsync();

            if (!requestIDs.Any())
                return string.Format(Constants.FORMAT_REQUEST_ID, Globals.EXEC_REQ_DATE, Constants.DEFAULT_REQ_ID_SUFFIX);

            var latestRequestID = requestIDs.First();
            var currentSuffix = latestRequestID.Substring(Constants.LENGTH_REQ_ID_PREFIX, Constants.LENGTH_REQ_ID_SUFFIX);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.LENGTH_REQ_ID_SUFFIX, Constants.CHAR_ZERO);

            return string.Format(Constants.FORMAT_REQUEST_ID, Globals.EXEC_REQ_DATE, newSuffix);
        }
    }
}
