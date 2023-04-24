using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace eFitnessAPI.ViewModels.KorisnikVM
{
    public class KorisnikGetAllVM
    {
        public string ime { get; set; }
        public string prezime { get; set; }
        public int id { get; set; }
        public string korisnicko_ime { get; set; }
        public string slika { get; set; }
        public bool is_admin { get; set; }
        public string email { get; set; }
    }
}
