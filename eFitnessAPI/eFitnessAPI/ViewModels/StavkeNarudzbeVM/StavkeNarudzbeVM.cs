using eFitnessAPI.Class;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.ViewModels.StavkeNarudzbeVM
{
    public class StavkeNarudzbeVM
    {
        public int id { get; set; }
        public int narudzba_id { get; set; }
        public int suplement_id { get; set; }
        public int kolicina { get; set; }
    }
}
