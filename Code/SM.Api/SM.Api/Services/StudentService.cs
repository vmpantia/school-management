using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SM.Api.Commons;
using SM.Api.Contractors;
using SM.Api.DataAccess;
using SM.Api.DataAccess.Models;
using SM.Api.Exceptions;
using SM.Api.Models.Requests;
using System.Net;

namespace SM.Api.Services
{
    public class StudentService : IStudentService
    {
        private readonly SMDbContext _db;
        private readonly ICommonService _common;
        public StudentService(SMDbContext context, ICommonService common)
        {
            _db = context;
            _common = common;
        }

        public async Task SaveStudent(SaveStudentRequest request)
        {
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.MODEL_STUDENT));

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    await InsertStudentAsync(request.inputStudent);
                    await _common.InsertContactsAsync(_db, request.inputStudent.InternalID, request.inputContacts);
                    await _common.InsertAddressesAsync(_db, request.inputStudent.InternalID, request.inputAddresses);

                    //await UpdateStudentAsync(request.inputStudent);
                    //await _common.UpdateContactsAsync(_db, request.inputStudent.InternalID, request.inputContacts);
                    //await _common.UpdateAddressesAsync(_db, request.inputStudent.InternalID, request.inputAddresses);

                    await transaction.CommitAsync();
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }
        }

        private async Task InsertStudentAsync(Student stud)
        {
            if (stud == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_STUDENT));

            stud.InternalID = Guid.NewGuid();
            stud.StudentID = await GenerateStudentIDAsync();
            stud.CreatedDate = Globals.EXEC_DATE;
            stud.ModifiedDate = null;

            await _db.Students.AddAsync(stud);

            var result = await _db.SaveChangesAsync();
            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_STUDENT));
        }

        private async Task UpdateStudentAsync(Student stud)
        {
            if (stud == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_STUDENT));

            var currStud = await _db.Students.FindAsync(stud.InternalID);
            if (currStud == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_ID_NOT_FOUND, Constants.MODEL_STUDENT));

            //currStud.InternalID = stud.InternalID;
            //currStud.StudentID = stud.StudentID;
            currStud.FirstName = stud.FirstName;
            currStud.MiddleName = stud.MiddleName;
            currStud.LastName = stud.LastName;
            currStud.Gender = stud.Gender;
            currStud.Birthdate = stud.Birthdate;
            currStud.Status = stud.Status;
            //currStud.CreatedDate = stud.CreatedDate;
            currStud.ModifiedDate = Globals.EXEC_DATE;

            var result = await _db.SaveChangesAsync();
            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_STUDENT));
        }

        private async Task<string> GenerateStudentIDAsync()
        {
            var studentIDs = await _db.Students.OrderByDescending(data => data.StudentID)
                                               .Select(data => data.StudentID)
                                               .ToListAsync();

            if (!studentIDs.Any())
                return string.Format(Constants.FORMAT_STUDENT_ID, Constants.DEFAULT_ID_SUFFIX);

            var latestStudentID = studentIDs.First();
            var currentSuffix = latestStudentID.Substring(Constants.LENGTH_ID_PREFIX, Constants.LENGTH_ID_SUFFIX);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.LENGTH_ID_SUFFIX, Constants.CHAR_ZERO);

            return string.Format(Constants.FORMAT_STUDENT_ID, newSuffix);
        }
    }
}
