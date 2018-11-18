using System.IO;
using Domain.MegaSena;
using Domain.LotoFacil;
using Repository.Mappings;
using Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Repository.Context
{
    public class LoteriaContext : DbContext
    {
        public LoteriaContext(DbContextOptions opt) : base(opt) { }
       
        public DbSet<LotoFacilCEF> LotoFacilCEFs { get; set; }
        public DbSet<MegaSenaCEF> MegaSenaCEFs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.AddConfiguration(new LotoFacilMapping());
            modelBuilder.AddConfiguration(new MegaSenaMapping());

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            //optionsBuilder.UseMySql(config.GetConnectionString("DefaultConnection"));
        }
    }
}
