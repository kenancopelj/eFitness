using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace eFitnessAPI.Model
{
    public class Korisnik
    {
        public int id { get; set; }
        public string korisnikoIme { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string lozinka { get; set; }
        public string slika { get; set; }
        //public Osoblje osoblje => this as Osoblje;
        //public bool isOsoblje => osoblje != null;
        public bool isAdmin { get; set; }
    }
}
