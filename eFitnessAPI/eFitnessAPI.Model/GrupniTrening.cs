using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class GrupniTrening
    {
        public int id { get; set; }
        public int kategorija_id { get; set; }
        public DateTime vrijemeOdrzavanja { get; set; }
    }
}
