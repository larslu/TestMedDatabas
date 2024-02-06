using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace TestMedDatabas.Models;

public partial class FilmerContext : DbContext
{
    public FilmerContext()
    {
    }

    public FilmerContext(DbContextOptions<FilmerContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Film> Films { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlite("DefaultDbString");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Film>(entity =>
        {
            entity.ToTable("Film");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
