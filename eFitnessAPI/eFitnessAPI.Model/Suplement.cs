using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class Suplement
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public DateTime rokTrajanja { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        public int kategorija_id { get; set; }
    }
}
