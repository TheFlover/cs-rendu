using Database;
using Microsoft.EntityFrameworkCore;

namespace WebApiBiblio.Context
{
    public class WebApiBiblioDbContext: DbContext
    {
        public WebApiBiblioDbContext(DbContextOptions<WebApiBiblioDbContext> options): base(options) { 
        }

        public DbSet<Etudiant> Etudiants{ get; set; }
        public DbSet<Emprunt> Emprunts{ get; set; }
        public DbSet<Livre> Livres{ get; set; }
        public DbSet<Auteur> Auteurs{ get; set; }
        public DbSet<Categorie> Categories{ get; set; }

    }
}