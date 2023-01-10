using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.GrupniTreningVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GrupniTreningController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public GrupniTreningController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll() 
        {
            var podaci = dbContext.GrupniTrening
                .Select(x => new GrupniTreningGetAllVM
                {
                    kategorija_id= x.kategorija_id,
                    naziv_kategorije=x.kategorija.naziv,
                    vrijeme_odrzavanja=x.vrijemeOdrzavanja
                }).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] GrupniTreningAddVM x)
        {
            var noviTrening = new GrupniTrening
            {
                kategorija_id=x.kategorija_id,
                vrijemeOdrzavanja=x.vrijeme_odrzavanja
            };

            dbContext.Add(noviTrening);
            dbContext.SaveChanges();

            return Ok(noviTrening);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]GrupniTreningAddVM x, int treningID)
        {
            var trening = dbContext.GrupniTrening.Find(treningID);

            if (trening != null)
            {
                trening.vrijemeOdrzavanja = x.vrijeme_odrzavanja;
                trening.kategorija_id = x.kategorija_id;

                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok();
        }

    }
}
