using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.PrijavaGrupnihTreningaVM;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class PrijavaGrupnihTreningaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public PrijavaGrupnihTreningaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.PrijavaGrupniTrening.
                Select(x => new PrijavaGrupnihTreningaGetAllVM
                {
                    korisnik_id=x.korisnik_id,
                    grupni_trening_id=x.grupni_trening_id,
                    datumPrijave=x.datumPrijave
                })
                .ToList();

            return Ok(podaci);
        }


        [HttpPost]
        public ActionResult Add([FromBody] PrijavaGrupnihTreningaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Niste logirani!");

            if (dbContext.PrijavaGrupniTrening.Any(p => p.korisnik_id == x.korisnik_id && p.grupni_trening_id == x.grupni_trening_id))
                return BadRequest("Već ste prijavljeni na ovaj trening");


            var novi = new PrijavaGrupniTrening()
            {
                korisnik_id = x.korisnik_id,
                grupni_trening_id = x.grupni_trening_id,
                datumPrijave = x.datumPrijave
            };
            dbContext.PrijavaGrupniTrening.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] PrijavaGrupnihTreningaAddVM x, int id)
        {
            //var objekat = dbContext.PrijavaGrupniTrening.Find(id);
            //if (objekat != null)
            //{
            //    objekat.grupni_trening_id = x.grupni_trening_id;
            //    objekat.datumPrijave = x.datumPrijave;
            //}
            //else
            //    return BadRequest("pogresan ID");
            //dbContext.SaveChanges();
            return Ok("Nije jos gotovo");
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.PrijavaGrupniTrening.Find(id);
            if (objekat != null)
            {
                dbContext.PrijavaGrupniTrening.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }
    }
}
