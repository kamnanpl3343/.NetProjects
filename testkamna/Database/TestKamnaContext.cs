using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace testkamna.Database;

public partial class TestKamnaContext : DbContext
{
    public TestKamnaContext()
    {
    }

    public TestKamnaContext(DbContextOptions<TestKamnaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Comment> Comments { get; set; }

    public virtual DbSet<FollowUp> FollowUps { get; set; }

    public virtual DbSet<Lead> Leads { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Server=DESKTOP-K2QSHIC\\EFOXSOLUTION;Database=TestKamna;user=sa;password=root@123;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Comment>(entity =>
        {
            entity.HasKey(e => e.CommentId).HasName("PK__comments__E7957687E5E478A0");

            entity.ToTable("comments");

            entity.Property(e => e.CommentId).HasColumnName("comment_id");
            entity.Property(e => e.CommentDate)
                .HasColumnType("date")
                .HasColumnName("comment_date");
            entity.Property(e => e.CommentText).HasColumnName("comment_text");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");

            entity.HasOne(d => d.Lead).WithMany(p => p.Comment)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("FK__comments__lead_i__29572725");
        });

        modelBuilder.Entity<FollowUp>(entity =>
        {
            entity.HasKey(e => e.FollowUpId).HasName("PK__follow_u__53C081440AAD83AF");

            entity.ToTable("follow_ups");

            entity.Property(e => e.FollowUpId).HasColumnName("follow_up_id");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate).HasColumnType("datetime");
            entity.Property(e => e.FollowUpDate)
                .HasColumnType("date")
                .HasColumnName("follow_up_date");
            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.Notes).HasColumnName("notes");

            entity.HasOne(d => d.Lead).WithMany(p => p.FollowUp)
                .HasForeignKey(d => d.LeadId)
                .HasConstraintName("FK__follow_up__lead___267ABA7A");
        });

        modelBuilder.Entity<Lead>(entity =>
        {
            entity.HasKey(e => e.LeadId).HasName("PK__leads__B54D340B0D19D03E");

            entity.ToTable("leads");

            entity.Property(e => e.LeadId).HasColumnName("lead_id");
            entity.Property(e => e.Address)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("address");
            entity.Property(e => e.CompanyName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("company_name");
            entity.Property(e => e.ContactName)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("contact_name");
            entity.Property(e => e.CreatedBy)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.CreatedDate)
                .HasColumnType("date")
                .HasColumnName("created_date");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Flag)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("flag");
            entity.Property(e => e.Interest)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("interest");
            entity.Property(e => e.Location)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("location");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("phone");
            entity.Property(e => e.Remark).HasColumnName("remark");
            entity.Property(e => e.Status)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("status");
            entity.Property(e => e.UserAssignee)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("user_assignee");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
