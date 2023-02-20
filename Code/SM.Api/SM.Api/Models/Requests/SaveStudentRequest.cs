using SM.Api.DataAccess.Models;

namespace SM.Api.Models.Requests
{
    public class SaveStudentRequest : RequestBase
    {
        public Student inputStudent { get; set; }
        public List<Contact> inputContacts { get; set; }
        public List<Address> inputAddresses { get; set; }
    }
}
