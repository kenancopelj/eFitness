using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("KategorijaTreninga")]
    public class KategorijaTreninga
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
    }
}
