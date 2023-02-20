using Microsoft.EntityFrameworkCore;
using SM.Api.DataAccess.Models;

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
    }
}
