using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    public  class Narudzba
    {
        public int narudzbaID { get; set; }
        public decimal Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
        [ForeignKey(nameof(korisnik))]
        public int korisnik_id { get; set; }
        public Korisnik korisnik { get; set; }
        public bool kupljeno { get; set; }

        public Narudzba()
        {
            kupljeno = false;
        }

        

        

    }
}
