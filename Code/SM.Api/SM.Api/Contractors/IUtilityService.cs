using SM.Api.DataAccess.Models;

namespace SM.Api.Contractors
{
    public interface IUtilityService
    {
        bool isStudentAvailable(Student student);
        bool isContactAvailable(Contact address);
        bool isAddressAvailable(Address address);
    }
}