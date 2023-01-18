using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.KategorijaSuplementaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class KategorijaSuplementaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public KategorijaSuplementaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.KategorijaSuplementa
                .Select(x => new KategorijaSuplementaGetAllVM
                {
                    id=x.id,
                    naziv_kategorije=x.naziv
                }).ToList();


            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody]KategorijaSuplementaGetAllVM x)
        {
            var novaKategorija = new KategorijaSuplementa
            {
                naziv=x.naziv_kategorije
            };

            dbContext.Add(novaKategorija);
            dbContext.SaveChanges();

            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody]KategorijaSuplementaGetAllVM x, int id)
        {
            var odabranaKategorija = dbContext.KategorijaSuplementa.Find(id);
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
            var odabrani = dbContext.KategorijaSuplementa.Find(id);

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
