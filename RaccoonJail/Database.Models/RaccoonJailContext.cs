using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Database.Models
{
    public partial class RaccoonJailContext : DbContext
    {
        public RaccoonJailContext()
        {
        }

        public RaccoonJailContext(DbContextOptions<RaccoonJailContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ArrestLocation> ArrestLocations { get; set; }
        public virtual DbSet<HappinessLevel> HappinessLevels { get; set; }
        public virtual DbSet<HungerLevel> HungerLevels { get; set; }
        public virtual DbSet<Inmate> Inmates { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Server=(local);Database=RaccoonJail;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<ArrestLocation>(entity =>
            {
                entity.ToTable("ArrestLocation", "Info");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Location)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<HappinessLevel>(entity =>
            {
                entity.ToTable("HappinessLevel", "Info");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<HungerLevel>(entity =>
            {
                entity.ToTable("HungerLevel", "Info");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);
            });

            modelBuilder.Entity<Inmate>(entity =>
            {
                entity.ToTable("Inmate", "Jail");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsFixedLength(true);

                entity.Property(e => e.Size).HasColumnType("decimal(9, 6)");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
