using Microsoft.EntityFrameworkCore;
using FireEmblemTTRPG.Domain.Entities;
using FireEmblemTTRPG.Domain.Enums;

namespace FireEmblemTTRPG.Data
{
    public class FEContext : DbContext
    {
        public FEContext(DbContextOptions<FEContext> options)
            : base(options)
        {
        }
        public DbSet<Character> Characters { get; set; }
        public DbSet<Class> Classes { get; set; }
        public DbSet<Weapon> Weapons { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source= (localdb)\\MSSQLLocalDB; Initial Catalog=FEDatabase");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Character>(c =>
            {
                c.OwnsOne(c => c.GrowthRate);
                c.OwnsOne(c => c.StatGrowth);
            });

            builder.Entity<Class>(c =>
            {
                c.OwnsOne(c => c.GrowthRate);
                c.OwnsOne(c => c.MaxStat);
                c.OwnsOne(c => c.BaseStat);
            });

            builder.Entity<Character>()
             .HasMany(s => s.Weapons)
             .WithMany(b => b.Characters)
             .UsingEntity<CharacterWeapon>
              (bs => bs.HasOne<Weapon>().WithMany(),
               bs => bs.HasOne<Character>().WithMany());

            builder.Entity<Character>()
             .HasMany(s => s.Classes)
             .WithMany(b => b.Characters)
             .UsingEntity<CharacterClass>
              (bs => bs.HasOne<Class>().WithMany(),
               bs => bs.HasOne<Character>().WithMany());

            builder.Entity<Weapon>()
            .Property(e => e.WeaponType)
            .HasConversion(
            v => v.ToString(),
            v => (WeaponType)Enum.Parse(typeof(WeaponType), v));

            builder.Entity<Class>()
            .Property(e => e.WeaponType)
            .HasConversion(
            v => v.ToString(),
            v => (WeaponType)Enum.Parse(typeof(WeaponType), v));

            builder.Entity<Class>()
            .Property(e => e.WeaponType2)
            .HasConversion(
            v => v.ToString(),
            v => (WeaponType)Enum.Parse(typeof(WeaponType), v));

            builder.Entity<Class>()
            .Property(e => e.WeaponType3)
            .HasConversion(
            v => v.ToString(),
            v => (WeaponType)Enum.Parse(typeof(WeaponType), v));
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<string>().HaveMaxLength(128);
        }
    }
}