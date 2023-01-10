using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.VrstaClanarineVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VrstaVjezbeController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public VrstaVjezbeController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.VrstaClanarine.
                Select(x => new VrstaVjezbeGetAllVM
                {
                   naziv=x.naziv
                })
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] VrstaVjezbeAddVM x)
        {
            var novi = new VrstaClanarine()
            {
                naziv = x.naziv
            };
            dbContext.VrstaClanarine.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] VrstaVjezbeAddVM x, int id)
        {
            var objekat = dbContext.VrstaClanarine.Find(id);
            if (objekat != null)
            {
                objekat.naziv = x.naziv;
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
