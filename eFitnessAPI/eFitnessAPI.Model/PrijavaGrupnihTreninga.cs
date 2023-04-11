using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class PrijavaGrupnihTreninga
    {
        public int Id { get; set; }
        public int korisnik_id { get; set; }
        public int grupni_trening_id { get; set; }
        public DateTime datumPrijave { get; set; }
    }
}
