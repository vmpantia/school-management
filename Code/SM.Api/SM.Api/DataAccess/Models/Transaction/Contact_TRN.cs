using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models.Transaction
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(InternalID))]
    public class Contact_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
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
