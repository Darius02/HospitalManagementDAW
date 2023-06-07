using HospitalManagement.Models;
using Microsoft.EntityFrameworkCore;


namespace HospitalManagement.Data
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MedicalRecord> MedicalRecords { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                string connectionString = "data source=DESKTOP-4MPGUNO;initial catalog=HOSPITAL;Encrypt=False;trusted_connection=true";
                optionsBuilder.UseSqlServer(connectionString);
                //optionsBuilder.UseSqlServer("data source=DESKTOP-4MPGUNO;initial catalog=HOSPITAL;trusted_connection=true;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<DoctorPatients>()
                .HasKey(dp => new { dp.DoctorId, dp.PatientId });

            modelBuilder.Entity<DoctorPatients>()
                .HasOne(dp => dp.Doctor)
                .WithMany(d => d.DoctorPatients)
                .HasForeignKey(dp => dp.DoctorId);

            modelBuilder.Entity<DoctorPatients>()
                .HasOne(dp => dp.Patient)
                .WithMany(p => p.DoctorPatients)
                .HasForeignKey(dp => dp.PatientId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.PatientsList)
                .WithOne(p => p.Doctor)
                .HasForeignKey(p => p.DoctorId)
                .OnDelete(DeleteBehavior.Restrict);

            //modelBuilder.Entity<DoctorPatients>()
            //    .HasNoKey();

            // One to Many

            modelBuilder.Entity<DoctorDepartment>()
                .HasKey(dd => new { dd.DoctorId, dd.DepartmentId });

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(dd => dd.Doctor)
                .WithMany()
                .HasForeignKey(dd => dd.DoctorId);

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(dd => dd.Department)
                .WithMany()
                .HasForeignKey(dd => dd.DepartmentId);

            modelBuilder.Entity<Department>()
                .Ignore(d => d.DoctorsList);


            // Many to Many

            modelBuilder.Entity<DoctorDepartment>()
                .HasKey(dd => new { dd.DoctorId, dd.DepartmentId });

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(dd => dd.Doctor)
                .WithMany(d => d.DoctorDepartments)
                .HasForeignKey(dd => dd.DoctorId);

            modelBuilder.Entity<DoctorDepartment>()
                .HasOne(dd => dd.Department)
                .WithMany(d => d.DoctorDepartments)
                .HasForeignKey(dd => dd.DepartmentId);

            modelBuilder.Entity<Doctor>()
                .HasMany(d => d.DoctorDepartments)
                .WithOne()
                .HasForeignKey(dd => dd.DoctorId);

            modelBuilder.Entity<Department>()
                .HasMany(d => d.DoctorDepartments)
                .WithOne()
                .HasForeignKey(dd => dd.DepartmentId);



            //modelBuilder.Entity<Doctor>()
            //.HasMany(d => d.DepartmentsList)
            //.WithMany(d => d.DoctorsList)
            //.UsingEntity(join => join.ToTable("DoctorDepartment"));

            //modelBuilder.Entity<DoctorDepartment>()
            //   .HasNoKey();

            // One to One

            modelBuilder.Entity<Patient>()
                .HasOne(p => p.MedicalRecord)
                .WithOne(mr => mr.Patient)
                .HasForeignKey<MedicalRecord>(mr => mr.PatientId);
        }
    }
}