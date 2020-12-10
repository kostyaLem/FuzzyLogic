using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using FuzzyLogic.DB.Context.Models;

#nullable disable

namespace FuzzyLogic.DB.Context
{
    public partial class FuzzyContext : DbContext
    {
        public FuzzyContext()
        {
        }

        public FuzzyContext(DbContextOptions<FuzzyContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Account> Accounts { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<Material> Materials { get; set; }
        public virtual DbSet<MaterialColor> MaterialColors { get; set; }
        public virtual DbSet<Report> Reports { get; set; }
        public virtual DbSet<Role> Roles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Account>(entity =>
            {
                entity.ToTable("Account");

                entity.Property(e => e.Login).IsRequired();

                entity.Property(e => e.Password).IsRequired();

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.Accounts)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<File>(entity =>
            {
                entity.ToTable("File");

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<Material>(entity =>
            {
                entity.ToTable("Material");

                entity.Property(e => e.Name).IsRequired();
            });

            modelBuilder.Entity<MaterialColor>(entity =>
            {
                entity.ToTable("MaterialColor");

                entity.Property(e => e.Image).IsRequired();

                entity.Property(e => e.Name).IsRequired();

                entity.HasOne(d => d.Material)
                    .WithMany(p => p.MaterialColors)
                    .HasForeignKey(d => d.MaterialId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });

            modelBuilder.Entity<Report>(entity =>
            {
                entity.ToTable("Report");

                entity.Property(e => e.Date).IsRequired();

                entity.Property(e => e.Image).IsRequired();

                entity.HasOne(d => d.Account)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.AccountId);

                entity.HasOne(d => d.MaterialColor)
                    .WithMany(p => p.Reports)
                    .HasForeignKey(d => d.MaterialColorId);
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.ToTable("Role");

                entity.Property(e => e.Name).IsRequired();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
