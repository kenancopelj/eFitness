using AspNetCore.Reporting;
using eFitnessAPI.Data;
using Microsoft.EntityFrameworkCore;
using System.Text;

namespace eFitnessReport.Services
{
    public class ReportService
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

           
                        var dateTimeFromInString = queryString.TryGetValue("df", out string df) ? df : DateTime.Now.ToString("dd.MM.yyyy");
                        DateTime dateTimeFrom = DateTime.TryParse(dateTimeFromInString, out DateTime dFrom) ? dFrom : DateTime.Now;

                        var dateTimeToInString = queryString.TryGetValue("dt", out string dt) ? dt : DateTime.Now.ToString("dd.MM.yyyy");
                        DateTime dateTimeTo = DateTime.TryParse(dateTimeToInString, out DateTime dTo) ? dTo : DateTime.Now;


                        List<object> l = new List<object>();

                        var podaci = await dBContext.Narudzba
                            .Where(x => x.VrijemePravljenja >= dateTimeFrom && x.VrijemePravljenja <= dateTimeTo)
                            .ToListAsync();

                        var ukupno = podaci.Sum(x => x.Total);

                        for (int i = 0; i < podaci.Count; i++)
                        {
                            l.Add(new
                            {
                                Rb = i + 1,
                                VrijemePravljenja = podaci[i].VrijemePravljenja.ToString("dd.MM.yyyy"),
                                Total = podaci[i].Total.ToString()
                            });
                        }
                        var listOfParameters = new List<object>();
                        var _parameters = new{
                            Ukupno = ukupno.ToString(),
                            DatumOd = dateTimeFrom.ToString("dd.MM.yyyy"),
                            DatumDo = dateTimeTo.ToString("dd.MM.yyyy")
                        };
                        

                        listOfParameters.Add(_parameters);
                        report.AddDataSource("Parameters", listOfParameters);
                        report.AddDataSource("ReportData", l);

            var result = report.Execute(RenderType.Pdf, 1);
            return result.MainStream;
        }


    }
}
