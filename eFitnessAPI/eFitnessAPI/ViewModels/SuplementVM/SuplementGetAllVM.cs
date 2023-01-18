namespace eFitnessAPI.ViewModels.SuplementVM
{
    public class SuplementGetAllVM
    {
        public string naziv { get; set; }
        public DateTime rokTrajanja { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        public int kategorija_id { get; set; }
        public string slika_suplementa_base64 { get; set; }
    }
}
