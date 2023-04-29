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
                korisnicko_ime = trenutniKorisnik.korisnikoIme,
                lozinka = trenutniKorisnik.lozinka,
                ime = trenutniKorisnik.Ime,
                prezime = trenutniKorisnik.Prezime,
                email = trenutniKorisnik.email
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
                    is_admin = x.isAdmin,
                    email = x.email
                })
                .ToList();
            return Ok(podaci);
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
                isAdmin = false,
                email = x.email
            };

            dbContext.Korisnik.Add(noviKorisnik);
            dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_korisnika_base63))
            {
                byte[] nova_slika = x.slika_korisnika_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slikeKorisnika/" + noviKorisnik.id + ".png");
            }

            return Ok(noviKorisnik);
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
                korisnik.email = x.email;
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
        public ActionResult UpdateSlikaKorisnika([FromBody]SlikaDto objekat,int id)
        {
            if (!string.IsNullOrEmpty(objekat.slika_korisnika_base63))
            {
                byte[] nova_slika = objekat.slika_korisnika_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slikeKorisnika/" + id + ".png");
                return Ok("Slika uspješno spašena!");
            }
            return Ok("Došlo je do greške!");
        }


        [HttpPut("{id}")]
        public ActionResult UpdateAdminRole(int id)
        {
            var korisnik = dbContext.Korisnik.Find(id);
            if (korisnik != null)
            {
                if (korisnik.isAdmin)
                    korisnik.isAdmin = false;
                else
                    korisnik.isAdmin = true;
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
