using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.ClanarinaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class ClanarinaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public ClanarinaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        [HttpGet]
        public ActionResult GetAll()
        {
            var podaci = dbContext.Clanarina.
                Select(x => new ClanarinaGetAllVM
                {
                    datumIsteka = x.datumIsteka,
                    datumKreiranja = x.datumKreiranja,
                    vrsta_clanarine_id = x.vrsta_clanarine_id,
                    aktivna = x.aktivna
                })
                .ToList();

            return Ok(podaci);
        }


        [HttpPost]
        public ActionResult Add([FromBody] ClanarinaAddVM x)
        {
            var novi = new Clanarina()
            {
                datumIsteka = x.datumIsteka,
                datumKreiranja = x.datumKreiranja,
                vrsta_clanarine_id = x.vrsta_clanarine_id,
                aktivna = x.aktivna
            };
            dbContext.Clanarina.Add(novi);
            dbContext.SaveChanges();

            return Ok(novi);
        }

        [HttpPut("{id}")]
        public ActionResult Update([FromBody] ClanarinaAddVM x,int id)
        {
            var objekat = dbContext.Clanarina.Find(id);
            if (objekat != null)
            {
                objekat.datumKreiranja = x.datumKreiranja;
                objekat.datumIsteka = x.datumIsteka;
                objekat.vrsta_clanarine_id = x.vrsta_clanarine_id;
                objekat.aktivna = x.aktivna;
            }
            else
                return BadRequest("pogresan ID");
            dbContext.SaveChanges();
            return Ok(objekat);
        }

        [HttpDelete("{id}")]
        public ActionResult Remove(int id)
        {
            var objekat = dbContext.Clanarina.Find(id);
            if (objekat != null)
            {
                dbContext.Clanarina.Remove(objekat);
                dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }


    }
}
