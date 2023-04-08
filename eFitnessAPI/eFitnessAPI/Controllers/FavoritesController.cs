using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.FavoritesVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class FavoritesController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public FavoritesController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet("{id}")]
        public ActionResult GetByClan(int id) 
        {
            var podaci = dbContext.Favorites.Where(x => x.korisnik_id == id)
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] FavoritesAddVM x)
        {
            var noviFavorite = new Favorites
            {
                korisnik_id=x.clanID,
                vjezba_id=x.vjezbaID
            };

            dbContext.Add(noviFavorite);
            dbContext.SaveChanges();
            return Ok(noviFavorite);
        }

        [HttpDelete]
        public ActionResult Remove([FromBody] FavoritesAddVM x)
        {
            var favorite = dbContext.Favorites.Where(f => f.korisnik_id == x.clanID && f.vjezba_id == x.vjezbaID).First();
            if (favorite != null)
            {
                dbContext.Remove(favorite);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");
            return Ok();
        }
    }
}
