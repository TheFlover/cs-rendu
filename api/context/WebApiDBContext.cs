using Database;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base(options) { 
        }

        public DbSet<Hero> Heroes{ get; set; }

    }
}