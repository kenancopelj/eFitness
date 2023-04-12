namespace eFitnessAPI.ViewModels.GrupniTreningVM
{
    public class GrupniTreningGetAllVM
    {
        public int id { get; set; }
        public int kategorija_id { get; set; }
        public DateTime vrijeme_odrzavanja { get; set; }
        public string naziv_kategorije { get; set; }
    }
}
