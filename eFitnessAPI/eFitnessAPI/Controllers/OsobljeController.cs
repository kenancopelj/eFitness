using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.OsobljeVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class OsobljeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public OsobljeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Osoblje.
                Select(x => new OsobljeGetAllVM
                {
                    ime = x.Ime,
                    prezime = x.Prezime,
                    datumRodjenja = x.DatumRodjenja,
                    datumZaposlenja = x.datumZaposlenja,
                    spolId = x.spol_id
                })
                .ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] OsobljeAddVM x)
        {
            var novi = new Osoblje()
            {
                Ime = x.ime,
                Prezime = x.prezime,
                datumZaposlenja = x.datumZaposlenja,
                spol_id = x.spolId
            };
            dbContext.Osoblje.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] OsobljeAddVM x, int id)
        {
            var objekat = dbContext.Osoblje.Find(id);
            if (objekat != null)
            {
                objekat.Ime = x.ime;
                objekat.Prezime = x.prezime;
                objekat.DatumRodjenja = x.datumRodjenja;
                objekat.datumZaposlenja = x.datumZaposlenja;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Osoblje.Find(id);
            if (objekat != null)
            {
                dbContext.Osoblje.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }

    }
}
