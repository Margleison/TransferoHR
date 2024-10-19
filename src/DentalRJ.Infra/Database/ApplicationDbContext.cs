using DentalRJ.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DentalRJ.Infra.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // Defina suas DbSets aqui
        public DbSet<Company> Company { get; set; }
        public DbSet<Clinic> Clinic { get; set; }
        public DbSet<DentalInsurance> DentalInsurance { get; set; }
        public DbSet<Dentist> Dentist { get; set; }
        public DbSet<Dentistry> Dentistry { get; set; }
        public DbSet<Patient> Patient { get; set; }
        public DbSet<DentalInsuranceDentistry> DentalInsuranceDentistry { get; set; }
        public DbSet<ClinicDentalInsurance> ClinicDentalInsurance { get; set; }
        public DbSet<DentistDentistry> DentistDentistry { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ClinicDentalInsurance>(entity =>
            {
                entity.HasKey(e => new { e.ClinicId, e.DentalInsuranceId });

                entity.HasOne(e => e.Clinic)
                      .WithMany(c => c.ClinicDentalInsurances)
                      .HasForeignKey(e => e.ClinicId);

                entity.HasOne(e => e.DentalInsurance)
                      .WithMany(i => i.ClinicDentalInsurances)
                      .HasForeignKey(e => e.DentalInsuranceId);
            });

            modelBuilder.Entity<DentalInsuranceDentistry>(entity =>
            {
                entity.HasKey(e => new { e.DentalInsuranceId, e.DentistryId });

                entity.HasOne(e => e.DentalInsurance)
                      .WithMany(d => d.DentalInsuranceDentistries)
                      .HasForeignKey(e => e.DentalInsuranceId);

                entity.HasOne(e => e.Dentistry)
                      .WithMany(d => d.DentalInsuranceDentistries)
                      .HasForeignKey(e => e.DentistryId);
            });

            modelBuilder.Entity<DentistDentistry>(entity =>
            {
                entity.HasKey(e => new { e.DentistId, e.DentistryId });

                entity.HasOne(e => e.Dentist)
                      .WithMany(d => d.DentistDentistries)
                      .HasForeignKey(e => e.DentistId);

                entity.HasOne(e => e.Dentistry)
                      .WithMany(d => d.DentistDentistries)
                      .HasForeignKey(e => e.DentistryId);
            });
        }
    }
}