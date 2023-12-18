using System.Configuration;

using Microsoft.EntityFrameworkCore;
using ConnectingDBToApp.Models;


namespace ConnectingDBToApp.MyDbContext;

public partial class DataContext : DbContext
{
    public DataContext() { }

    public DataContext(DbContextOptions<DataContext> options) : base(options) { }

    // Объект таблицы SQLiteElements
    public virtual DbSet<SQLiteElement> SQLiteElements { get; set; }

    // Объект таблицы SSMSElements
    public virtual DbSet<SSMSElement> SSMSElements { get; set; }

    // Объект таблицы TestQuestions
    public virtual DbSet<TestQuestion> TestQuestions { get; set; }

    // Объект таблицы TestResults
    public virtual DbSet<TestResult> TestResults { get; set; }

    // Конфигурация подключения базы данных
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    // Настройка свойств для столбцов (полей) таблиц
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
