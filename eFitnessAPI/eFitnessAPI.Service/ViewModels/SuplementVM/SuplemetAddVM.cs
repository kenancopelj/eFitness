namespace eFitnessAPI.ViewModels.SuplementVM
{
    public class SuplemetAddVM
    {
        public string naziv { get; set; }
        public DateTime rokTrajanja { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        public int kategorija_id { get; set; }
        public string? slika_suplementa_base63 { get; set; }

    }
}
