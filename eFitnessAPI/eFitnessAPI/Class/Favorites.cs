using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Favorites")]
    public class Favorites
    {
        [Key]
        public int id { get; set; }
        [ForeignKey(nameof(clan))]
        public int clan_id { get; set; }
        public Clan clan { get; set; }
        [ForeignKey(nameof(vjezba))]
        public int vjezba_id { get; set; }
        public Vjezba vjezba { get; set; }
    }
}
