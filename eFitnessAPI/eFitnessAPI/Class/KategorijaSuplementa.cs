using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("KategorijaSuplementa")]
    public class KategorijaSuplementa
    {
        [Key]
        public int id { get; set; }
        public int naziv { get; set; }
    }
}
