using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanVM;
using eFitnessAPI.ViewModels.KorisnikVM;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClanController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ClanController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Clan
                .Select(x => new ClanGetAllVM
                {
                    ime=x.ime,
                    prezime=x.prezime,
                    datumRodjenja=x.datumRodjenja,
                    spol=x.spol
                })
                .ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ClanAddVM x)
        {
            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;
           


            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ClanAddVM x, int id)
        {
            var clan = dbContext.Clan.Find(id);

            if (clan != null)
            {
                clan.datumRodjenja = x.datum_rodjenja;
                clan.ime = x.ime;
                clan.prezime = x.prezime;
            }

            dbContext.SaveChanges();

            return Ok(clan);
        }


        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            dbContext.Korisnik.Remove(korisnik);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
