using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("PrijavaGrupniTrening")]
    public class PrijavaGrupniTrening
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(clan))]
        public int clan_id { get; set; }
        public Clan clan { get; set; }
        [ForeignKey(nameof(grupniTrening))]
        public int grupni_trening_id { get; set; }
        public GrupniTrening grupniTrening { get; set; }
        public DateTime datumPrijave { get; set; }
    }
}
