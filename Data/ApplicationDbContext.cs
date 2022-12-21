using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using APIService.Models;

namespace APIService.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<User> Users { get; set; } = null!;
        public virtual DbSet<Userfile> Userfiles { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
                .HasCharSet("utf8mb4");

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("users");

                entity.HasIndex(e => e.Userid, "userid_UNIQUE")
                    .IsUnique();

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.Property(e => e.CreatedAt)
                    .HasColumnType("datetime")
                    .HasColumnName("createdAt");

                entity.Property(e => e.Email)
                    .HasMaxLength(45)
                    .HasColumnName("email");

                entity.Property(e => e.Password)
                    .HasMaxLength(45)
                    .HasColumnName("password");

                entity.Property(e => e.PhoneNo)
                    .HasMaxLength(45)
                    .HasColumnName("phone_no");

                entity.Property(e => e.Role)
                    .HasMaxLength(45)
                    .HasColumnName("role");

                entity.Property(e => e.Username)
                    .HasMaxLength(45)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Userfile>(entity =>
            {
                entity.HasKey(e => e.FileId)
                    .HasName("PRIMARY");

                entity.ToTable("userfiles");

                entity.HasIndex(e => e.FileId, "fileId_UNIQUE")
                    .IsUnique();

                entity.HasIndex(e => e.Userid, "userid_idx");

                entity.Property(e => e.FileId).HasColumnName("fileId");

                entity.Property(e => e.AccessRole)
                    .HasMaxLength(45)
                    .HasColumnName("access_role");

                entity.Property(e => e.CreatedAt)
                    .HasMaxLength(45)
                    .HasColumnName("created_at");

                entity.Property(e => e.FileData)
                    .HasMaxLength(45)
                    .HasColumnName("file_data");

                entity.Property(e => e.Filename)
                    .HasMaxLength(45)
                    .HasColumnName("filename");

                entity.Property(e => e.LastModified)
                    .HasMaxLength(45)
                    .HasColumnName("last_modified");

                entity.Property(e => e.Size)
                    .HasMaxLength(45)
                    .HasColumnName("size");

                entity.Property(e => e.Type)
                    .HasMaxLength(45)
                    .HasColumnName("type");

                entity.Property(e => e.Userid).HasColumnName("userid");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Userfiles)
                    .HasForeignKey(d => d.Userid)
                    .HasConstraintName("userid");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
