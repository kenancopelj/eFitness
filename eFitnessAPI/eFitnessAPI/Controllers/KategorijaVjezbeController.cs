using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.KategorijaSuplementaVM;
using eFitnessAPI.ViewModels.KategorijaVjezbeVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategorijaVjezbeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public KategorijaVjezbeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.KategorijaVjezbe
                .Select(x => new KategorijaVjezbeGetAllVM
                {
                    Naziv=x.naziv
                }).ToList();


            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] KategorijaVjezbeGetAllVM x)
        {
            var novaKategorija = new KategorijaVjezbe
            {
                naziv = x.Naziv
            };

            dbContext.Add(novaKategorija);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] KategorijaVjezbeGetAllVM x, int id)
        {
            var odabranaKategorija = dbContext.KategorijaVjezbe.Find(id);
            if (odabranaKategorija != null)
            {
                odabranaKategorija.naziv = x.Naziv;

                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok(odabranaKategorija);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var odabrani = dbContext.KategorijaVjezbe.Find(id);

            if (odabrani != null)
            {
                dbContext.Remove(odabrani);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok();

        }
    }
}
