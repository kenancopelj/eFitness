using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.ViewModels.GrupniTreningVM;
using eFitnessAPI.ViewModels.NarudzbaVM;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Transactions;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class NarudzbaController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;
        public NarudzbaController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost("placeorder")]
        public IActionResult CreateOrder([FromBody] List<Item> items)
        {
            //var tot = items.Sum(x => x.Price);
            //var Nar = new Narudzba()
            //{
            //    Total = tot,
            //    VrijemePravljenja = DateTime.Now,
            //   // Suplementi = items
            //};
            //// Save the order to the database
            //dbContext.Narudzba.Add(Nar);
            //dbContext.SaveChanges();

            return Ok();
        }

        [HttpPost("{korisnikid}")]
        public IActionResult AddNarudzba(int korisnikid)
        {
            var Postojeca = dbContext.Narudzba.Where(x=>x.korisnik.id == korisnikid && x.kupljeno==false).FirstOrDefault();
            var id=0;
            if (Postojeca == null)
            {
                var nar = new Narudzba()
                {
                    korisnik_id = korisnikid,
                    VrijemePravljenja = DateTime.Now,
                };
                dbContext.Narudzba.Add(nar);
                dbContext.SaveChanges();
                id = nar.narudzbaID;
                
            }
            else
            {
                id = Postojeca.narudzbaID;
            }
            return Ok(id);
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var podaci = dbContext.Narudzba
               .Select(x => new
               {
                   id = x.narudzbaID,
                   korisnik = x.korisnik_id,
                   kupljeno = x.kupljeno

               }).ToList();
            return Ok(podaci);
        }

        [HttpGet]
        public IActionResult GetIdsOfNarudzba()
        {
            var podaci = dbContext.Narudzba
                .Select(x => new 
                {
                    id = x.narudzbaID,

                }).ToList();
            return Ok(podaci);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteNarudzba(int id)
        {
            var nar = dbContext.Narudzba.Find(id);
            if (nar != null)
            {
            dbContext.Narudzba.Remove(nar);
            dbContext.SaveChanges();
            }
            else
                return BadRequest("pogresan ID");

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Kupljeno(int id)
        {
            var nar = dbContext.Narudzba.Find(id);
            if (nar != null)
            {
                nar.kupljeno = true;
                dbContext.SaveChanges();
            }

            return Ok();
        }


       


    }
}
