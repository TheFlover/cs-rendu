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

            //return Created( etudiant);
            return Ok();
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPatch("UpdateEtudiant/{id}")]
        public async Task<ActionResult<Etudiant>> UpdateEtudiant(int id, [FromBody] Etudiant etudiant)
        {
            var entityEtudiant = await this.dbContext.Etudiants.FindAsync(id);
            if (etudiant == null)
            {
                return BadRequest();
            }

            entityEtudiant.Nom = etudiant.Nom == null ? entityEtudiant.Nom : etudiant.Nom;
            entityEtudiant.Prenom = etudiant.Prenom == null ? entityEtudiant.Prenom : etudiant.Prenom;
            entityEtudiant.Naissance = etudiant.Naissance == null ? entityEtudiant.Naissance : etudiant.Naissance;
            entityEtudiant.Telephone = etudiant.Telephone == null ? entityEtudiant.Telephone : etudiant.Telephone;

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
            return Ok();
        }
    }
}