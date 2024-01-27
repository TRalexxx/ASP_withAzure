using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ASP_Db_4._10;

public partial class Test2DbContext : DbContext
{
    public Test2DbContext()
    {
    }

    public Test2DbContext(DbContextOptions<Test2DbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<User> Users { get; set; }


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(x=>x.Id);

            entity.Property(e => e.FirstName)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Id).ValueGeneratedOnAdd();
            entity.Property(e => e.LastName)
                .HasMaxLength(60)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}