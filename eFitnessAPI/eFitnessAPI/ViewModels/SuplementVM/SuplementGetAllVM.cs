namespace eFitnessAPI.ViewModels.SuplementVM
{
    public class SuplementGetAllVM
    {
        public int id { get; set; }
        public string naziv { get; set; }
        public DateTime rokTrajanja { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        public string kategorija { get; set; }
    }
}
