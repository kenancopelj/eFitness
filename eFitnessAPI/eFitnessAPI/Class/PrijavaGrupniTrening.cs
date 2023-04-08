using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("PrijavaGrupniTrening")]
    public class PrijavaGrupniTrening
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey(nameof(korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }
        [ForeignKey(nameof(grupniTrening))]
        public int grupni_trening_id { get; set; }
        public GrupniTrening grupniTrening { get; set; }
        public DateTime datumPrijave { get; set; }
    }
}
