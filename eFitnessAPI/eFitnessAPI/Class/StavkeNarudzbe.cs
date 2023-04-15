using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    public class StavkeNarudzbe
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(Narudzba))]
        public int narudzba_id { get; set; }
        public Narudzba Narudzba { get; set; }
        [ForeignKey(nameof(Suplement))]
        public int suplement_id { get; set; }
        public Suplement Suplement { get; set; }
        public int Kolicina { get; set; }
    }
}
