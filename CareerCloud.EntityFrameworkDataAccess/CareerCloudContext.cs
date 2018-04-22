using CareerCloud.Pocos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CareerCloud.EntityFrameworkDataAccess
{
    public class CareerCloudContext : DbContext
    {
        public CareerCloudContext(bool createProxy=true) : base("connectionString")
        {
            Configuration.ProxyCreationEnabled = createProxy;
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {

            //modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            //Database.SetInitializer<CareerCloudContext>(null);
            //base.OnModelCreating(modelBuilder);

            //ApplicantEducationPoco
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantEducations)
                .WithRequired(e => e.ApplicantProfile)
                .HasForeignKey(l => l.Applicant)
                .WillCascadeOnDelete(false);


            //ApplicantJobApplicationPoco
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(j => j.ApplicantProfile)
                .HasForeignKey(l => l.Applicant);
            modelBuilder.Entity<CompanyJobPoco>()
                .HasMany(a => a.ApplicantJobApplications)
                .WithRequired(j => j.CompanyJob)
                .HasForeignKey(l => l.Job);


            //ApplicantProfilePoco
            modelBuilder.Entity<SecurityLoginPoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(j => j.SecurityLogin)
                .HasForeignKey(l => l.Login);
            modelBuilder.Entity<SystemCountryCodePoco>()
                .HasMany(a => a.ApplicantProfiles)
                .WithRequired(j => j.SystemCountryCode)
                .HasForeignKey(l => l.Country);
            

            //ApplicantResumePoco
            modelBuilder.Entity<ApplicantProfilePoco>()
                .HasMany(a => a.ApplicantResumes)
                .WithRequired(j => j.ApplicantProfile)
                .HasForeignKey(l => l.Applicant);


            //ApplicantSkillPoco
            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantSkills)
               .WithRequired(j => j.ApplicantProfile)
               .HasForeignKey(l => l.Applicant);


            //ApplicantWorkHistoryPoco
            modelBuilder.Entity<SystemCountryCodePoco>()
               .HasMany(a => a.ApplicantWorkHistories)
               .WithRequired(j => j.SystemCountryCode)
               .HasForeignKey(l => l.CountryCode);
            modelBuilder.Entity<ApplicantProfilePoco>()
               .HasMany(a => a.ApplicantWorkHistories)
               .WithRequired(j => j.ApplicantProfile)
               .HasForeignKey(l => l.Applicant);
            //modelBuilder.Entity<ApplicantProfilePoco>()
            //    .HasRequired(a => a.ApplicantWorkHistories)
            //    .WithMany()
            //    .WillCascadeOnDelete(false);


            //CompanyDescriptionPoco
            modelBuilder.Entity<CompanyProfilePoco>()
               .HasMany(a => a.CompanyDescriptions)
               .WithRequired(j => j.CompanyProfile)
               .HasForeignKey(l => l.Company);
            modelBuilder.Entity<SystemLanguageCodePoco>()
               .HasMany(a => a.CompanyDescriptions)
               .WithRequired(j => j.SystemLanguageCode)
               .HasForeignKey(l => l.LanguageId);


            //CompanyJobDescriptionPoco
            modelBuilder.Entity<CompanyJobPoco>()
               .HasMany(a => a.CompanyJobDescriptions)
               .WithRequired(j => j.CompanyJob)
               .HasForeignKey(l => l.Job);


            //CompanyJobEducationPoco
            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(a => a.CompanyJobEducations)
              .WithRequired(j => j.CompanyJob)
              .HasForeignKey(l => l.Job);


            //CompanyJobPoco
            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(a => a.CompanyJobs)
              .WithRequired(j => j.CompanyProfile)
              .HasForeignKey(l => l.Company);


            //CompanyJobSkillPoco
            modelBuilder.Entity<CompanyJobPoco>()
              .HasMany(a => a.CompanyJobSkills)
              .WithRequired(j => j.CompanyJob)
              .HasForeignKey(l => l.Job);


            //CompanyLocationPoco
            modelBuilder.Entity<CompanyProfilePoco>()
              .HasMany(a => a.CompanyLocations)
              .WithRequired(j => j.CompanyProfile)
              .HasForeignKey(l => l.Company);


            //SecurityLoginsLogPoco
            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(a => a.SecurityLoginsLogs)
              .WithRequired(j => j.SecurityLogin)
              .HasForeignKey(l => l.Login);


            //SecurityLoginsRolePoco
            modelBuilder.Entity<SecurityLoginPoco>()
              .HasMany(a => a.SecurityLoginsRoles)
              .WithRequired(j => j.SecurityLogin)
              .HasForeignKey(l => l.Login);
            modelBuilder.Entity<SecurityRolePoco>()
              .HasMany(a => a.SecurityLoginsRoles)
              .WithRequired(j => j.SecurityRole)
              .HasForeignKey(l => l.Role);

            base.OnModelCreating(modelBuilder);
        }
        DbSet<ApplicantEducationPoco> ApplicantEducations { get; set; }
        DbSet<ApplicantJobApplicationPoco> ApplicantJobApplications { get; set; }
        DbSet<ApplicantProfilePoco> ApplicantProfiles { get; set; }
        DbSet<ApplicantResumePoco> ApplicantResumes { get; set; }
        DbSet<ApplicantSkillPoco> ApplicantSkills { get; set; }
        DbSet<ApplicantWorkHistoryPoco> ApplicantWorkHistories { get; set; }
        DbSet<CompanyDescriptionPoco> CompanyDescriptions { get; set; }
        DbSet<CompanyJobDescriptionPoco> CompanyJobDescriptions { get; set; }
        DbSet<CompanyJobEducationPoco> CompanyJobEducations { get; set; }
        DbSet<CompanyJobPoco> CompanyJobs { get; set; }
        DbSet<CompanyJobSkillPoco> CompanyJobSkills { get; set; }
        DbSet<CompanyLocationPoco> CompanyLocations { get; set; }
        DbSet<CompanyProfilePoco> CompanyProfiles { get; set; }
        DbSet<SecurityLoginPoco> SecurityLogins { get; set; }
        DbSet<SecurityLoginsLogPoco> SecurityLoginsLogs { get; set; }
        DbSet<SecurityLoginsRolePoco> SecurityLoginsRoles { get; set; }
        DbSet<SecurityRolePoco> SecurityRoles { get; set; }
        DbSet<SystemCountryCodePoco> SystemCountryCodes { get; set; }
        DbSet<SystemLanguageCodePoco> SystemLanguageCodes { get; set; }

    }
}
