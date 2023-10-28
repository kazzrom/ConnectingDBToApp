using System;
using System.Collections.Generic;
using System.Configuration;
using ConnectingDBToApp.Models;
using Microsoft.EntityFrameworkCore;

namespace ConnectingDBToApp.MyDbContext;

public partial class DataContext : DbContext
{
    public DataContext()
    {
    }

    public DataContext(DbContextOptions<DataContext> options)
        : base(options)
    {
    }

    public virtual DbSet<SqliteElement> SqliteElements { get; set; }

    public virtual DbSet<SsmsElement> Ssmselements { get; set; }

    public virtual DbSet<TestQuestion> TestQuestions { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite(ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<SqliteElement>(entity =>
        {
            entity.ToTable("SQLiteElements");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<SsmsElement>(entity =>
        {
            entity.ToTable("SSMSElements");

            entity.Property(e => e.Id).HasColumnName("ID");
        });

        modelBuilder.Entity<TestQuestion>(entity =>
        {
            entity.Property(e => e.Id).HasColumnName("ID");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
