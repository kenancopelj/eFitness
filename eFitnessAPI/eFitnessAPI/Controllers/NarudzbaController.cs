using eFitnessAPI.Class;
using eFitnessAPI.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public IActionResult CreateOrder([FromBody] Narudzba order)
        {
            // Save the order to the database
            dbContext.Narudzba.Add(order);
            dbContext.SaveChanges();

            return Ok();
        }
    }
}
