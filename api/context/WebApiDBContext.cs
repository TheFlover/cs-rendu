using Microsoft.EntityFrameworkCore; 

public class WebApiDbContext: DbContext 
{
    public WebApiDbContext(DbContextOptions<WebApiDbContext> options) : base(options) 
    {
        
    }

    public DbSet<Hero> Heroes { get; set; }
}