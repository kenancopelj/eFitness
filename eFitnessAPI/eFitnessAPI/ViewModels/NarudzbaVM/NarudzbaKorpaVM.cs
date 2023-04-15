using eFitnessAPI.Class;

namespace eFitnessAPI.ViewModels.NarudzbaVM
{
    public class NarudzbaKorpaVM
    {
        public int Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
        public virtual List<Suplement> Suplementi { get; set; }

    }
}
