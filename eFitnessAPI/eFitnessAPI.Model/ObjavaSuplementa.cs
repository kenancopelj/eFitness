using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class ObjavaSuplementa
    {
        public int id { get; set; }
        public int osoblje_id { get; set; }
        public int suplement_id { get; set; }
        public DateTime datumDodavanja { get; set; }
    }
}
