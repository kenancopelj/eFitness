﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace eFitnessAPI.Class
{
    [Table("Suplement")]
    public class Suplement
    {
        [Key]
        public int id { get; set; }
        public string naziv { get; set; }
        public DateTime rokTrajanja { get; set; }
        public string opis { get; set; }
        public double cijena { get; set; }
        [ForeignKey(nameof(kategorija))]
        public int kategorija_id { get; set; }
        public KategorijaSuplementa kategorija { get; set; }
        public byte[]? slika_suplement_bytes { get; set; }
        public string? slika_suplement_fs { get; set; }
    }
}
