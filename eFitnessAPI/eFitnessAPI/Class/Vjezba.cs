using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Vjezba")]
    public class Vjezba
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        [ForeignKey(nameof(kategorijaVjezbe))]
        public int kategorija_id { get; set; }
        public KategorijaVjezbe kategorijaVjezbe { get; set; }
    }
}
