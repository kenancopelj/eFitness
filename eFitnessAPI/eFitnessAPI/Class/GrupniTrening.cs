using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("GrupniTrening")]
    public class GrupniTrening
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(kategorija))]
        public int kategorija_id { get; set; }
        public KategorijaTreninga kategorija { get; set; }
        public DateTime vrijemeOdrzavanja { get; set; }
    }
}
