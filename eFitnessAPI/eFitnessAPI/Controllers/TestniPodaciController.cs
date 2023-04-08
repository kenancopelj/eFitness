using eFitnessAPI.Class;
using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using FIT_Api_Examples.Helper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class TestniPodaciController : ControllerBase
    {
        private readonly ApplicationDbContext dbContext;

        public TestniPodaciController(ApplicationDbContext _dbContext)
        {
            dbContext = _dbContext;
        }


        [HttpGet]
        public ActionResult Count()
        {
            Dictionary<string, int> data = new Dictionary<string, int>();
            data.Add("Osoblje", dbContext.Osoblje.Count());
            data.Add("Clanarine", dbContext.Clanarina.Count());
            data.Add("VrstaClanarine", dbContext.VrstaClanarine.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var vrstaClanarina = new List<VrstaClanarine>();
            var osoblje = new List<Osoblje>();
            var clanarina = new List<Clanarina>();
            var kategorijeSup = new List<KategorijaSuplementa>();



            kategorijeSup.Add(new KategorijaSuplementa { naziv = "Protein" });
            kategorijeSup.Add(new KategorijaSuplementa { naziv = "Kreatin" });
            kategorijeSup.Add(new KategorijaSuplementa { naziv = "Aminokiseline" });
            kategorijeSup.Add(new KategorijaSuplementa { naziv = "Preworkout" });




            vrstaClanarina.Add(new VrstaClanarine { naziv = "Mjesecna",cijena=45 });
            vrstaClanarina.Add(new VrstaClanarine { naziv = "3 mjeseca", cijena = 120 });
            vrstaClanarina.Add(new VrstaClanarine { naziv = "6 mjeseci", cijena = 210 });




            dbContext.AddRange(kategorijeSup);
            dbContext.AddRange(osoblje);
            dbContext.AddRange(clanarina);
            dbContext.AddRange(vrstaClanarina);
            
            dbContext.SaveChanges();

            return Count();
        }
    }
}

