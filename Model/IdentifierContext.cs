using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace kurs_idrisov.Model;

public partial class IdentifierContext : DbContext
{
    public IdentifierContext()
    {
    }

    public IdentifierContext(DbContextOptions<IdentifierContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Doctor> Doctors { get; set; }

    public virtual DbSet<Drug> Drugs { get; set; }

    public virtual DbSet<Patient> Patients { get; set; }

    public virtual DbSet<Priem> Priems { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("Data Source=..\\..\\..\\BD\\identifier.db");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Doctor>(entity =>
        {
            entity.ToTable("doctor");

            entity.Property(e => e.DoctorId)
                .ValueGeneratedOnAdd() // <-- Изменено
                .HasColumnName("doctor_id");
            entity.Property(e => e.DoctorLogin).HasColumnName("doctor_login");
            entity.Property(e => e.DoctorName).HasColumnName("doctor_name");
            entity.Property(e => e.DoctorPassword).HasColumnName("doctor_password");
        });

        modelBuilder.Entity<Drug>(entity =>
        {
            entity.ToTable("drug");
            entity.HasKey(e => e.DrugId);

            entity.Property(e => e.DrugId)
                .ValueGeneratedOnAdd() // <-- Изменено
                .HasColumnName("drug_id");
            entity.Property(e => e.Deistvie).HasColumnName("deistvie");
            entity.Property(e => e.DrugName).HasColumnName("drug_name");
            entity.Property(e => e.PobochnieEffects).HasColumnName("pobochnie_effects");
            entity.Property(e => e.SposobPriema).HasColumnName("sposob_priema");
        });

        modelBuilder.Entity<Patient>(entity =>
        {
            entity.ToTable("patient");

            entity.Property(e => e.PatientId)
                .ValueGeneratedOnAdd() // <-- Изменено
                .HasColumnName("patient_id");
            entity.Property(e => e.Adres).HasColumnName("adres");
            entity.Property(e => e.DataRosdeniya)
                .HasColumnType("DATE")
                .HasColumnName("data_rosdeniya");
            entity.Property(e => e.PatientName).HasColumnName("patient_name");
            entity.Property(e => e.Pol).HasColumnName("pol");
        });

        modelBuilder.Entity<Priem>(entity =>
        {
            entity.ToTable("priem");

            entity.Property(e => e.PriemId)
                .ValueGeneratedOnAdd() // <-- Изменено
                .HasColumnName("priem_id");
            entity.Property(e => e.Data)
                .HasColumnType("DATE")
                .HasColumnName("data");
            entity.Property(e => e.Diagnoz).HasColumnName("diagnoz");
            entity.Property(e => e.DoctorId).HasColumnName("doctor_id");
            entity.Property(e => e.DrugId).HasColumnName("drug_id");
            entity.Property(e => e.Mesto).HasColumnName("mesto");
            entity.Property(e => e.Naznachenie).HasColumnName("naznachenie");
            entity.Property(e => e.PatientId).HasColumnName("patient_id");
            entity.Property(e => e.Simptomi).HasColumnName("simptomi");

            entity.HasOne(d => d.Doctor).WithMany(p => p.Priems).HasForeignKey(d => d.DoctorId);

            entity.HasOne(d => d.Drug).WithMany(p => p.Priems).HasForeignKey(d => d.DrugId);

            entity.HasOne(d => d.Patient).WithMany(p => p.Priems).HasForeignKey(d => d.PatientId);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
