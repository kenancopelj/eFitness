using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("AktivacijskiToken")]
    public class AktivacijskiToken
    {
        [Key]
        public int Id { get; set; }
        public string Token { get; set; }
        public string Korisnik { get; set; }
    }
}
