using Microsoft.EntityFrameworkCore;
using SM.Api.DataAccess.Models;
using SM.Api.DataAccess.Models.Transaction;

namespace SM.Api.DataAccess
{
    public class SMDbContext : DbContext
    {
        public SMDbContext() : base() { }
        public SMDbContext(DbContextOptions<SMDbContext> options) : base(options) { }
        public virtual DbSet<Student> Students { get; set; }
        public virtual DbSet<Teacher> Teachers { get; set; }
        public virtual DbSet<Address> Addresses { get; set; }
        public virtual DbSet<Contact> Contacts { get; set; }
        public virtual DbSet<Request> Requests { get; set; }


        public virtual DbSet<Student_TRN> Student_TRN { get; set; }
        public virtual DbSet<Teacher_TRN> Teacher_TRN { get; set; }
        public virtual DbSet<Address_TRN> Address_TRN { get; set; }
        public virtual DbSet<Contact_TRN> Contact_TRN { get; set; }
    }
}
