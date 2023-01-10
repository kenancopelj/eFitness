using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.VjezbaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class VjezbaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public VjezbaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Vjezba.
                Select(x => new VjezbaGetAllVM
                {
                   naziv=x.naziv,
                   kategorija_id=x.kategorija_id
                })
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] VjezbaAddVM x)
        {
            var novi = new Vjezba()
            {
                naziv = x.naziv,
                kategorija_id = x.kategorija_id
            };
            dbContext.Vjezba.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] VjezbaAddVM x, int id)
        {
            var objekat = dbContext.Vjezba.Find(id);
            if (objekat != null)
            {
                objekat.naziv = x.naziv;
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
            var objekat = dbContext.Vjezba.Find(id);
            if (objekat != null)
            {
                dbContext.Vjezba.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }

    }
}
