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

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await dbContext.Etudiants.ToListAsync());
        }

        [HttpPost]
        public async Task<ActionResult<List<Etudiant>>> CreateEtudiant([FromBody] Etudiant etudiant)
        {
            await dbContext.Etudiants.AddAsync(etudiant);

            return Ok(dbContext.Etudiants);
        }

        [HttpPut]
        public async Task<ActionResult<List<Etudiant>>> UpdateEtudiant(Etudiant request)
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

            return Ok(etudiant);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Etudiant>> Get(int id)
        {
            var etudiant = await dbContext.Etudiants.FindAsync(request.EtudiantId);
            if (etudiant == null)
            {
                return NotFound("Etudiant not Found");
            }
            return Ok(etudiant);
        }
    }
}