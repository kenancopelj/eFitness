using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Reflection.Metadata.Ecma335;

namespace eFitnessAPI.Class
{
    public class Narudzba
    {
        public int narudzbaID { get; set; }
        public decimal Total { get; set; }
        public DateTime VrijemePravljenja { get; set; }
        public virtual ICollection<Item> Suplementi { get; set; }

    }
}
