using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class Favorites
    {
        public int id { get; set; }
        public int korisnik_id { get; set; }
        public int vjezba_id { get; set; }
    }
}
