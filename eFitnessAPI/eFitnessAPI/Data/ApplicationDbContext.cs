using eFitnessAPI.Class;
using eFitnessAPI.Controllers.Autentifikacija;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace eFitnessAPI.Data
{
    public class ApplicationDbContext:DbContext
    {
        public DbSet<Korisnik> Korisnik { get; set; }
        public DbSet<Osoblje> Osoblje { get; set; }
        public DbSet<Clanarina> Clanarina { get; set; }
        public DbSet<GrupniTrening> GrupniTrening { get; set; }
        public DbSet<KategorijaTreninga> KategorijaTreninga { get; set; }
        public DbSet<VrstaClanarine> VrstaClanarine { get; set; }
        public DbSet<Trener> Trener { get; set; }
        public DbSet<AutentifikacijaToken> AutentifikacijaToken { get; set; }
        public DbSet<PrijavaGrupniTrening> PrijavaGrupniTrening { get; set; }
        public DbSet<Suplement> Suplement { get; set; }
        public DbSet<Vjezba> Vjezba { get; set; }
        public DbSet<KategorijaVjezbe> KategorijaVjezbe { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<KategorijaSuplementa> KategorijaSuplementa { get; set; }
        public DbSet<ObjavaSuplementa> ObjavaSuplementa { get; set; }
        public DbSet<Narudzba> Narudzba { get; set; }
        public DbSet<StavkeNarudzbe> StavkeNarudzbe { get; set; }
        public DbSet<Item> Item { get; set; }
        public DbSet<AktivacijskiToken> AktivacijskiToken { get; set; }



        public ApplicationDbContext(DbContextOptions options):base(options){ 
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           /* modelBuilder.Entity<Clan>()
            .HasOne<Clanarina>(s => s.clanarina)
            .WithOne(ad => ad.clan)
            .HasForeignKey<Clanarina>(ad => ad.clan);*/
        }
    }
}
