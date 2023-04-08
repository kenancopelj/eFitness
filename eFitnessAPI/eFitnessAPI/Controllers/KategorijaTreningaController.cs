using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.ViewModels.KategorijaSuplementaVM;
using eFitnessAPI.ViewModels.KategorijaTreningaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategorijaTreningaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public KategorijaTreningaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.KategorijaTreninga
                .Select(x => new KategorijaTreningaGetAllVM
                {
                    id=x.id,
                    naziv_kategorije=x.naziv
                }).ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] KategorijaSuplementaGetAllVM x)
        {
            var novaKategorija = new KategorijaTreninga
            {
                naziv=x.naziv_kategorije
            };

            dbContext.Add(novaKategorija);
            dbContext.SaveChanges();

            

            return Ok(novaKategorija);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] KategorijaTreningaGetAllVM x, int id)
        {
            var odabranaKategorija = dbContext.KategorijaTreninga.Find(id);
            if (odabranaKategorija != null)
            {
                odabranaKategorija.naziv = x.naziv_kategorije;
                dbContext.SaveChanges();
            }
            else
                return BadRequest("Pogresan ID");

            return Ok(odabranaKategorija);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var odabrani = dbContext.KategorijaTreninga.Find(id);

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
