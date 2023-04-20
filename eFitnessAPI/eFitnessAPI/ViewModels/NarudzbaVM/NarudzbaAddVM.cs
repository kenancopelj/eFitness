using eFitnessAPI.Class;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.ViewModels.NarudzbaVM
{
    public class NarudzbaAddVM
    {
        public int narudzbaID { get; set; }
        public decimal Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
        public int korisnik_id { get; set; }
    }
}
