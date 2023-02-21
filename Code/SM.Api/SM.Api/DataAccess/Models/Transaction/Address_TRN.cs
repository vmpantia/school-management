using Azure.Core;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace SM.Api.DataAccess.Models.Transaction
{
    [PrimaryKey(nameof(RequestID), nameof(Number), nameof(InternalID))]
    public class Address_TRN
    {
        [MaxLength(15)]
        public string RequestID { get; set; }
        public int Number { get; set; }
        public Guid InternalID { get; set; }
        public Guid RelationID { get; set; }
        public int Type { get; set; }
        [Required, MaxLength(50)]
        public string Line1 { get; set; }
        [Required, MaxLength(50)]
        public string Line2 { get; set; }
        [Required, MaxLength(50)]
        public string Barangay { get; set; }
        [Required, MaxLength(50)]
        public string City { get; set; }
        [Required, MaxLength(50)]
        public string ZipCode { get; set; }
        [Required, MaxLength(50)]
        public string Province { get; set; }
        [Required, MaxLength(50)]
        public string Country { get; set; }
        public int Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? ModifiedDate { get; set; }
    }
}
