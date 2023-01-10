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
                    ime = x.ime,
                    prezime = x.prezime,
                    datumRodjenja = x.datumRodjenja,
                    datumZaposlenja = x.datumZaposlenja,
                    spol = x.spol
                })
                .ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] OsobljeAddVM x)
        {
            var novi = new Osoblje()
            {
                ime = x.ime,
                prezime = x.prezime,
                datumRodjenja = x.datumRodjenja,
                datumZaposlenja = x.datumZaposlenja,
                spol = x.spol
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
                objekat.ime = x.ime;
                objekat.prezime = x.prezime;
                objekat.datumRodjenja = x.datumRodjenja;
                objekat.datumZaposlenja = x.datumZaposlenja;
                objekat.spol = x.spol;
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
