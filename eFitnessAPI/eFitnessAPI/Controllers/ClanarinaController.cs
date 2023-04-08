using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClanarinaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ClanarinaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }



        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Clanarina.
                Select(x => new ClanarinaGetAllVM
                {
                    datumIsteka = x.datumIsteka,
                    datumKreiranja = x.datumKreiranja,
                    vrsta_clanarine_id = x.vrsta_clanarine_id,
                    aktivna = x.aktivna,
                    korisnikDto = new KorisnikDto
                    {
                        korisnikId = x.korisnik_id,
                        Ime = x.korisnik.Ime,
                        Prezime = x.korisnik.Prezime
                    }
                })
                .ToList();

            return Ok(podaci);
        }


        [HttpPost]
        public ActionResult Add([FromBody] ClanarinaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Nije logiran");

            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var novaClanarina = new Clanarina()
            {
                datumIsteka = x.datumIsteka,
                datumKreiranja = DateTime.Now,
                vrsta_clanarine_id = x.vrsta_clanarine_id,
                korisnik_id = x.korisnik_id,
                aktivna = true
            };
            dbContext.Clanarina.Add(novaClanarina);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ClanarinaAddVM x,int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Nije logiran");

            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var objekat = dbContext.Clanarina
                //.Where(x=> trenutniKorisnik.id == x.korisnik_id && id==x.id )
                .First();

            if (objekat != null)
            {
                objekat.datumKreiranja = x.datumKreiranja;
                objekat.datumIsteka = x.datumIsteka;
                objekat.vrsta_clanarine_id = x.vrsta_clanarine_id;
                objekat.aktivna = x.aktivna;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Clanarina.Find(id);
            if (objekat != null)
            {
                dbContext.Clanarina.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }


    }
}
