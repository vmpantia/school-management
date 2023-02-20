using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models
{
    public class Teacher
    {
        [Key]
        public Guid InternalID { get; set; }
        public string TeacherID { get; set; }
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
