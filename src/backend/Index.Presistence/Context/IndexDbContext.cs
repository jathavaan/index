namespace Index.Presistence.Context;

public partial class IndexDbContext(DbContextOptions<IndexDbContext> options) : DbContext(options)
{
    public virtual DbSet<UserProfile> UserProfiles { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }
    public virtual DbSet<ReportCard> ReportCards { get; set; }
    public virtual DbSet<ReportCardSubject> ReportCardSubjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Dataseeding
        SubjectSeed.LookupData(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(typeof(IndexDbContext).Assembly);
    }
}