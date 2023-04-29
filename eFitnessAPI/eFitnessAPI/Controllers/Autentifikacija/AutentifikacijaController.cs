using System;
using System.Collections.Generic;
using System.Linq;
using eFitnessAPI.Class;
using eFitnessAPI.Controllers.Autentifikacija;
using eFitnessAPI.Controllers.Autentifikacija.ViewModels;
using eFitnessAPI.Data;
using eFitnessAPI.Services;
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
        private readonly IMailService _mailService;

        public AutentifikacijaController(ApplicationDbContext dbContext, IMailService mailService)
        {
            this._dbContext = dbContext;
            this._mailService = mailService;
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
            string randomString = TokenGenerator.Generate(6);

            logiraniKorisnik.aktivacijaToken = randomString;

            var message = $"<br><br><br>";
            message += $"<h4 style=\"text-align: center; font-weight: normal;\">Vaš autentifikacijski token je: <span style=\"font-weight: bold;\">{randomString}</span></h4>\r\n";

            _mailService.Posalji(logiraniKorisnik.email, message, "Autentifikacijski token");

            _dbContext.SaveChanges();
            return Ok();
        }

        [HttpPost("{token}")]
        public ActionResult<LoginInformacije> TwoWayAuth(string token)
        {
            var korisnik = _dbContext.Korisnik.FirstOrDefault(x => x.aktivacijaToken == token);
            if (korisnik != null)
            {
                var noviToken = new AutentifikacijaToken()
                {
                    ipAdresa = Request.HttpContext.Connection.RemoteIpAddress?.ToString(),
                    vrijednost = token,
                    korisnickiNalog = korisnik,
                    vrijemeEvidentiranja = DateTime.Now
                };
                _dbContext.Add(noviToken);
                _dbContext.SaveChanges();
                 return new LoginInformacije(noviToken);
            }
            return BadRequest("Pogrešan token");
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