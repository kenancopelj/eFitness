using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.Services;
using eFitnessAPI.ViewModels;
using eFitnessAPI.ViewModels.KorisnikVM;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using FIT_Api_Examples.Modul0_Autentifikacija.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KorisnikController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IMailService _mailService;
        public KorisnikController(ApplicationDbContext dbContext, IMailService mailService)
        {
            this.dbContext = dbContext;
            this._mailService = mailService;
        }

        [HttpGet]
        public ActionResult GetTrenutni()
        {
            var trenutniKorisnik = HttpContext.GetLoginInfo().korisnickiNalog;

            return Ok(new
            {
                id = trenutniKorisnik.id,
                korisnickoIme = trenutniKorisnik.korisnikoIme,
                lozinka = trenutniKorisnik.lozinka,
            });
        }

        [HttpGet("{treningID}")]
        public ActionResult GetSlikaKorisnika(int korisnikId)
        {

            byte[] bajtovi_slike = Fajlovi.Ucitaj("slikeKorisnika/" + korisnikId + ".png")
                                   ?? Fajlovi.Ucitaj("slikeKorisnika/prva.png");

            return File(bajtovi_slike, "image/png");
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Korisnik
                .Select(x => new KorisnikGetAllVM
                {
                    ime = x.Ime,
                    prezime = x.Prezime,
                    id = x.id,
                    korisnicko_ime = x.korisnikoIme,
                    slika = x.slika,
                    is_admin = x.isAdmin
                })
                .ToList();
            return Ok(podaci);
        }

        [HttpGet("{token}")]
        public IActionResult Aktivacija(string token)
        {
            var korisnik = dbContext.Korisnik.FirstOrDefault(x=>x.aktivacijaToken == token); 
            return BadRequest("Pogrešan token");
        }


        [HttpPost]
        public ActionResult Add([FromBody] KorisnikAddVM x)
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = x.Ime,
                Prezime = x.Prezime,
                korisnikoIme = x.korisnicko_ime,
                lozinka = x.lozinka,
                slika = x.slika_korisnika_base63,
                isAdmin = x.isAdmin
            };

            var token = TokenGenerator.Generate(6);

            noviKorisnik.aktivacijaToken = token;

            _mailService.Posalji("kenancopelj@gmail.com", token);

            dbContext.Korisnik.Add(noviKorisnik);
            dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_korisnika_base63))
            {
                byte[] nova_slika = x.slika_korisnika_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slikeKorisnika/" + noviKorisnik.id + ".png");
            }

            return Ok(token);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] KorisnikAddVM x, int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            if (korisnik != null)
            {
                korisnik.Ime = x.Ime;
                korisnik.Prezime = x.Prezime;
                korisnik.korisnikoIme = x.korisnicko_ime;
                korisnik.lozinka = x.lozinka;
                korisnik.slika = x.slika_korisnika_base63;
            }


            if (!string.IsNullOrEmpty(x.slika_korisnika_base63))
            {
                byte[] nova_slika = x.slika_korisnika_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slikeKorisnika/" + korisnik.id + ".png");
            }

            dbContext.SaveChanges();

            return Ok(korisnik);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateKaoAdmin([FromBody] KorisnikUpdateKaoAdminVM x, int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            if (korisnik != null)
            {
                korisnik.Ime = x.Ime;
                korisnik.Prezime = x.Prezime;
                korisnik.korisnikoIme = x.korisnicko_ime;
                
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
