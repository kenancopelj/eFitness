using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.SuplementVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SuplementController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public SuplementController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }




        [HttpPost]
        public ActionResult GetAll([FromBody] SearchObject searchObject)
        {
            var podaci = dbContext.Suplement.
                Select(x => new SuplementGetAllVM
                {
                    id=x.id,
                    naziv = x.naziv,
                    rokTrajanja = x.rokTrajanja,
                    opis = x.opis,
                    cijena = x.cijena,
                    kategorija_id = x.kategorija_id,
                    kategorija=x.kategorija
                })
                .ApplyPagination(searchObject.Skip(), searchObject.PageSize)
                .ToList();

            var Items = podaci.Count();

            var message = new Message()
            {
                IsValid = true,
                Data = podaci,
                PagedResult = new PagedResult
                {
                    TotalItems = Items,
                    TotalPages = searchObject.CalculatePages(Items),
                    CurrentPage = searchObject.Page,
                }
            };
            return Ok(message);
        }

        [HttpGet]
        public ActionResult GetAllOld()
        {
            var podaci = dbContext.Suplement.
                Select(x => new SuplementGetAllVM
                {
                    id = x.id,
                    naziv = x.naziv,
                    rokTrajanja = x.rokTrajanja,
                    opis = x.opis,
                    cijena = x.cijena,
                    kategorija_id = x.kategorija_id,
                    kategorija = x.kategorija
                })
                .ToList();

            
            return Ok(podaci);
        }

        [HttpGet]
        public ActionResult GetLastThree()
        {
            var podaci = dbContext.Suplement.
                Select(x => new SuplementGetAllVM
                {
                    id = x.id,
                    naziv = x.naziv,
                    rokTrajanja = x.rokTrajanja,
                    opis = x.opis,
                    cijena = x.cijena,
                    kategorija_id = x.kategorija_id,
                    kategorija = x.kategorija
                })
                .Take(3)
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] SuplemetAddVM x)
        {
            var novi = new Suplement()
            {
                naziv = x.naziv,
                rokTrajanja = x.rokTrajanja,
                opis = x.opis,
                cijena = x.cijena,
                kategorija_id = x.kategorija_id,
            
            };
            dbContext.Suplement.Add(novi);
            dbContext.SaveChanges();

            if (!string.IsNullOrEmpty(x.slika_suplementa_base63))
            {
                byte[] nova_slika = x.slika_suplementa_base63.parseBase64();
                Fajlovi.Snimi(nova_slika, "slike/" + novi.id + ".png");
                
            }


            return Ok(novi);
        }
        
       

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] SuplemetAddVM x, int id)
        {
            var objekat = dbContext.Suplement.Find(id);
            if (objekat != null)
            {
                objekat.naziv = x.naziv;
                objekat.rokTrajanja = x.rokTrajanja;
                objekat.opis = x.opis;
                objekat.cijena = x.cijena;
                objekat.kategorija_id = x.kategorija_id;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Suplement.Find(id);
            if (objekat != null)
            {
                dbContext.Suplement.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }

        [HttpGet("{suplementID}")]
        public ActionResult GetSlikaSuplementa(int suplementID)
        {
            //Suplement suplement = dbContext.Suplement.Find(suplementID);

            //byte[] slika = Fajlovi.Ucitaj(Config.SlikeFolder + suplement.id + ".png");

            //if (slika == null || slika.Length == 0)
            //{
            //    slika = Fajlovi.Ucitaj(Config.SlikeFolder + "prva.png");
            //}
            //return File(slika, "image/png");


            byte[] bajtovi_slike = Fajlovi.Ucitaj("slike/" + suplementID + ".png")
                                   ?? Fajlovi.Ucitaj("slike/prva.png");

            return File(bajtovi_slike, "image/png");
        }

    }
}
