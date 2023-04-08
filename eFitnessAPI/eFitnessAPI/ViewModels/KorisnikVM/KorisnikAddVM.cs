namespace eFitnessAPI.ViewModels.KorisnikVM
{
    public class KorisnikAddVM
    {
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string korisnicko_ime { get; set; }
        public string lozinka { get; set; }
        public string? slika_korisnika_base63 { get; set; }
        public bool isAdmin { get; set; }
    }
}
