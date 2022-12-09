using Database;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace WebApiBiblio.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategorieController : ControllerBase
    {
        private readonly WebApiBiblioDbContext dbContext;

        public CategorieController(WebApiBiblioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("GetCategories")]
        public async Task<ActionResult<List<Categorie>>> Get()
        {
            return Ok(await dbContext.Categories.ToListAsync());
        }

        [HttpGet("GetCategorie/{id}")]
        public async Task<ActionResult> GetCategorie(int id)
        {
            var categorie = await this.dbContext.Categories.FindAsync(id);
            if (categorie == null)
            {
                return BadRequest();
            }

            return Ok(categorie);
        }

        [HttpPost("AddCategorie")]
        public async Task<ActionResult<Categorie>> CreateCategorie([FromBody] Categorie categorie)
        {
            var Uri = await dbContext.Categories.AddAsync(categorie);
            await dbContext.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCategorie), new { id = categorie.CategorieId }, categorie);
        }


        // Verifie les differences entre PUT et PATCH 
        //PUT ecrase tandis que patch permet une modification partielle
        [HttpPut("PutCategorie/{id}")]
    public async Task<IActionResult> PutCategorie(int id, Categorie categorie)
    {
        if (id != categorie.CategorieId)
        {
            return BadRequest();
        }

        var entityCategorie = await dbContext.Categories.FindAsync(id);
        if (entityCategorie == null)
        {
            return NotFound();
        }

        entityCategorie.Nom = categorie.Nom;

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

        [HttpDelete("RemoveCategorie/{id}")]
        public async Task<ActionResult> DeleteCategorie(int id)
        {
            var categorie = await this.dbContext.Categories.FindAsync(id);
            if (categorie == null)
            {
                return NotFound();
            }

            dbContext.Categories.Remove(categorie);
            await dbContext.SaveChangesAsync();
            return NoContent();
        }

        private bool TodoItemExists(int id)
    {
        return dbContext.Categories.Any(categorie => categorie.CategorieId == id);
    }
    }
}