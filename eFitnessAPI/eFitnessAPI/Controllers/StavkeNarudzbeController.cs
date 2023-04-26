using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.ViewModels.GrupniTreningVM;
using eFitnessAPI.ViewModels.StavkeNarudzbeVM;
using eFitnessAPI.ViewModels.SuplementVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class StavkeNarudzbeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public StavkeNarudzbeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.StavkeNarudzbe
                .Select(x => new
                {
                    id = x.id,
                    narudzba_id = x.narudzba_id,
                    suplement_id = x.suplement_id,
                    kolicina = x.kolicina
                }).ToList();
            return Ok(podaci);
        }

        [HttpPost("{narudzbaId}")]
        public ActionResult Add([FromBody] StavkeNarudzbeVM x, int narudzbaId)
        {
            var narudzba = dbContext.Narudzba.Find(narudzbaId);
            var novi = new StavkeNarudzbe
            {
                id = x.id,
                narudzba_id = narudzba.narudzbaID,
                suplement_id = x.suplement_id,
                kolicina = x.kolicina
            };

            dbContext.StavkeNarudzbe.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult UpdateKolicina(int id)
        {
            var stavka = dbContext.StavkeNarudzbe.Find(id);

            if (stavka != null)
            {
                stavka.kolicina = stavka.kolicina+1;

                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok(stavka);
        }

        [HttpGet("{naruzdbaId}")]
        public ActionResult GetStavkeNarudzbeByNarudzbaId(int naruzdbaId)
        {
            var podaci = dbContext.StavkeNarudzbe
                .Include(x => x.suplement)
                .Include(x => x.suplement.kategorija)
                .Where(x => x.narudzba_id == naruzdbaId)
                .Select(x => new
                {
                    id = x.id,
                    narudzba_id = x.narudzba_id,
                    kolicina = x.kolicina,
                    suplement = new
                    {
                        id = x.suplement.id,
                        naziv = x.suplement.naziv,
                        rokTrajanja = x.suplement.rokTrajanja,
                        opis = x.suplement.opis,
                        cijena = x.suplement.cijena,
                        kategorija = new
                        {
                            id = x.suplement.kategorija.id,
                            naziv = x.suplement.kategorija.naziv
                        }
                    }
                }).ToList();
            return Ok(podaci);
        }
        [HttpDelete("{stavka_id}")]
        public IActionResult DeleteStavkaFromNarudzba(int stavka_id)
        {
            var stavka = dbContext.StavkeNarudzbe.Find(stavka_id);
            if (stavka != null)
            {
                dbContext.StavkeNarudzbe.Remove(stavka);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");
            return Ok();

        }
        
    }
}
