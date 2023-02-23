using Microsoft.AspNetCore.Components.Forms;
using Microsoft.EntityFrameworkCore;
using SM.Api.Commons;
using SM.Api.Contractors;
using SM.Api.DataAccess;
using SM.Api.DataAccess.Models;
using SM.Api.DataAccess.Models.Transaction;
using SM.Api.Exceptions;
using SM.Api.Models;
using SM.Api.Models.enums;
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

        public async Task<IEnumerable<StudentInformation>> GetStudentsAsync()
        {
            var students = await _db.Students.ToListAsync();

            var newStudents = new List<StudentInformation>();

            foreach(var student in students)
            {
                newStudents.Add(new StudentInformation
                {
                    student = student,
                    CellphoneNo = await _common.GetContactByTypeAsync(student.InternalID, ContactType.CELLPHONE_NO),
                    EmailAddress = await _common.GetContactByTypeAsync(student.InternalID, ContactType.EMAILADDRESS),
                    PresentAddress = await _common.GetAddressyTypeAsync(student.InternalID, AddressType.PRESENT),
                    PermanentAddress = await _common.GetAddressyTypeAsync(student.InternalID, AddressType.PERMANENT),
                    ProvincialAddress = await _common.GetAddressyTypeAsync(student.InternalID, AddressType.PROVINCIAL)
                });
            }

            return newStudents;
        }

        public async Task<string> SaveStudentAsync(SaveStudentRequest request)
        {
            if (request == null)
                throw new APIException(string.Format(Constants.ERROR_REQUEST_NULL, Constants.MODEL_STUDENT));

            using (var transaction = await _db.Database.BeginTransactionAsync())
            {
                try
                {
                    //Insert Request
                    var requestID = await _common.InsertRequestAsync(_db, request);
                    switch(request.FunctionID)
                    {
                        case Constants.FUNCTION_ID_ADD_STUDENT:
                            //Insert Main Records
                            await InsertStudentAsync(request.inputStudent);
                            await _common.InsertContactsAsync(_db, request.inputStudent.InternalID, request.inputContacts);
                            await _common.InsertAddressesAsync(_db, request.inputStudent.InternalID, request.inputAddresses);
                            break;

                        case Constants.FUNCTION_ID_CHANGE_STUDENT:
                            //Update Main Records
                            await UpdateStudentAsync(request.inputStudent);
                            await _common.UpdateContactsAsync(_db, request.inputStudent.InternalID, request.inputContacts);
                            await _common.UpdateAddressesAsync(_db, request.inputStudent.InternalID, request.inputAddresses);
                            break;

                        default:
                            throw new APIException(string.Format(Constants.ERROR_FUNCTION_ID_NOT_FOUND, request.FunctionID));

                    }
                    //Insert Transactions
                    await InsertStudent_TRNAsync(request.inputStudent, requestID);
                    await _common.InsertContacts_TRNAsync(_db, request.inputContacts, requestID);
                    await _common.InsertAddress_TRNAsync(_db, request.inputAddresses, requestID);

                    await transaction.CommitAsync();

                    return requestID;
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
            stud.CreatedDate = Globals.EXEC_DATETIME;
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
            currStud.ModifiedDate = Globals.EXEC_DATETIME;

            var result = await _db.SaveChangesAsync();
            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_UPDATE, Constants.MODEL_STUDENT));
        }

        private async Task InsertStudent_TRNAsync(Student stud, string requestID)
        {
            if (stud == null)
                throw new APIException(string.Format(Constants.ERROR_MODEL_NULL, Constants.MODEL_STUDENT));

            var trn = new Student_TRN
            {
                RequestID = requestID,
                Number = 1, //Default
                InternalID = stud.InternalID,
                StudentID = stud.StudentID,
                FirstName = stud.FirstName,
                MiddleName = stud.MiddleName,
                LastName = stud.LastName,
                Gender = stud.Gender,
                Birthdate = stud.Birthdate,
                Status = stud.Status,
                CreatedDate = stud.CreatedDate,
                ModifiedDate = stud.ModifiedDate
            };

            await _db.Student_TRN.AddAsync(trn);

            var result = await _db.SaveChangesAsync();
            if (result == 0)
                throw new APIException(string.Format(Constants.ERROR_INSERT, Constants.MODEL_STUDENT_TRN));
        }

        private async Task<string> GenerateStudentIDAsync()
        {
            var studentIDs = await _db.Students.Where(data => data.CreatedDate.Year == Globals.EXEC_YEAR)
                                               .OrderByDescending(data => data.StudentID)
                                               .Select(data => data.StudentID)
                                               .ToListAsync();

            if (!studentIDs.Any())
                return string.Format(Constants.FORMAT_STUDENT_ID, Globals.EXEC_YEAR, Constants.DEFAULT_UNQ_ID_SUFFIX);

            var latestStudentID = studentIDs.First();
            var currentSuffix = latestStudentID.Substring(Constants.LENGTH_UNQ_ID_PREFIX, Constants.LENGTH_UNQ_ID_SUFFIX);
            var newSuffix = (int.Parse(currentSuffix) + 1).ToString().PadLeft(Constants.LENGTH_UNQ_ID_SUFFIX, Constants.CHAR_ZERO);

            return string.Format(Constants.FORMAT_STUDENT_ID, Globals.EXEC_YEAR, newSuffix);
        }
    }
}
