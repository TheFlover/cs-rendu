using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivreController : ControllerBase
    {
        private readonly WebApiBiblioDbContext dbContext;

        public LivreController(WebApiBiblioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetLivres")]
        public async Task<ActionResult<List<Livre>>> Get()
        {
            return Ok(await dbContext.Livres.ToListAsync());
        }

        [HttpGet("GetLivre/{id}")]
        public async Task<ActionResult> GetLivre(int id)
        {
            var livre = await this.dbContext.Livres.FindAsync(id);
            if (livre == null)
            {
                return BadRequest();
            }

            return Ok(livre);
        }

        [HttpPost("AddLivre")]
        public async Task<ActionResult<Livre>> CreateLivre([FromBody] Livre livre)
        {
            var Uri = await dbContext.Livres.AddAsync(livre);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetLivre), new { id = livre.LivreId }, livre);
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPut("PutLivre/{id}")]
    public async Task<IActionResult> PutLivre(int id, Livre livre)
    {
        if (id != livre.LivreId)
        {
            return BadRequest();
        }

        var entityLivre = await dbContext.Livres.FindAsync(id);
        if (entityLivre == null)
        {
            return NotFound();
        }

        entityLivre.Titre = livre.Titre;
        entityLivre.AuteurId = livre.AuteurId;
        entityLivre.CategorieId = livre.CategorieId;
        entityLivre.DatePublication = livre.DatePublication;

        try
        {
            await dbContext.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException) when (!TodoItemExists(id))
        {
            return NotFound();
        }

        return NoContent();
    }

        [HttpDelete("RemoveLivre/{id}")]
        public async Task<ActionResult> DeleteLivre(int id)
        {
            var livre = await this.dbContext.Livres.FindAsync(id);
            if (livre == null)
            {
                return NotFound();
            }

            dbContext.Livres.Remove(livre);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(int id)
    {
        return dbContext.Livres.Any(livre => livre.LivreId == id);
    }
    }
}