using Medicoweb.Data.Models.Account;
using Medicoweb.Data.Models.Drug;
using Medicoweb.Data.Models.Hospital;
using Medicoweb.Data.Models.Schedule;
using Medicoweb.Data.Models.Visit;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace Medicoweb.Data
{
    public class MedicowebDbContext : IdentityDbContext<MedicowebUser, MedicowebRole, Guid>
    {
        public MedicowebDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Departament> Departaments { get; set; }
        public DbSet<DepartamentDoctor> DepartamentDoctors { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<SpecializationDoctor> SpecializationDoctors { get; set; }
        public DbSet<Drug> Drugs { get; set; }
        public DbSet<Hospital> Hospitals { get; set; }
        public DbSet<Pharmacy> Pharmacies { get; set; }
        public DbSet<PharmacyDrug> PharmacyDrugs { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<PrescriptionDrug> PrescriptionDrugs { get; set; }
        public DbSet<Specialization> Specialization { get; set; }
        public DbSet<Visit> Visits { get; set; }
        public DbSet<VisitTime> VisitsTimes { get; set; }
        public DbSet<DoctorTime> DoctorsTimes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicowebRole>().HasData(new MedicowebRole
            {
                Id = new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"),
                Name = "Doctor",
                NormalizedName = "DOCTOR",
                ConcurrencyStamp = "3ca04c41-6ba2-41b4-8549-98e09c83777f"
            });
            modelBuilder.Entity<MedicowebRole>().HasData(new MedicowebRole
            {
                Id = new Guid("7fd7bc3a-00b6-47d4-a18b-e3c419bbb071"),
                Name = "Patient",
                NormalizedName = "PATIENT",
                ConcurrencyStamp = "7fd7bc3a-00b6-47d4-a18b-e3c419bbb071"
            });
            modelBuilder.Entity<MedicowebRole>().HasData(new MedicowebRole
            {
                Id = new Guid("4d6100b7-05cb-45da-a6f3-cce42c4f9930"),
                Name = "Admin",
                NormalizedName = "ADMIN",
                ConcurrencyStamp = "4d6100b7-05cb-45da-a6f3-cce42c4f9930"
            });

            modelBuilder.Entity<Visit>()
                .HasOne(a => a.Date)
                .WithOne(b => b.Visit)
                .HasForeignKey<VisitTime>(b => b.VisitId);

            modelBuilder.Entity<Doctor>()
                .HasOne(a => a.TimeOfWork)
                .WithOne(b => b.Doctor)
                .HasForeignKey<DoctorTime>(b => b.DoctorId);

            modelBuilder.Entity<DepartamentDoctor>().HasKey(bc => new {bc.DepartamentId, bc.DoctorId});
            modelBuilder.Entity<DepartamentDoctor>()
                .HasOne(bc => bc.Departament)
                .WithMany(b => b.DepartamentDoctors)
                .HasForeignKey(bc => bc.DepartamentId);
            modelBuilder.Entity<DepartamentDoctor>()
                .HasOne(bc => bc.Doctor)
                .WithMany(c => c.DepartamentDoctors)
                .HasForeignKey(bc => bc.DoctorId);

            modelBuilder.Entity<PharmacyDrug>().HasKey(bc => new {bc.PharmacyId, bc.DrugId});
            modelBuilder.Entity<PharmacyDrug>()
                .HasOne(bc => bc.Pharmacy)
                .WithMany(b => b.PharmacyDrugs)
                .HasForeignKey(bc => bc.PharmacyId);
            modelBuilder.Entity<PharmacyDrug>()
                .HasOne(bc => bc.Drug)
                .WithMany(c => c.PharmacyDrugs)
                .HasForeignKey(bc => bc.DrugId);

            modelBuilder.Entity<PrescriptionDrug>().HasKey(bc => new {bc.PrescriptionId, bc.DrugId});
            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(bc => bc.Prescription)
                .WithMany(b => b.PrescriptionDrug)
                .HasForeignKey(bc => bc.PrescriptionId);
            modelBuilder.Entity<PrescriptionDrug>()
                .HasOne(bc => bc.Drug)
                .WithMany(c => c.PrescriptionDrug)
                .HasForeignKey(bc => bc.DrugId);

            modelBuilder.Entity<SpecializationDoctor>().HasKey(bc => new {bc.SpecializationId, bc.DoctorId});
            modelBuilder.Entity<SpecializationDoctor>()
                .HasOne(bc => bc.Specialization)
                .WithMany(b => b.SpecializationDoctor)
                .HasForeignKey(bc => bc.SpecializationId);
            modelBuilder.Entity<SpecializationDoctor>()
                .HasOne(bc => bc.Doctor)
                .WithMany(c => c.SpecializationDoctor)
                .HasForeignKey(bc => bc.DoctorId);

            base.OnModelCreating(modelBuilder);
        }
    }
}