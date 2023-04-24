using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.ViewModels.ClanarinaVM;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClanarinaController : ControllerBase

    {
        private readonly ApplicationDbContext _dbContext;

        
        public ClanarinaController(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }



        [HttpGet]
        public ActionResult GetAll()
        {

            var podaci = _dbContext.Clanarina.
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
        [HttpGet]
        public ActionResult GetByKorisnik()
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("nije logiran");

            var korisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var podaci = _dbContext.Clanarina
                .Include(x=>x.vrstaClanarine)
                .Where(x => x.korisnik_id == korisnik.id)
                .ToList();

            return Ok(podaci);
        }


        [HttpPost]
        public ActionResult Add([FromBody] ClanarinaAddVM x)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Nije logiran");

            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            if (_dbContext.Clanarina.Any(c => c.korisnik_id == x.korisnik_id && c.aktivna))
                return BadRequest("Već ste učlanjeni");

            var novaClanarina = new Clanarina()
            {
                datumIsteka = x.datumIsteka,
                datumKreiranja = DateTime.Now,
                vrsta_clanarine_id = x.vrsta_clanarine_id,
                korisnik_id = x.korisnik_id,
                aktivna = true
            };
            _dbContext.Clanarina.Add(novaClanarina);
            _dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ClanarinaAddVM x,int id)
        {
            if (!HttpContext.GetLoginInfo().isLogiran)
                return BadRequest("Nije logiran");

            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            var objekat = _dbContext.Clanarina
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
            _dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = _dbContext.Clanarina.Find(id);
            if (objekat != null)
            {
                _dbContext.Clanarina.Remove(objekat);
                _dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }


    }
}
