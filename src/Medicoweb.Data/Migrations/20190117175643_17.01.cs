using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Medicoweb.Data.Migrations
{
    public partial class _1701 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "AspNetRoles",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetRoles", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetUsers",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_AspNetUsers", x => x.Id); });

            migrationBuilder.CreateTable(
                "Doctors",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Surname = table.Column<string>(nullable: true),
                    Pesel = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Doctors", x => x.Id); });

            migrationBuilder.CreateTable(
                "Drugs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Company = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Drugs", x => x.Id); });

            migrationBuilder.CreateTable(
                "Hospitals",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Hospitals", x => x.Id); });

            migrationBuilder.CreateTable(
                "Pharmacies",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Pharmacies", x => x.Id); });

            migrationBuilder.CreateTable(
                "Specialization",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table => { table.PrimaryKey("PK_Specialization", x => x.Id); });

            migrationBuilder.CreateTable(
                "AspNetRoleClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    RoleId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserClaims",
                table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy",
                            SqlServerValueGenerationStrategy.IdentityColumn),
                    UserId = table.Column<Guid>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        "FK_AspNetUserClaims_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserLogins",
                table => new
                {
                    LoginProvider = table.Column<string>(nullable: false),
                    ProviderKey = table.Column<string>(nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new {x.LoginProvider, x.ProviderKey});
                    table.ForeignKey(
                        "FK_AspNetUserLogins_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserRoles",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    RoleId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new {x.UserId, x.RoleId});
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        x => x.RoleId,
                        "AspNetRoles",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_AspNetUserRoles_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "AspNetUserTokens",
                table => new
                {
                    UserId = table.Column<Guid>(nullable: false),
                    LoginProvider = table.Column<string>(nullable: false),
                    Name = table.Column<string>(nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new {x.UserId, x.LoginProvider, x.Name});
                    table.ForeignKey(
                        "FK_AspNetUserTokens_AspNetUsers_UserId",
                        x => x.UserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DoctorsTimes",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    DayOfWeek = table.Column<int>(nullable: false),
                    IsCurrent = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DoctorsTimes", x => x.Id);
                    table.ForeignKey(
                        "FK_DoctorsTimes_Doctors_DoctorId",
                        x => x.DoctorId,
                        "Doctors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Visits",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PatientId = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false),
                    IsCancelled = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Visits", x => x.Id);
                    table.ForeignKey(
                        "FK_Visits_Doctors_DoctorId",
                        x => x.DoctorId,
                        "Doctors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Visits_AspNetUsers_PatientId",
                        x => x.PatientId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Departaments",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    HospitalId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departaments", x => x.Id);
                    table.ForeignKey(
                        "FK_Departaments_Hospitals_HospitalId",
                        x => x.HospitalId,
                        "Hospitals",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PharmacyDrugs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PharmacyId = table.Column<Guid>(nullable: false),
                    DrugId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PharmacyDrugs", x => new {x.PharmacyId, x.DrugId});
                    table.ForeignKey(
                        "FK_PharmacyDrugs_Drugs_DrugId",
                        x => x.DrugId,
                        "Drugs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PharmacyDrugs_Pharmacies_PharmacyId",
                        x => x.PharmacyId,
                        "Pharmacies",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "SpecializationDoctors",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    SpecializationId = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SpecializationDoctors", x => new {x.SpecializationId, x.DoctorId});
                    table.ForeignKey(
                        "FK_SpecializationDoctors_Doctors_DoctorId",
                        x => x.DoctorId,
                        "Doctors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_SpecializationDoctors_Specialization_SpecializationId",
                        x => x.SpecializationId,
                        "Specialization",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Prescriptions",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    VisitId = table.Column<Guid>(nullable: false),
                    SBDUserId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prescriptions", x => x.Id);
                    table.ForeignKey(
                        "FK_Prescriptions_AspNetUsers_SBDUserId",
                        x => x.SBDUserId,
                        "AspNetUsers",
                        "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        "FK_Prescriptions_Visits_VisitId",
                        x => x.VisitId,
                        "Visits",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "VisitsTimes",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    StartTime = table.Column<TimeSpan>(nullable: false),
                    EndTime = table.Column<TimeSpan>(nullable: false),
                    VisitId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VisitsTimes", x => x.Id);
                    table.ForeignKey(
                        "FK_VisitsTimes_Visits_VisitId",
                        x => x.VisitId,
                        "Visits",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "DepartamentDoctors",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DepartamentId = table.Column<Guid>(nullable: false),
                    DoctorId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartamentDoctors", x => new {x.DepartamentId, x.DoctorId});
                    table.ForeignKey(
                        "FK_DepartamentDoctors_Departaments_DepartamentId",
                        x => x.DepartamentId,
                        "Departaments",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DepartamentDoctors_Doctors_DoctorId",
                        x => x.DoctorId,
                        "Doctors",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PrescriptionDrugs",
                table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PrescriptionId = table.Column<Guid>(nullable: false),
                    DrugId = table.Column<Guid>(nullable: false),
                    DrugQuantity = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PrescriptionDrugs", x => new {x.PrescriptionId, x.DrugId});
                    table.ForeignKey(
                        "FK_PrescriptionDrugs_Drugs_DrugId",
                        x => x.DrugId,
                        "Drugs",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PrescriptionDrugs_Prescriptions_PrescriptionId",
                        x => x.PrescriptionId,
                        "Prescriptions",
                        "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[]
                {
                    new Guid("3ca04c41-6ba2-41b4-8549-98e09c83777f"), "3ca04c41-6ba2-41b4-8549-98e09c83777f", "Doctor",
                    "DOCTOR"
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[]
                {
                    new Guid("7fd7bc3a-00b6-47d4-a18b-e3c419bbb071"), "7fd7bc3a-00b6-47d4-a18b-e3c419bbb071", "Patient",
                    "PATIENT"
                });

            migrationBuilder.InsertData(
                "AspNetRoles",
                new[] {"Id", "ConcurrencyStamp", "Name", "NormalizedName"},
                new object[]
                {
                    new Guid("4d6100b7-05cb-45da-a6f3-cce42c4f9930"), "4d6100b7-05cb-45da-a6f3-cce42c4f9930", "Admin",
                    "ADMIN"
                });

            migrationBuilder.CreateIndex(
                "IX_AspNetRoleClaims_RoleId",
                "AspNetRoleClaims",
                "RoleId");

            migrationBuilder.CreateIndex(
                "RoleNameIndex",
                "AspNetRoles",
                "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserClaims_UserId",
                "AspNetUserClaims",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserLogins_UserId",
                "AspNetUserLogins",
                "UserId");

            migrationBuilder.CreateIndex(
                "IX_AspNetUserRoles_RoleId",
                "AspNetUserRoles",
                "RoleId");

            migrationBuilder.CreateIndex(
                "EmailIndex",
                "AspNetUsers",
                "NormalizedEmail");

            migrationBuilder.CreateIndex(
                "UserNameIndex",
                "AspNetUsers",
                "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                "IX_DepartamentDoctors_DoctorId",
                "DepartamentDoctors",
                "DoctorId");

            migrationBuilder.CreateIndex(
                "IX_Departaments_HospitalId",
                "Departaments",
                "HospitalId");

            migrationBuilder.CreateIndex(
                "IX_DoctorsTimes_DoctorId",
                "DoctorsTimes",
                "DoctorId",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_PharmacyDrugs_DrugId",
                "PharmacyDrugs",
                "DrugId");

            migrationBuilder.CreateIndex(
                "IX_PrescriptionDrugs_DrugId",
                "PrescriptionDrugs",
                "DrugId");

            migrationBuilder.CreateIndex(
                "IX_Prescriptions_SBDUserId",
                "Prescriptions",
                "SBDUserId");

            migrationBuilder.CreateIndex(
                "IX_Prescriptions_VisitId",
                "Prescriptions",
                "VisitId");

            migrationBuilder.CreateIndex(
                "IX_SpecializationDoctors_DoctorId",
                "SpecializationDoctors",
                "DoctorId");

            migrationBuilder.CreateIndex(
                "IX_Visits_DoctorId",
                "Visits",
                "DoctorId");

            migrationBuilder.CreateIndex(
                "IX_Visits_PatientId",
                "Visits",
                "PatientId");

            migrationBuilder.CreateIndex(
                "IX_VisitsTimes_VisitId",
                "VisitsTimes",
                "VisitId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "AspNetRoleClaims");

            migrationBuilder.DropTable(
                "AspNetUserClaims");

            migrationBuilder.DropTable(
                "AspNetUserLogins");

            migrationBuilder.DropTable(
                "AspNetUserRoles");

            migrationBuilder.DropTable(
                "AspNetUserTokens");

            migrationBuilder.DropTable(
                "DepartamentDoctors");

            migrationBuilder.DropTable(
                "DoctorsTimes");

            migrationBuilder.DropTable(
                "PharmacyDrugs");

            migrationBuilder.DropTable(
                "PrescriptionDrugs");

            migrationBuilder.DropTable(
                "SpecializationDoctors");

            migrationBuilder.DropTable(
                "VisitsTimes");

            migrationBuilder.DropTable(
                "AspNetRoles");

            migrationBuilder.DropTable(
                "Departaments");

            migrationBuilder.DropTable(
                "Pharmacies");

            migrationBuilder.DropTable(
                "Drugs");

            migrationBuilder.DropTable(
                "Prescriptions");

            migrationBuilder.DropTable(
                "Specialization");

            migrationBuilder.DropTable(
                "Hospitals");

            migrationBuilder.DropTable(
                "Visits");

            migrationBuilder.DropTable(
                "Doctors");

            migrationBuilder.DropTable(
                "AspNetUsers");
        }
    }
}