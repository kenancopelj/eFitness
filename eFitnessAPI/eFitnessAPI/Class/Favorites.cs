using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Favorites")]
    public class Favorites
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }
        [ForeignKey(nameof(vjezba))]
        public int vjezba_id { get; set; }
        public Vjezba vjezba { get; set; }
    }
}
