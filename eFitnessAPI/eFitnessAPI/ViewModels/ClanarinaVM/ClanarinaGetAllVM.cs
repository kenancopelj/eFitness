using eFitnessAPI.Class;

namespace eFitnessAPI.ViewModels.ClanarinaVM
{
    public class ClanarinaGetAllVM
    {
        public DateTime datumIsteka { get; set; }
        public DateTime datumKreiranja { get; set; }
        public int vrsta_clanarine_id { get; set; }
        public bool aktivna { get; set; }
        public KorisnikDto korisnikDto { get; set; }
    }
}
