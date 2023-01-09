using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("KategorijaVjezbe")]
    public class KategorijaVjezbe
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
