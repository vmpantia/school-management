using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models.Transaction
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(InternalID))]
    public class Student_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid InternalID { get; set; }
        [Required, MaxLength(15)]
        public string StudentID { get; set; }
        [Required, MaxLength(25)]
        public string FirstName { get; set; }
        [MaxLength(25)]
        public string? MiddleName { get; set; }
        [Required, MaxLength(25)]
        public string LastName { get; set; }
        public int Gender { get; set; }
        public DateTime Birthdate { get; set; }
        //Common Properties
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
