using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    [Table("Osoblje")]
    public class Osoblje : Korisnik
    {
        public DateTime DatumRodjenja { get; set; }
        [ForeignKey(nameof(spol))]
        public int spol_id { get; set; }
        public Spol spol { get; set; }
        public DateTime datumZaposlenja { get; set; }
    }
}
