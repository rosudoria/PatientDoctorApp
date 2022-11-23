using PatientDoctorApp.Areas.Identity.Data;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PatientDoctorApp.Models;

namespace PatientDoctorApp.Data;

public class PatientDoctorAppContext : IdentityDbContext<PatientDoctorAppUser>
{
    public PatientDoctorAppContext(DbContextOptions<PatientDoctorAppContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
        // Customize the ASP.NET Identity model and override the defaults if needed.
        // For example, you can rename the ASP.NET Identity table names and more.
        // Add your customizations after calling base.OnModelCreating(builder);

        builder.ApplyConfiguration(new DoctorPatientAppUserEntityConfiguration());
        builder.ApplyConfiguration(new DoctorPatientAppDocumentEntityConfiguration());
    }
}

public class DoctorPatientAppUserEntityConfiguration : IEntityTypeConfiguration<PatientDoctorAppUser>
{
    public void Configure(EntityTypeBuilder<PatientDoctorAppUser> builder)
    {
        builder.Property(u => u.FirstName).HasMaxLength(255);
        builder.Property(u => u.LastName).HasMaxLength(255);
    }
}

/// <summary>
/// This class is used to configure the mapping between the <see cref="PatientDoctorAppDocument"/> and the database.
/// </summary>
public class DoctorPatientAppDocumentEntityConfiguration : IEntityTypeConfiguration<Document>
{
    /// <summary>
    /// This method is used to configure the mapping between the <see cref="PatientDoctorAppDocument"/> and the database.
    /// </summary>
    /// <param name="builder"></param>
    public void Configure(EntityTypeBuilder<Document> builder)
    {
        builder.Property(d => d.DoctorId).HasMaxLength(255);
        builder.Property(d => d.AppointmentId).HasMaxLength(255);
        builder.Property(d => d.PatientId).HasMaxLength(255);
        builder.Property(d => d.Date).HasMaxLength(255);
        builder.Property(d => d.AppointmentId).HasMaxLength(255);
        builder.Property(d => d.Type).HasMaxLength(255);
        builder.Property(d => d.Note).HasMaxLength(255);
        builder.Property(d => d.ConditionStatus).HasMaxLength(255);
        builder.Property(d => d.Prescriptions).HasMaxLength(255);
        builder.Property(d => d.Remarks).HasMaxLength(255);
        builder.Property(d => d.FilePathTestReport).HasMaxLength(255);
        builder.Property(d => d.TestName).HasMaxLength(255);
        builder.Property(d => d.TestResult).HasMaxLength(255);
        builder.Property(d => d.TestDate).HasMaxLength(255);
    }
}
