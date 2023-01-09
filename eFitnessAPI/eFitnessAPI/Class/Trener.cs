using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Trener")]
    public class Trener:Osoblje
    {
        public string Specijalnost { get; set; }
    }
}
