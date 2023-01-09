using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels;
using eFitnessAPI.ViewModels.KorisnikVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public KorisnikController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Korisnik
                .Select(x => new KorisnikGetAllVM
                {
                    korisnicko_ime=x.korisnikoIme,
                    slika=x.slika
                })
                .ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] KorisnikAddVM x)
        {
            var noviKorisnik = new Korisnik()
            {
                korisnikoIme = x.korisnicko_ime,
                lozinka = x.lozinka,
                slika = x.slika
            };

            dbContext.Korisnik.Add(noviKorisnik);
            dbContext.SaveChanges();

            return Ok(noviKorisnik);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] KorisnikAddVM x, int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            if (korisnik != null)
            {
                korisnik.korisnikoIme = x.korisnicko_ime;
                korisnik.lozinka = x.lozinka;
                korisnik.slika = x.slika;
            }
            dbContext.SaveChanges();

            return Ok(korisnik);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            if (korisnik != null)
            {
                dbContext.Korisnik.Remove(korisnik);
                dbContext.SaveChanges();
            }

            return Ok();
        }


    }
}
