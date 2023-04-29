using AspNetCore.Reporting;
using eFitnessAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace eFitnessReport.Services
{
    public class ReportService : IReportService
    {
        private readonly IWebHostEnvironment webHostEnvironment;
        private readonly ApplicationDbContext dBContext;

        public ReportService(IWebHostEnvironment webHost, ApplicationDbContext _dbContext) 
        {
            webHostEnvironment = webHost;
            dBContext = _dbContext;
            Encoding.RegisterProvider(CodePagesEncodingProvider.Instance);
        }

        public async Task<byte[]> CreateReportFile(Dictionary<string, string> queryString, CancellationToken cancellationToken)
        {
            
            string pathRdlc = Path.Combine(webHostEnvironment.ContentRootPath, "Report", "Report1.rdlc");

            AspNetCore.Reporting.LocalReport report = new AspNetCore.Reporting.LocalReport(pathRdlc);

           
                        //var dateTimeFromInString = queryString.TryGetValue("df", out string df) ? df : DateTime.Now.ToString("dd.MM.yyyy");
                        //DateTime dateTimeFrom = DateTime.TryParse(dateTimeFromInString, out DateTime dFrom) ? dFrom : DateTime.Now;

                        //var dateTimeToInString = queryString.TryGetValue("dt", out string dt) ? dt : DateTime.Now.ToString("dd.MM.yyyy");
                        //DateTime dateTimeTo = DateTime.TryParse(dateTimeToInString, out DateTime dTo) ? dTo : DateTime.Now;
                        
                        int userId = queryString.TryGetValue("u", out var cuId) ? Convert.ToInt32(cuId) : 0;
                        int narID = queryString.TryGetValue("k", out var kId) ? Convert.ToInt32(kId) : 0;

            
            
                        List<object> l = new List<object>();

                        var podaci = await dBContext.StavkeNarudzbe.Include(x => x.narudzba).Include(x => x.suplement)
                            .Where(x => x.narudzba.narudzbaID == narID )
                            .ToListAsync();

                        var podaciNar = await dBContext.Narudzba.FindAsync(narID);

                        double ukupno = 0;

                        for (int i = 0; i < podaci.Count; i++)
                        {
                            l.Add(new
                            {
                                Rb = i + 1,
                                Naziv = podaci[i].suplement.naziv,
                                Kolicina = podaci[i].kolicina,
                                Cijena = podaci[i].kolicina * podaci[i].suplement.cijena
                            });
                             ukupno =+ podaci[i].kolicina * podaci[i].suplement.cijena;
                        }
                        var listOfParameters = new List<object>();
                        var _parameters = new{
                            Ukupno = ukupno.ToString(),
                            KorisnikIme = dBContext.Korisnik.Find(userId).Ime,
                            KorisnikPrezime = dBContext.Korisnik.Find(userId).Prezime,
                            VrijemePravljenja = podaciNar.VrijemePravljenja.ToString("dd.MM.yyyy")
                        };
                        

                        listOfParameters.Add(_parameters);
                        report.AddDataSource("Parameters", listOfParameters);
                        report.AddDataSource("DataSet1", l);

            var result = report.Execute(RenderType.Pdf, 1);
            return result.MainStream;
        }


    }
}
