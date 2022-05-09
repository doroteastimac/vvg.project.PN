using Microsoft.EntityFrameworkCore;
using Model.PN.model;
using System;

namespace Console.PN.Database
{
    public class PNDbContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql(@"Host=localhost;Port=5432;Database=postgres;Username=postgres;Password=postgres");
        }

        public PNDbContext()
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        public DbSet<MjestoPutovanja>? MjestoPutovanja { get; set; }
        public DbSet<PutniNalog>? PutniNalog { get; set; }
        public DbSet<PutniTroskovi>? PutniTroskovi { get; set; }
        public DbSet<RadnoMjesto>? RadnoMjesto { get; set; }
        public DbSet<Vozilo>? Vozilo { get; set; }
        public DbSet<VrstaTroska>? VrstaTroska { get; set; }
        public DbSet<Zaposlenik>? Zaposlenik { get; set; }

    }
   
}
