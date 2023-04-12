namespace eFitnessAPI.ViewModels.GrupniTreningVM
{
    public class GrupniTreningAddVM
    {
        public int kategorija_id { get; set; }
        public DateTime vrijeme_odrzavanja { get; set; }
        public string? slika_suplementa_base63 { get; set; }
    }
}
