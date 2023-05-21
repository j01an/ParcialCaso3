using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ParcialCaso3.DOMAIN.Core.Entities;

namespace ParcialCaso3.DOMAIN.Infraestructure.Data;

public partial class Parcial202320100651Context : DbContext
{
    public Parcial202320100651Context()
    {
    }

    public Parcial202320100651Context(DbContextOptions<Parcial202320100651Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Player> Player { get; set; }

    public virtual DbSet<Team> Team { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=WS1602498;Database=Parcial202320100651;Integrated Security=true;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Player>(entity =>
        {
            entity.Property(e => e.DateOfBirth).HasMaxLength(50);
            entity.Property(e => e.FullName).HasMaxLength(100);
        });

        modelBuilder.Entity<Team>(entity =>
        {
            entity.Property(e => e.Country)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("country");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
