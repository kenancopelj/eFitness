using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;

namespace eFitnessAPI.ViewModels.KorisnikVM
{
    public class KorisnikGetAllVM
    {
        public int id { get; set; }
        public string korisnicko_ime { get; set; }
        public string slika { get; set; }
    }
}
