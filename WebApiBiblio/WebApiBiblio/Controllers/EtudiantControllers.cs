using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EtudiantController : ControllerBase
    {
        private readonly WebApiBiblioDbContext dbContext;

        public EtudiantController(WebApiBiblioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetEtudiants")]
        public async Task<ActionResult<List<Etudiant>>> Get()
        {
            return Ok(await dbContext.Etudiants.ToListAsync());
        }

        [HttpGet("GetEtudiant/{id}")]
        public async Task<ActionResult> GetEtudiant(int id)
        {
            var etudiant = await this.dbContext.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return BadRequest();
            }

            return Ok(etudiant);
        }

        [HttpPost("AddEtudiant")]
        public async Task<ActionResult<Etudiant>> CreateEtudiant([FromBody] Etudiant etudiant)
        {
            var Uri = await dbContext.Etudiants.AddAsync(etudiant);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEtudiant), new { id = etudiant.EtudiantId }, etudiant);
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPut("PutEtudiant/{id}")]
    public async Task<IActionResult> PutEtudiant(int id, Etudiant etudiant)
    {
        if (id != etudiant.EtudiantId)
        {
            return BadRequest();
        }

        var entityEtudiant = await dbContext.Etudiants.FindAsync(id);
        if (entityEtudiant == null)
        {
            return NotFound();
        }

        entityEtudiant.Nom = etudiant.Nom;
        entityEtudiant.Prenom = etudiant.Prenom;
        entityEtudiant.Naissance = etudiant.Naissance;
        entityEtudiant.Telephone = etudiant.Telephone;

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

        [HttpDelete("RemoveEtudiant/{id}")]
        public async Task<ActionResult> DeleteEtudiant(int id)
        {
            var etudiant = await this.dbContext.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return NotFound();
            }

            dbContext.Etudiants.Remove(etudiant);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(int id)
    {
        return dbContext.Etudiants.Any(etudiant => etudiant.EtudiantId == id);
    }
    }
}