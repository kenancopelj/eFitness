using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class Narudzba
    {
        public int narudzbaID { get; set; }
        public int Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
       // public virtual List<Suplement> Suplementi { get; set; }
    }
}
