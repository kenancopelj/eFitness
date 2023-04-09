using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    public class Narudzba
    {
        public int narudzbaID { get; set; }
        public int Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
        public virtual List<Suplement> Suplementi { get; set; }

    }
}
