using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace EFCoreApp.Models
{
    public partial class StorageDBContext : DbContext
    {

        public StorageDBContext(DbContextOptions<StorageDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<PassportDetails> PassportDetails { get; set; }
        public virtual DbSet<Person> Person { get; set; }

        public virtual DbSet<PersonDetails> PersonDetails { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<PassportDetails>(entity =>
            {
                entity.HasKey(e => e.PkPassportId)
                    .HasName("PK__Passport__7F6837A660A367E5");

                entity.HasIndex(e => e.FkPersonId)
                    .HasName("UQ__Passport__04554C331EA7C82F")
                    .IsUnique();

                entity.Property(e => e.PkPassportId)
                    .HasColumnName("Pk_Passport_Id")
                    .ValueGeneratedNever();

                entity.Property(e => e.FkPersonId).HasColumnName("Fk_Person_Id");

                entity.Property(e => e.PassportNumber)
                    .HasColumnName("Passport_Number")
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkPerson)
                    .WithOne(p => p.PassportDetails)
                    .HasForeignKey<PassportDetails>(d => d.FkPersonId)
                    .HasConstraintName("FK__PassportD__Fk_Pe__276EDEB3");
            });

            modelBuilder.Entity<Person>(entity =>
            {
                entity.HasKey(e => e.PkPersonId)
                    .HasName("PK__Person__27401FF65FBB9E53");

                entity.Property(e => e.PkPersonId).HasColumnName("Pk_Person_Id");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<PersonDetails>(entity =>
            {
                entity.HasKey(e => e.PassportId);

                entity.Property(e => e.Name)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.PassportId)
                    .ValueGeneratedNever();

                entity.Property(e => e.PassportNumber)
                    .HasMaxLength(255)
                    .IsUnicode(false);

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
