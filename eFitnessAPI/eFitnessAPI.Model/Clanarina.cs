using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
   
    public class Clanarina
    {
        public int id { get; set; }
        public DateTime datumKreiranja { get; set; }
        public DateTime datumIsteka { get; set; }

        public int vrsta_clanarine_id { get; set; }
        public bool aktivna { get; set; }

        public int korisnik_id { get; set; }

    }
}
