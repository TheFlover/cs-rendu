using Database;
using Microsoft.EntityFrameworkCore;

namespace WebApiBiblio.Context
{
    public class WebApiBiblioDbContext: DbContext
    {
        public WebApiBiblioDbContext(DbContextOptions<WebApiBiblioDbContext> options): base(options) { 
        }

        public DbSet<Etudiant> Etudiants{ get; set; }

    }
}