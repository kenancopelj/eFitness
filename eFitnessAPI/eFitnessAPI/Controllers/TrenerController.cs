using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using eFitnessAPI.ViewModels.TrenerVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TrenerController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public TrenerController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Trener.
                Select(x => new TrenerGetAllVM
                {
                   Specijalnost=x.Specijalnost
                })
                .ToList();

            return Ok(podaci);
        }

        [HttpPost]
        public ActionResult Add([FromBody] TrenerAddVM x)
        {
            var novi = new Trener()
            {
                Specijalnost=x.Specijalnost
            };
            dbContext.Trener.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] TrenerAddVM x, int id)
        {
            var objekat = dbContext.Trener.Find(id);
            if (objekat != null)
            {
                objekat.Specijalnost = x.Specijalnost;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }


        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Trener.Find(id);
            if (objekat != null)
            {
                dbContext.Trener.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }
    }
}
