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
            data.Add("Clan", dbContext.Clan.Count());
            data.Add("Clanarine", dbContext.Clanarina.Count());
            data.Add("VrstaClanarine", dbContext.VrstaClanarine.Count());

            return Ok(data);
        }

        [HttpPost]
        public ActionResult Generisi()
        {
            var vrstaClanarina = new List<VrstaClanarine>();
            var  clan= new List<Clan>();
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


            clanarina.Add(new Clanarina { datumKreiranja = DateTime.Now, datumIsteka = new DateTime(2023, 2, 24), aktivna = true, vrstaClanarine = vrstaClanarina[0] });
            clanarina.Add(new Clanarina { datumKreiranja = DateTime.Now, datumIsteka = new DateTime(2023, 2, 25), aktivna = true, vrstaClanarine = vrstaClanarina[1] });



            clan.Add(new Clan { korisnikoIme="adinmaks",lozinka="test",slika=Config.SlikeURL + "empty.png", ime = "Adin", prezime = "Maksumic", spol = "Muski", datumRodjenja = DateTime.Now, clanarina = clanarina[0] });
            clan.Add(new Clan { korisnikoIme = "kenancop", lozinka = "test", slika = Config.SlikeURL + "empty.png", ime = "Kenan", prezime = "Copelj", spol = "Muski", datumRodjenja = DateTime.Now, clanarina = clanarina[1] });

            osoblje.Add(new Osoblje { korisnikoIme = "edina", lozinka = "test", slika = Config.SlikeURL + "empty.png", ime = "Edina", prezime = "neznam", spol = "Zenski",datumRodjenja=DateTime.Now, datumZaposlenja=DateTime.Now, isAdmin=true });




            dbContext.AddRange(kategorijeSup);
            dbContext.AddRange(osoblje);
            dbContext.AddRange(clan);
            dbContext.AddRange(clanarina);
            dbContext.AddRange(vrstaClanarina);
            
            dbContext.SaveChanges();

            return Count();
        }
    }
}

