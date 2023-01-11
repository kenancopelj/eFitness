﻿
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

        [JsonIgnore]
        public string lozinka{ get; set; }

        public string slika { get; set; }

        [JsonIgnore]
        public Clan clan => this as Clan;

        [JsonIgnore]
        public Osoblje osoblje => this as Osoblje;
        public bool isClan => clan != null;
        public bool isOsoblje => osoblje != null;
        public bool isAdmin { get; set; }
    }

    
}
