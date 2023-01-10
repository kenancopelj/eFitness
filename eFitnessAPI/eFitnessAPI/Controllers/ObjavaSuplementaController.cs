using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ObjavaSuplementaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ObjavaSuplementaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ObjavaSuplementaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.ObjavaSuplementa
                .Select(x => new ObjavaSuplementaGetAllVM
                {
                    datum_dodavanja=x.datumDodavanja,
                    osobljeID=x.osoblje_id,
                    suplementID=x.suplement_id
                }).ToList();


            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] ObjavaSuplementaGetAllVM x)
        {
            var novaObjava = new ObjavaSuplementa
            {
                osoblje_id = x.osobljeID,
                datumDodavanja = x.datum_dodavanja,
                suplement_id = x.suplementID
            };

            dbContext.Add(novaObjava);
            dbContext.SaveChanges();

            return Ok(novaObjava);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ObjavaSuplementaGetAllVM x, int id)
        {
            var odabrani = dbContext.ObjavaSuplementa.Find(id);

            if (odabrani != null)
            {
                odabrani.osoblje_id = x.osobljeID;
                odabrani.suplement_id = x.suplementID;
                odabrani.datumDodavanja = x.datum_dodavanja;
            }
            else
                return BadRequest("Pogresan ID");
            return Ok(odabrani);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id) 
        {
            var odabrani = dbContext.ObjavaSuplementa.Find(id);

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
