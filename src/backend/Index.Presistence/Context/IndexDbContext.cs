using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Index.Presistence.Context;

public class IndexDbContext(DbContextOptions<IndexDbContext> options) : IdentityDbContext<UserProfile>(options)
{
    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<ReportCard> ReportCards { get; set; }
    public virtual DbSet<ReportCardSubject> ReportCardSubjects { get; set; }
    public virtual DbSet<AssignmentGroup> AssignmentGroups { get; set; }
    public virtual DbSet<Assignment> Assignments { get; set; }
    public virtual DbSet<StudyPlan> StudyPlans { get; set; }
    public virtual DbSet<StudyPlanRestriction> StudyPlanRestrictions { get; set; }
    public virtual DbSet<StudyPlanSubject> StudyPlanSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Identity
        base.OnModelCreating(modelBuilder);

        // Dataseeding
        SubjectSeed.LookupData(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndexDbContext).Assembly);
    }
}