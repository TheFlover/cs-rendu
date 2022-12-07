using Microsoft.AspNetCore.Mvc; 

namespace api.Controllers;

[ApiController]
[Route("[controller]")]
public class HeroController : ControllerBase
{
    private static List<Hero> heroes = new List<Hero>
    {
        new Hero {Id = 1, Name = "IronMan", RealName = "Tony Stark"},
        new Hero {Id = 2, Name = "Captain America", RealName = "Steve Rogers"}, 
        new Hero {Id = 3, Name = "Thor", RealName = "Thor"}, 
        new Hero {Id = 4, Name = "Hulk", RealName = "Bruce Banner"}
    }; 
    private readonly WebApiDbContext _context; 

    public HeroController(WebApiDbContext apiDbContext) 
    {
        this._context = apiDbContext;
    }

    [HttpGet]
    public async Task<ActionResult<List<Hero>>> GetHeroes()
    {
        var myHeroes = await _context.Heroes.ToListAsync(); 
        return Ok(myHeroes); 
    }

    [HttpPost]
    public async Task<ActionResult<List<Hero>>> CreateHero([FromBody]Hero newHero)
    {
        heroes.Add(newHero); 
        return Ok(heroes); 
    }
}