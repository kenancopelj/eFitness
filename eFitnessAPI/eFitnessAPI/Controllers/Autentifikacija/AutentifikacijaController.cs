using System;
using System.Collections.Generic;
using System.Linq;
using eFitnessAPI.Class;
using eFitnessAPI.Controllers.Autentifikacija;
using eFitnessAPI.Controllers.Autentifikacija.ViewModels;
using eFitnessAPI.Data;
using FIT_Api_Examples.Helper;
using FIT_Api_Examples.Helper.AutentifikacijaAutorizacija;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static FIT_Api_Examples.Helper.AutentifikacijaAutorizacija.MyAuthTokenExtension;

namespace FIT_Api_Examples.Modul0_Autentifikacija.Controllers
{
    //[Authorize]
    [ApiController]
    [Route("[controller]/[action]")]
    public class AutentifikacijaController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;

        public AutentifikacijaController(ApplicationDbContext dbContext)
        {
            this._dbContext = dbContext;
        }


        [HttpPost]
        public ActionResult<LoginInformacije> Login([FromBody] LoginVM x)
        {
            //1- provjera logina
            Korisnik logiraniKorisnik = _dbContext.Korisnik
                .FirstOrDefault(k =>
                k.korisnikoIme != null && k.korisnikoIme == x.korisnickoIme && k.lozinka == x.lozinka);

            if (logiraniKorisnik == null)
            {
                //pogresan username i password
                return BadRequest("Pogrešan username ili password");
            }

            //2- generisati random string
            string randomString = TokenGenerator.Generate(10);

            //3- dodati novi zapis u tabelu AutentifikacijaToken za logiraniKorisnikId i randomString
            var noviToken = new AutentifikacijaToken()
            {
                ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                vrijednost = randomString,
                korisnickiNalog = logiraniKorisnik,
                vrijemeEvidentiranja = DateTime.Now
            };

            _dbContext.Add(noviToken);
            _dbContext.SaveChanges();

            //4- vratiti token string
            return new LoginInformacije(noviToken);
        }

        [HttpPost]
        public ActionResult Logout()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            if (autentifikacijaToken == null)
                return Ok();

            _dbContext.Remove(autentifikacijaToken);
            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpGet]
        public ActionResult<AutentifikacijaToken> Get()
        {
            AutentifikacijaToken autentifikacijaToken = HttpContext.GetAuthToken();

            return autentifikacijaToken;
        }
    }
}