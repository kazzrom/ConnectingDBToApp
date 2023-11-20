using System.Configuration;

using Microsoft.EntityFrameworkCore;
using ConnectingDBToApp.Models;


namespace ConnectingDBToApp.MyDbContext;

public partial class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    public virtual DbSet<SQLiteElement> SQLiteElements { get; set; }

    public virtual DbSet<SSMSElement> SSMSElements { get; set; }

    public virtual DbSet<TestQuestion> TestQuestions { get; set; }

    public virtual DbSet<TestResult> TestResults { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SQLiteElement>(entity =>
        {
            entity.ToTable("SQLiteElements");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ObjectType).HasDefaultValueSql("'PlainText'");
        });

        modelBuilder.Entity<SSMSElement>(entity =>
        {
            entity.ToTable("SSMSElements");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.ObjectType).HasDefaultValueSql("'PlainText'");
        });

        modelBuilder.Entity<TestQuestion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TestResult>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
