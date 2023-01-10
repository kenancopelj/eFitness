using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.SuplementVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SuplementController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SuplementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Suplement.
                Select(x => new SuplementGetAllVM
                {
                    naziv = x.naziv,
                    rokTrajanja = x.rokTrajanja,
                    opis = x.opis,
                    cijena = x.cijena,
                    kategorija_id=x.kategorija_id
                })
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] SuplemetAddVM x)
        {
            var novi = new Suplement()
            {
                naziv = x.naziv,
                rokTrajanja = x.rokTrajanja,
                opis = x.opis,
                cijena = x.cijena,
                kategorija_id = x.kategorija_id
            };
            dbContext.Suplement.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] SuplemetAddVM x, int id)
        {
            var objekat = dbContext.Suplement.Find(id);
            if (objekat != null)
            {
                objekat.naziv = x.naziv;
                objekat.rokTrajanja = x.rokTrajanja;
                objekat.opis = x.opis;
                objekat.cijena = x.cijena;
                objekat.kategorija_id = x.kategorija_id;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Suplement.Find(id);
            if (objekat != null)
            {
                dbContext.Suplement.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }

    }
}
