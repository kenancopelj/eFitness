using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessReport.Services
{
    [Route("report")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        private readonly Microsoft.AspNetCore.Hosting.IHostingEnvironment _hostingEnvironment;
        private IReportService IReport;
        public ReportController(Microsoft.AspNetCore.Hosting.IHostingEnvironment host, IReportService service)
        {
            IReport = service;
            _hostingEnvironment = host;
        }
        [HttpGet]
        [Route("Export_Data")]
        public async Task<IActionResult> Export_Data(CancellationToken cancellationToken)
        {
            var byteRes = new byte[] { };

            Dictionary<string, string> queryString = new Dictionary<string, string>();
            foreach (var item in HttpContext.Request.Query.Keys)
            {
                queryString.Add(item, HttpContext.Request.Query[item]);
            }

            byteRes = await IReport.CreateReportFile(queryString, cancellationToken);

            HttpContext.Response.Clear();
            HttpContext.Response.ContentType = "application/pdf";
            HttpContext.Response.Headers.Add("content-disposition", "inline;");

            await HttpContext.Response.Body.WriteAsync(byteRes);
            HttpContext.Response.Body.Flush();

            return Ok();
        }
        [HttpGet]
        [Route("adin")]
        public async Task<IActionResult> adin(CancellationToken cancellationToken)
        {
            
            return Ok("s");
        }

    }
}
