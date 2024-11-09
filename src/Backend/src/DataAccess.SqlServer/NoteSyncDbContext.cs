using System;
using System.Collections.Generic;
using DataAccess.SqlServer.Models;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.SqlServer;

public partial class NoteSyncDbContext : DbContext
{
    public NoteSyncDbContext(DbContextOptions<NoteSyncDbContext> options)
         : base(options)
    {
    }
    public virtual DbSet<Folder> Folders { get; set; }

    public virtual DbSet<FolderTag> FolderTags { get; set; }

    public virtual DbSet<Membership> Memberships { get; set; }

    public virtual DbSet<Page> Pages { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Folder>(entity =>
        {
            entity.HasKey(e => e.FolderId).HasName("PK__Folder__ACD7107F32B9D4BA");

            entity.ToTable("Folder", tb => tb.HasTrigger("trg_InsertFolder"));

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.FolderName)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.LastModifiedDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.User).WithMany(p => p.Folders)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userid_fk");
        });

        modelBuilder.Entity<FolderTag>(entity =>
        {
            entity.HasKey(e => e.FolderTagId).HasName("PK__FolderTa__113E4E7FAE3A0162");

            entity.ToTable("FolderTag");

            entity.HasOne(d => d.Folder).WithMany(p => p.FolderTags)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("folderid_fk");

            entity.HasOne(d => d.Tag).WithMany(p => p.FolderTags)
                .HasForeignKey(d => d.TagId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("tagid_fk");
        });

        modelBuilder.Entity<Membership>(entity =>
        {
            entity.HasKey(e => e.MembershipId).HasName("PK__Membersh__92A786798756BF28");

            entity.ToTable("Membership");

            entity.Property(e => e.MembershipId).ValueGeneratedOnAdd();
            entity.Property(e => e.MembershipName)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Price).HasColumnType("money");
        });

        modelBuilder.Entity<Page>(entity =>
        {
            entity.HasKey(e => e.PageId).HasName("PK__Page__C565B104FDC638FD");

            entity.ToTable("Page");

            entity.Property(e => e.Content).IsUnicode(false);
            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Title)
                .HasMaxLength(45)
                .IsUnicode(false);

            entity.HasOne(d => d.Folder).WithMany(p => p.Pages)
                .HasForeignKey(d => d.FolderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("folderid2_fk");
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tag__657CF9ACCA6BBBE6");

            entity.ToTable("Tag");

            entity.Property(e => e.Color)
                .HasMaxLength(7)
                .IsUnicode(false);
            entity.Property(e => e.TagContent).HasMaxLength(20);

            entity.HasOne(d => d.User).WithMany(p => p.Tags)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("userid2_fk");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CC4CC1982303");

            entity.ToTable("User", tb => tb.HasTrigger("trg_InsertUser"));

            entity.HasIndex(e => e.Email, "UQ__User__A9D105340A3BE14C").IsUnique();

            entity.Property(e => e.CreatedAt)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.MembershipId).HasDefaultValue((byte)1);
            entity.Property(e => e.Nickname).HasMaxLength(15);
            entity.Property(e => e.ProfilePictureUrl).HasMaxLength(255);

            entity.HasOne(d => d.Membership).WithMany(p => p.Users)
                .HasForeignKey(d => d.MembershipId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("user_plan_fk");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
