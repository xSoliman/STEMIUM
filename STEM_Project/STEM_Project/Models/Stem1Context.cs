#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace STEM_Project.Models;

public partial class Stem1Context : DbContext
{
    public Stem1Context(DbContextOptions<Stem1Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Feedback> Feedbacks { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Feedback>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Feedback__3214EC079C8FCA39");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.HasOne(d => d.User).WithMany(p => p.Feedbacks).HasConstraintName("FK__Feedback__User_I__3F466844");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07086BC40A");

            entity.Property(e => e.Id).ValueGeneratedNever();
        });
        modelBuilder.Entity<User>().HasData(
      new User
      {
          Email = "admin@admin.com",
          Password = "admin",
          Name = "Admin",
          Age = 21,
          EducationalLevel = "University",
          Type = "Admin"
      });
        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}