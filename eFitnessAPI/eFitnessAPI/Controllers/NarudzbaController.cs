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


        [HttpPost]
        public IActionResult CreateOrder([FromBody] List<Suplement> Suplementi)
        {
            var tot = Suplementi.Sum(x => x.cijena);
            var Nar = new Narudzba()
            {
                Total = tot,
                VrijemePravljenja = DateTime.Now,
                Suplementi = Suplementi
            };
            // Save the order to the database
            dbContext.Narudzba.Add(Nar);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
