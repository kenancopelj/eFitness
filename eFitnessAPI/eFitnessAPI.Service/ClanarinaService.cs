using eFitnessAPI;
using eFitnessAPI.Data;
using eFitnessAPI.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public


    }
}
