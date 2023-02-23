using SM.Api.Commons;
using SM.Api.Contractors;
using SM.Api.DataAccess.Models;
using SM.Api.Models.enums;

namespace SM.Api.Services
{
    public class UtilityService : IUtilityService
    {
        public bool isStudentAvailable(Student student)
        {
            if (student == null)
                return false;

            return student.Status == (int)Status.ENABLED;
        }

        public bool isContactAvailable(Contact contact)
        {
            if (contact == null)
                return false;

            return contact.Status == (int)Status.ENABLED;
        }

        public bool isAddressAvailable(Address address)
        {
            if (address == null)
                return false;

            return address.Status == (int)Status.ENABLED;
        }
    }
}
