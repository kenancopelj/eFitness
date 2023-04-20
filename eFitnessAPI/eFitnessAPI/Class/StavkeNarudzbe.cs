using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    public class StavkeNarudzbe
    {
        public int id { get; set; }
        [ForeignKey(nameof(narudzba))]
        public int narudzba_id { get; set; }
        public Narudzba narudzba { get; set; }
        [ForeignKey(nameof(suplement))]
        public int suplement_id { get; set; }
        public Suplement suplement { get; set; }
        public int kolicina { get; set; }
    }
}
