using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class Osoblje : Korisnik
    {
        public DateTime DatumRodjenja { get; set; }
        public int spol_id { get; set; }
        public DateTime datumZaposlenja { get; set; }
    }
}
