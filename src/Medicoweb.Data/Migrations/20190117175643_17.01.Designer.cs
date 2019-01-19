﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;

namespace Medicoweb.Data.Migrations
{
    [DbContext(typeof(MedicowebDbContext))]
    [Migration("20190117175643_17.01")]
    partial class _1701
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.4-rtm-31024")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("RoleId");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<Guid>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<Guid>("UserId");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<Guid>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.Property<Guid>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("SBD.DATA.Models.Account.SBDUser", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("Name");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("Pesel");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<string>("Surname");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("SBD.DATA.Models.Departament", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("HospitalId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("HospitalId");

                    b.ToTable("Departaments");
                });

            modelBuilder.Entity("SBD.DATA.Models.DepartamentDoctor", b =>
                {
                    b.Property<Guid>("DepartamentId");

                    b.Property<Guid>("DoctorId");

                    b.Property<Guid>("Id");

                    b.HasKey("DepartamentId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("DepartamentDoctors");
                });

            modelBuilder.Entity("SBD.DATA.Models.Doctor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<string>("Pesel");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("SBD.DATA.Models.Drug", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Company");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Drugs");
                });

            modelBuilder.Entity("SBD.DATA.Models.Hospital", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Hospitals");
                });

            modelBuilder.Entity("SBD.DATA.Models.Pharmacy", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Address");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Pharmacies");
                });

            modelBuilder.Entity("SBD.DATA.Models.PharmacyDrug", b =>
                {
                    b.Property<Guid>("PharmacyId");

                    b.Property<Guid>("DrugId");

                    b.Property<Guid>("Id");

                    b.HasKey("PharmacyId", "DrugId");

                    b.HasIndex("DrugId");

                    b.ToTable("PharmacyDrugs");
                });

            modelBuilder.Entity("SBD.DATA.Models.Prescription", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid?>("SBDUserId");

                    b.Property<Guid>("VisitId");

                    b.HasKey("Id");

                    b.HasIndex("SBDUserId");

                    b.HasIndex("VisitId");

                    b.ToTable("Prescriptions");
                });

            modelBuilder.Entity("SBD.DATA.Models.PrescriptionDrug", b =>
                {
                    b.Property<Guid>("PrescriptionId");

                    b.Property<Guid>("DrugId");

                    b.Property<int>("DrugQuantity");

                    b.Property<Guid>("Id");

                    b.HasKey("PrescriptionId", "DrugId");

                    b.HasIndex("DrugId");

                    b.ToTable("PrescriptionDrugs");
                });

            modelBuilder.Entity("SBD.DATA.Models.SBDRole", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");

                    b.HasData(
                        new { Id = new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"), ConcurrencyStamp = "3ca04c41-6ba2-41b4-8549-98e09c83777f", Name = "Doctor", NormalizedName = "DOCTOR" },
                        new { Id = new Guid("7fd7bc3a-00b6-47d4-a18b-e3c419bbb071"), ConcurrencyStamp = "7fd7bc3a-00b6-47d4-a18b-e3c419bbb071", Name = "Patient", NormalizedName = "PATIENT" },
                        new { Id = new Guid("4d6100b7-05cb-45da-a6f3-cce42c4f9930"), ConcurrencyStamp = "4d6100b7-05cb-45da-a6f3-cce42c4f9930", Name = "Admin", NormalizedName = "ADMIN" }
                    );
                });

            modelBuilder.Entity("SBD.DATA.Models.Schedule.DoctorTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("DayOfWeek");

                    b.Property<Guid>("DoctorId");

                    b.Property<TimeSpan>("EndTime");

                    b.Property<bool>("IsCurrent");

                    b.Property<TimeSpan>("StartTime");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId")
                        .IsUnique();

                    b.ToTable("DoctorsTimes");
                });

            modelBuilder.Entity("SBD.DATA.Models.Schedule.VisitTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<TimeSpan>("EndTime");

                    b.Property<TimeSpan>("StartTime");

                    b.Property<Guid>("VisitId");

                    b.HasKey("Id");

                    b.HasIndex("VisitId")
                        .IsUnique();

                    b.ToTable("VisitsTimes");
                });

            modelBuilder.Entity("SBD.DATA.Models.Specialization", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Specialization");
                });

            modelBuilder.Entity("SBD.DATA.Models.SpecializationDoctor", b =>
                {
                    b.Property<Guid>("SpecializationId");

                    b.Property<Guid>("DoctorId");

                    b.Property<Guid>("Id");

                    b.HasKey("SpecializationId", "DoctorId");

                    b.HasIndex("DoctorId");

                    b.ToTable("SpecializationDoctors");
                });

            modelBuilder.Entity("SBD.DATA.Models.Visit", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<Guid>("DoctorId");

                    b.Property<bool>("IsCancelled");

                    b.Property<Guid>("PatientId");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.HasIndex("PatientId");

                    b.ToTable("Visits");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<System.Guid>", b =>
                {
                    b.HasOne("SBD.DATA.Models.SBDRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<System.Guid>", b =>
                {
                    b.HasOne("SBD.DATA.Models.Account.SBDUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<System.Guid>", b =>
                {
                    b.HasOne("SBD.DATA.Models.Account.SBDUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<System.Guid>", b =>
                {
                    b.HasOne("SBD.DATA.Models.SBDRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Account.SBDUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<System.Guid>", b =>
                {
                    b.HasOne("SBD.DATA.Models.Account.SBDUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.Departament", b =>
                {
                    b.HasOne("SBD.DATA.Models.Hospital", "Hospital")
                        .WithMany("Departaments")
                        .HasForeignKey("HospitalId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.DepartamentDoctor", b =>
                {
                    b.HasOne("SBD.DATA.Models.Departament", "Departament")
                        .WithMany("DepartamentDoctors")
                        .HasForeignKey("DepartamentId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Doctor", "Doctor")
                        .WithMany("DepartamentDoctors")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.PharmacyDrug", b =>
                {
                    b.HasOne("SBD.DATA.Models.Drug", "Drug")
                        .WithMany("PharmacyDrugs")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Pharmacy", "Pharmacy")
                        .WithMany("PharmacyDrugs")
                        .HasForeignKey("PharmacyId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.Prescription", b =>
                {
                    b.HasOne("SBD.DATA.Models.Account.SBDUser")
                        .WithMany("Prescriptions")
                        .HasForeignKey("SBDUserId");

                    b.HasOne("SBD.DATA.Models.Visit", "Visit")
                        .WithMany("Prescription")
                        .HasForeignKey("VisitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.PrescriptionDrug", b =>
                {
                    b.HasOne("SBD.DATA.Models.Drug", "Drug")
                        .WithMany("PrescriptionDrug")
                        .HasForeignKey("DrugId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Prescription", "Prescription")
                        .WithMany("PrescriptionDrug")
                        .HasForeignKey("PrescriptionId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.Schedule.DoctorTime", b =>
                {
                    b.HasOne("SBD.DATA.Models.Doctor", "Doctor")
                        .WithOne("TimeOfWork")
                        .HasForeignKey("SBD.DATA.Models.Schedule.DoctorTime", "DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.Schedule.VisitTime", b =>
                {
                    b.HasOne("SBD.DATA.Models.Visit", "Visit")
                        .WithOne("Date")
                        .HasForeignKey("SBD.DATA.Models.Schedule.VisitTime", "VisitId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.SpecializationDoctor", b =>
                {
                    b.HasOne("SBD.DATA.Models.Doctor", "Doctor")
                        .WithMany("SpecializationDoctor")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Specialization", "Specialization")
                        .WithMany("SpecializationDoctor")
                        .HasForeignKey("SpecializationId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SBD.DATA.Models.Visit", b =>
                {
                    b.HasOne("SBD.DATA.Models.Doctor", "Doctor")
                        .WithMany("Visits")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SBD.DATA.Models.Account.SBDUser", "Patient")
                        .WithMany("Visits")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
