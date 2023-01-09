using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("ObjavaSuplementa")]
    public class ObjavaSuplementa
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(osoblje))]
        public int osoblje_id { get; set; }
        public Osoblje osoblje { get; set; }
        [ForeignKey(nameof(suplement))]
        public int suplement_id { get; set; }
        public Suplement suplement { get; set; }
        public DateTime datumDodavanja { get; set; }
    }
}
