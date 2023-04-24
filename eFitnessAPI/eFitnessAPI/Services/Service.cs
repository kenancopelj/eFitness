using eFitnessAPI.Data;
using Microsoft.EntityFrameworkCore;

namespace eFitnessAPI.Services
{
    public class Service : IService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IMailService _mailService;

        public Service(ApplicationDbContext dbContext, IMailService mailService)
        {
            this._dbContext= dbContext;
            this._mailService= mailService;
        }


        public void ProvjeriClanarine(CancellationToken token)
        {
            var clanarine = _dbContext.Clanarina
                .Include(x => x.korisnik)
                .ToList();

            foreach (var item in clanarine)
            {
                if ((item.datumIsteka - DateTime.Now).TotalDays <= 3)
                {
                    _mailService.Posalji(item.korisnik.email, "Vaša članarine ističe za manje od 3 dana!");
                }
                else if((item.datumIsteka - DateTime.Now).TotalDays == 0)
                {
                    item.aktivna = false;
                    _mailService.Posalji(item.korisnik.email, "Vaša članarina je istekla!");
                }
            }

            _dbContext.SaveChanges();

            return;
        }
    }
}
