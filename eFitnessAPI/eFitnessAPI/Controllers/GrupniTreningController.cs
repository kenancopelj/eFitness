using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.ViewModels.GrupniTreningVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class GrupniTreningController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public GrupniTreningController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll() 
        {
            var podaci = dbContext.GrupniTrening
                .Select(x => new GrupniTreningGetAllVM
                {
                    id=x.id,
                    kategorija_id= x.kategorija_id,
                    naziv_kategorije=x.kategorija.naziv,
                    vrijeme_odrzavanja=x.vrijemeOdrzavanja
                }).ToList();
            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] GrupniTreningAddVM x)
        {
            var noviTrening = new GrupniTrening
            {
                kategorija_id=x.kategorija_id,
                vrijemeOdrzavanja=x.vrijeme_odrzavanja
            };

            dbContext.Add(noviTrening);
            dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_suplementa_base63))
            {
                byte[] nova_slika = x.slika_suplementa_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slikeGrupniTrening/" + noviTrening.id + ".png");
            }

            return Ok(noviTrening);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]GrupniTreningAddVM x, int treningID)
        {
            var trening = dbContext.GrupniTrening.Find(treningID);

            if (trening != null)
            {
                trening.vrijemeOdrzavanja = x.vrijeme_odrzavanja;
                trening.kategorija_id = x.kategorija_id;

                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Remove(int id)
        {
            var trening = dbContext.GrupniTrening.FirstOrDefault(x => x.id == id);

            if (trening != null)
            {
                dbContext.GrupniTrening.Remove(trening);
                dbContext.SaveChanges();
                return Ok();
            }
            else
                return BadRequest("Pogresan Id treninga!");
        }

        [HttpGet("{treningID}")]
        public ActionResult GetSlikaGrupnogTreninga(int treningID)
        {

            byte[] bajtovi_slike = Fajlovi.Ucitaj("slikeGrupniTrening/" + treningID + ".png")
                                   ?? Fajlovi.Ucitaj("slikeGrupniTrening/prva.png");

            return File(bajtovi_slike, "image/png");
        }

    }
}
