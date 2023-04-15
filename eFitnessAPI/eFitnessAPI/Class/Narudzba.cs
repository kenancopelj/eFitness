using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    public class Narudzba
    {
        [Key]
        public int narudzbaID { get; set; }
        [ForeignKey(nameof(Korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik Korisnik { get; set; }
        public DateTime VrijemePravljenja { get; set; }
    }
}
