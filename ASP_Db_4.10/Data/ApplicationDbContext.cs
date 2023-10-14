using ASP_Db_4._10.Model;
using Microsoft.EntityFrameworkCore;

namespace ASP_Db_4._10.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }        

        public DbSet<MobilePhone> MobilePhones { get; set; }
        public DbSet<Brand> Brands { get; set; }
    }
}
