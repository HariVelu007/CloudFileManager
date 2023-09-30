using CFMDomainModel;
using Microsoft.EntityFrameworkCore;

namespace CFMServices.Config
{
    public class CFMContext : DbContext
    {
        public CFMContext(DbContextOptions<CFMContext> db) : base(db)
        {

        }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFile> UserFiles { get; set; }
        public DbSet<UserFileAccess> UserFileAccess { get; set; }
       
    }
}