﻿// <auto-generated />
using System;
using HospitalManagement.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HospitalManagement.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HospitalManagement.Models.Department", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Departments");
                });

            modelBuilder.Entity("HospitalManagement.Models.Doctor", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Specialization")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId");

                    b.ToTable("Doctors");
                });

            modelBuilder.Entity("HospitalManagement.Models.DoctorDepartment", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId")
                        .HasColumnType("int");

                    b.Property<int>("DepartmentId1")
                        .HasColumnType("int");

                    b.Property<int>("DoctorId1")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "DepartmentId");

                    b.HasIndex("DepartmentId");

                    b.HasIndex("DepartmentId1");

                    b.HasIndex("DoctorId1");

                    b.ToTable("DoctorDepartment");
                });

            modelBuilder.Entity("HospitalManagement.Models.DoctorPatients", b =>
                {
                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.HasKey("DoctorId", "PatientId");

                    b.HasIndex("PatientId");

                    b.ToTable("DoctorPatients");
                });

            modelBuilder.Entity("HospitalManagement.Models.MedicalRecord", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Diagnosis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MedicalRecordId")
                        .HasColumnType("int");

                    b.Property<int>("PatientId")
                        .HasColumnType("int");

                    b.Property<string>("Prescription")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("PatientId")
                        .IsUnique();

                    b.ToTable("MedicalRecords");
                });

            modelBuilder.Entity("HospitalManagement.Models.Patient", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DateCreated")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("DateModified")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PrimaryDoctorId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("DoctorId");

                    b.ToTable("Patients");
                });

            modelBuilder.Entity("HospitalManagement.Models.Doctor", b =>
                {
                    b.HasOne("HospitalManagement.Models.Patient", null)
                        .WithMany("DoctorsList")
                        .HasForeignKey("PatientId");
                });

            modelBuilder.Entity("HospitalManagement.Models.DoctorDepartment", b =>
                {
                    b.HasOne("HospitalManagement.Models.Department", null)
                        .WithMany("DoctorDepartments")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Models.Department", "Department")
                        .WithMany()
                        .HasForeignKey("DepartmentId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Models.Doctor", null)
                        .WithMany("DoctorDepartments")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Models.Doctor", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId1")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalManagement.Models.DoctorPatients", b =>
                {
                    b.HasOne("HospitalManagement.Models.Doctor", "Doctor")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HospitalManagement.Models.Patient", "Patient")
                        .WithMany("DoctorPatients")
                        .HasForeignKey("PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doctor");

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Models.MedicalRecord", b =>
                {
                    b.HasOne("HospitalManagement.Models.Patient", "Patient")
                        .WithOne("MedicalRecord")
                        .HasForeignKey("HospitalManagement.Models.MedicalRecord", "PatientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Patient");
                });

            modelBuilder.Entity("HospitalManagement.Models.Patient", b =>
                {
                    b.HasOne("HospitalManagement.Models.Doctor", "Doctor")
                        .WithMany("PatientsList")
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("HospitalManagement.Models.Department", b =>
                {
                    b.Navigation("DoctorDepartments");
                });

            modelBuilder.Entity("HospitalManagement.Models.Doctor", b =>
                {
                    b.Navigation("DoctorDepartments");

                    b.Navigation("DoctorPatients");

                    b.Navigation("PatientsList");
                });

            modelBuilder.Entity("HospitalManagement.Models.Patient", b =>
                {
                    b.Navigation("DoctorPatients");

                    b.Navigation("DoctorsList");

                    b.Navigation("MedicalRecord")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
