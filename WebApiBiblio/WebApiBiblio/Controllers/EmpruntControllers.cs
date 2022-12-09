using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpruntController : ControllerBase
    {
        private readonly WebApiBiblioDbContext dbContext;

        public EmpruntController(WebApiBiblioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetEmprunts")]
        public async Task<ActionResult<List<Emprunt>>> Get()
        {
            return Ok(await dbContext.Emprunts.ToListAsync());
        }

        [HttpGet("GetEmprunt/{id}")]
        public async Task<ActionResult> GetEmprunt(int id)
        {
            var emprunt = await this.dbContext.Emprunts.FindAsync(id);
            if (emprunt == null)
            {
                return BadRequest();
            }

            return Ok(emprunt);
        }

        [HttpPost("AddEmprunt")]
        public async Task<ActionResult<Emprunt>> CreateEmprunt([FromBody] Emprunt emprunt)
        {
            var Uri = await dbContext.Emprunts.AddAsync(emprunt);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmprunt), new { id = emprunt.EmpruntId }, emprunt);
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPut("PutEmprunt/{id}")]
    public async Task<IActionResult> PutEmprunt(int id, Emprunt emprunt)
    {
        if (id != emprunt.EmpruntId)
        {
            return BadRequest();
        }

        var entityEmprunt = await dbContext.Emprunts.FindAsync(id);
        if (entityEmprunt == null)
        {
            return NotFound();
        }

        entityEmprunt.EtudiantId = emprunt.EtudiantId;
        entityEmprunt.LivreId = emprunt.LivreId;
        entityEmprunt.DateEmprunt = emprunt.DateEmprunt;
        entityEmprunt.DateRetour = emprunt.DateRetour;

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

        [HttpDelete("RemoveEmprunt/{id}")]
        public async Task<ActionResult> DeleteEmprunt(int id)
        {
            var emprunt = await this.dbContext.Emprunts.FindAsync(id);
            if (emprunt == null)
            {
                return NotFound();
            }

            dbContext.Emprunts.Remove(emprunt);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(int id)
    {
        return dbContext.Emprunts.Any(emprunt => emprunt.EmpruntId == id);
    }
    }
}