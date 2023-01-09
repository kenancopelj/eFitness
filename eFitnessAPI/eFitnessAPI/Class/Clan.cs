using Microsoft.AspNetCore.Components.Web;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Clan")]
    public class Clan:Korisnik
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public string spol { get; set; }
        public DateTime datumRodjenja { get; set; }
        public bool jeLiClan { get; set; }
        [ForeignKey(nameof(clanarina))]
        public int clanarina_id { get; set; }
        public Clanarina clanarina { get; set; }


    }
}
