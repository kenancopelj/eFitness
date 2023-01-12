using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("VrstaClanarine")]
    public class VrstaClanarine
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public int cijena { get; set; }
    }
}
