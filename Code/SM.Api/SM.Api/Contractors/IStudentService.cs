using SM.Api.Models;
using SM.Api.Models.Requests;

namespace SM.Api.Contractors
{
    public interface IStudentService
    {
        Task<IEnumerable<StudentInformation>> GetStudentsAsync();
        Task<string> SaveStudentAsync(SaveStudentRequest request);
    }
}