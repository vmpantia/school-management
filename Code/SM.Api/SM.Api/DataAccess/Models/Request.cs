using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models
{
    public class Request
    {
        [Key, Required, MaxLength(15)]
        public string RequestID { get; set; }
        [Required, MaxLength(5)]
        public string FunctionID { get; set; }
        public DateTime RequestDate { get; set; }
        public Guid RequestBy { get; set; }
        public DateTime? ApprovedDate { get; set; }
        public Guid? ApprovedBy { get; set; }
        [Required, MaxLength(2)]
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
