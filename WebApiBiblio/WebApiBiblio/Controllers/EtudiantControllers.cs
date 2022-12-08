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
            await dbContext.Etudiants.AddAsync(etudiant);

            return Ok(dbContext.Etudiants);
        }

        [HttpPatch("UpdateEtudiant/{id}")]
        public async Task<ActionResult<Etudiant>> UpdateEtudiant(Etudiant request)
        {
            var etudiant = await this.dbContext.Etudiants.FindAsync(request.EtudiantId);
            if (etudiant == null)
            {
                return BadRequest(request);
            }

            etudiant.Nom = request.Nom;
            etudiant.Prenom = request.Prenom;
            etudiant.Naissance = request.Naissance;
            etudiant.Telephone = request.Telephone;

            dbContext.Etudiants.Update(etudiant);
            await dbContext.SaveChangesAsync();
            return Ok(etudiant);
        }

        [HttpDelete("RemoveEtudiant/{id}")]
        public async Task<ActionResult> DeleteEtudiant(int id)
        {
            var etudiant = await this.dbContext.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return BadRequest();
            }

            dbContext.Etudiants.Remove(etudiant);
            await dbContext.SaveChangesAsync();
            return Ok(etudiant);
        }
    }
}