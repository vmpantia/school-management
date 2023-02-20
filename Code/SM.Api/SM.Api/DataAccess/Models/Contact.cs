using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models
{
    public class Contact
    {
        [Key]
        public Guid InternalID { get; set; }
        public Guid RelationID { get; set; }
        public int Type { get; set; }
        [Required, MaxLength(100)]
        public string Value { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
