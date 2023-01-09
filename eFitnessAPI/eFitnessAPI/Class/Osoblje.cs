using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    [Table("Osoblje")]
    public class Osoblje : Korisnik
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public DateTime datumRodjenja { get; set; }
        public DateTime datumZaposlenja { get; set; }
        public string spol { get; set; }
    }
}
