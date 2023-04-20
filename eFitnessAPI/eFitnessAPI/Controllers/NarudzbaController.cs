using eFitnessAPI.Class;
using eFitnessAPI.Data;
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

        [HttpPost("{korisnikid)")]
        public IActionResult AddNarudzba([FromBody] NarudzbaAddVM x,int korisnikid)
        {
            var Postojeca = dbContext.Narudzba.Where(x=>x.korisnik_id == korisnikid).FirstOrDefault();
            if (Postojeca == null)
            {
                var nar = new Narudzba()
                {
                    korisnik_id = x.korisnik_id,
                    VrijemePravljenja = DateTime.Now,
                };

                dbContext.Narudzba.Add(nar);
                dbContext.SaveChanges();
            }
            return Ok();
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


        //[HttpGet("{id}")]
        //public IActionResult GetSuplementiByCategory(int id)
        //{
        //    var podaci = new List<Suplement>();
        //    var Narudzbe = dbContext.Narudzba.ToList();
        //    for (int i = 0; i < Narudzbe.Count(); i++)
        //    {
        //        for (int j = 0; j < Narudzbe[i].Suplementi.Count(); j++)
        //        {
        //            podaci.Add(Narudzbe[i].Suplementi.ToList()[j]. as Suplement)

        //        }
        //    }




        //    //    return Ok();
        //    //}


    }
}
