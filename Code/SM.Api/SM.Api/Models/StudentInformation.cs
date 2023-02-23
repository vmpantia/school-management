using SM.Api.Commons;
using SM.Api.DataAccess.Models;
using System.ComponentModel.DataAnnotations;

namespace SM.Api.Models
{
    public class StudentInformation : OtherInformation
    {
        public Student student { get; set; }

        public string FullName {
            get
            {
                if (student == null)
                    return Constants.NA;

                 return string.Format(Constants.FORMAT_FULLNAME, student.FirstName, student.LastName);
            }
        }

        public string Age
        {
            get
            {
                if (student == null)
                    return Constants.NA;

                return (Globals.EXEC_YEAR - student.Birthdate.Year).ToString();
            }
        }
    }
}
