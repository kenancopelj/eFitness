using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.VrstaClanarineVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VrstaClanarineController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public VrstaClanarineController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.VrstaClanarine.
                Select(x => new VrstaClanarineVM
                {
                    Id = x.id,
                    naziv = x.naziv,
                    cijena=x.cijena
                })
                .ToList();

            return Ok(podaci);
        }

        [HttpGet("{clanarinaId}")]
        public ActionResult GetById(int clanarinaId)
        {
            var podaci = dbContext.VrstaClanarine
                .Where(x=>x.id == clanarinaId)
                .Select(x => new VrstaClanarineVM
                {
                   naziv = x.naziv,
                   cijena= x.cijena
                })
                .FirstOrDefault();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] VrstaClanarineVM x)
        {
            var novi = new VrstaClanarine()
            {
                naziv = x.naziv,
                cijena=x.cijena
            };
            dbContext.VrstaClanarine.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] VrstaClanarineVM x, int id)
        {
            var objekat = dbContext.VrstaClanarine.Find(id);
            if (objekat != null)
            {
                objekat.naziv = x.naziv;
                objekat.cijena = x.cijena;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.VrstaClanarine.Find(id);
            if (objekat != null)
            {
                dbContext.VrstaClanarine.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }
    }
}
