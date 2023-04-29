using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class MailController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMailService _mailService;
        public MailController(ApplicationDbContext dbContext, IMailService mailService)
        {
            _dbContext = dbContext;
            _mailService = mailService;
        }

        [HttpPost]
        public IActionResult SendMail([FromBody]MailDto mailDto)
        {
            var message = _mailService.Posalji(mailDto.To, mailDto.Message,"");

            if (message == true)
                return Ok();

            return BadRequest("Greška");
        }

    }
}
