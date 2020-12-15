using System;
using Fotografos.Domain;
using Microsoft.EntityFrameworkCore;

namespace Fotografos.Persistence
{
    public partial class FotomixContext : DbContext
    {
        public FotomixContext() { }

        public FotomixContext(DbContextOptions<FotomixContext> options) : base(options) { }

        public virtual DbSet<Application> Applications { get; set; }
        public virtual DbSet<Photographer> Photographers { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=scripts/fotomix.db");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Application>(entity =>
            {
                entity.ToTable("Application");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Date)
                    .IsRequired()
                    .HasColumnName("date");

                entity.Property(e => e.EquimentDescription)
                    .IsRequired()
                    .HasColumnName("equimentDescription");

                entity.Property(e => e.PhotographerId)
                    .HasColumnType("INT")
                    .HasColumnName("photographerId");

                entity.Property(e => e.Resume)
                    .IsRequired()
                    .HasColumnName("resume");
            });

            modelBuilder.Entity<Photographer>(entity =>
            {
                entity.ToTable("Photographer");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Address)
                    .IsRequired()
                    .HasColumnName("address");

                entity.Property(e => e.City)
                    .IsRequired()
                    .HasColumnName("city");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name");

                entity.Property(e => e.Postalcode)
                    .HasColumnType("INT")
                    .HasColumnName("postalcode");

                entity.Property(e => e.Surename)
                    .IsRequired()
                    .HasColumnName("surename");

                entity.Property(e => e.Telephone)
                    .HasColumnType("INT")
                    .HasColumnName("telephone");
            });

            // Data seeding:
            modelBuilder.Entity<Photographer>().HasData(
                new []
                {
                    new Photographer { Id = 1, Name = "Juan", Surename = "Augusto", Address = "C/Falsa 123", City = "Pueblo Falso", Postalcode = 46448, Telephone = 456456465 },
                    new Photographer { Id = 2, Name = "Carlos", Surename = "Murcia", Address = "C/Falsa 456", City = "Ciudad Falsa", Postalcode = 46444, Telephone = 456456464 },
                }
            );

            modelBuilder.Entity<Application>().HasData(
                new []
                {
                    new Application { Id = 1, PhotographerId = 1, Date = new DateTime(2020, 10, 15), EquimentDescription = "Two cameras", Resume = "Photographer at a wedding" },
                    new Application { Id = 2, PhotographerId = 2, Date = new DateTime(2020, 08, 15), EquimentDescription = "Two cameras and tripod", Resume = "Nature photographer" },
                }
            );

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
