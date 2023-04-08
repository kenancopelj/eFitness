using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Clanarina")]
    public class Clanarina
    {
        [Key]
        public int id { get; set; }
        public DateTime datumKreiranja { get; set; }
        public DateTime datumIsteka { get; set; }

        [ForeignKey(nameof(vrstaClanarine))]
        public int vrsta_clanarine_id { get; set; }
        public VrstaClanarine vrstaClanarine { get; set; }
        public bool aktivna { get; set; }

        [ForeignKey(nameof(korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }

    }
}
