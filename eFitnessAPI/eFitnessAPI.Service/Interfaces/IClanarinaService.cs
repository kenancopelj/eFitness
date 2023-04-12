using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Service.Interfaces
{
    public interface IClanarinaService
    {
        public Task<Message> GetAll();

        public Task<Message> GetByKorisnik();
        
    }
}
