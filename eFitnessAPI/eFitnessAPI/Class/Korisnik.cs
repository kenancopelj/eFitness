using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace eFitnessAPI.Class
{
    [Table("Korisnik")]
    public class Korisnik
    {
        [Key]
        public int id { get; set; }
        public string korisnikoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }

        [JsonIgnore]
        public string lozinka{ get; set; }
        [JsonIgnore]
        public string slika { get; set; }
        public Osoblje osoblje => this as Osoblje;
        public bool isOsoblje => osoblje != null;
        public bool isAdmin { get; set; }
        public string email { get; set; }

        public string? aktivacijaToken { get; set; }

    }

    
}
