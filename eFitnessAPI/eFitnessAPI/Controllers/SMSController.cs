using eFitnessAPI.Data;
using eFitnessAPI.Helper;
using eFitnessAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eFitnessAPI.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class SMSController : ControllerBase
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly ISMSService _smsService;
        public SMSController(ApplicationDbContext dbContext, ISMSService SMSService)
        {
            _dbContext = dbContext;
            _smsService = SMSService;
        }

        [HttpPost]
        public IActionResult SendMessage([FromBody]MessageDto message)
        {
            if (_smsService.SendMessage(message.To, message.Message))
                return Ok();
            return BadRequest("Došlo je do greške");
        }

    }
}
