namespace eFitnessAPI.ViewModels.ClanarinaVM
{
    public class ClanarinaAddVM
    {
        public DateTime datumKreiranja { get; set; }
        public DateTime datumIsteka { get; set; }
        public int vrsta_clanarine_id { get; set; }
        public bool aktivna { get; set; }
        public int korisnik_id { get; set; }
        public DateTime datumRodjenja { get; set; }
    }
}
