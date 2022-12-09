using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuteurController : ControllerBase
    {
        private readonly WebApiBiblioDbContext dbContext;

        public AuteurController(WebApiBiblioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetAuteurs")]
        public async Task<ActionResult<List<Auteur>>> Get()
        {
            return Ok(await dbContext.Auteurs.ToListAsync());
        }

        [HttpGet("GetAuteur/{id}")]
        public async Task<ActionResult> GetAuteur(int id)
        {
            var auteur = await this.dbContext.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return BadRequest();
            }

            return Ok(auteur);
        }

        [HttpPost("AddAuteur")]
        public async Task<ActionResult<Auteur>> CreateAuteur([FromBody] Auteur auteur)
        {
            var Uri = await dbContext.Auteurs.AddAsync(auteur);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAuteur), new { id = auteur.AuteurId }, auteur);
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPut("PutAuteur/{id}")]
    public async Task<IActionResult> PutAuteur(int id, Auteur auteur)
    {
        if (id != auteur.AuteurId)
        {
            return BadRequest();
        }

        var entityAuteur = await dbContext.Auteurs.FindAsync(id);
        if (entityAuteur == null)
        {
            return NotFound();
        }

        entityAuteur.Nom = auteur.Nom;
        entityAuteur.Prenom = auteur.Prenom;

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

        [HttpDelete("RemoveAuteur/{id}")]
        public async Task<ActionResult> DeleteAuteur(int id)
        {
            var auteur = await this.dbContext.Auteurs.FindAsync(id);
            if (auteur == null)
            {
                return NotFound();
            }

            dbContext.Auteurs.Remove(auteur);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(int id)
    {
        return dbContext.Auteurs.Any(auteur => auteur.AuteurId == id);
    }
    }
}