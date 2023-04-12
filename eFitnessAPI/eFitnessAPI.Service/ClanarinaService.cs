using eFitnessAPI;
using eFitnessAPI.Data;
using eFitnessAPI.Service.Interfaces;
using eFitnessAPI.ViewModels.ClanarinaVM;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Service
{
    public class ClanarinaService : IClanarinaService
    {
        private readonly ApplicationDbContext dbContext;
        public ClanarinaService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Message> GetAll()
        {
            var podaci = await dbContext.Clanarina.
                Select(x => new ClanarinaGetAllVM
                {
                    datumIsteka = x.datumIsteka,
                    datumKreiranja = x.datumKreiranja,
                    vrsta_clanarine_id = x.vrsta_clanarine_id,
                    aktivna = x.aktivna,
                    korisnikDto = new KorisnikDto
                    {
                        korisnikId = x.korisnik_id,
                        Ime = x.korisnik.Ime,
                        Prezime = x.korisnik.Prezime
                    }
                })
                .ToListAsync();

            return new Message
            {
                Info = "Ok",
                Data = podaci,
                Valid = true,
            };
        }

        
    }
}
