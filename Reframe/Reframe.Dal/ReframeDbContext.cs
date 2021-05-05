using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Reframe.Dal.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Reframe.Dal
{
    public class ReframeDbContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public ReframeDbContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Subject> Subjects { get; set; }
        public virtual DbSet<Place> Places { get; set; }
        public virtual DbSet<Course> Courses { get; set; }
        public virtual DbSet<News> MoreNews { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Subject>(entity =>
            {
                entity.Property(e => e.Credit)
                    .IsRequired();

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");


                entity.HasOne(d => d.User)
                    .WithMany(p => p.Subjects)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Place>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Places)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);

            });

            modelBuilder.Entity<Course>(entity =>
            {
                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Time).IsRequired();

                entity.HasOne(d => d.Place)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.PlaceId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.Subject)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.SubjectId)
                    .OnDelete(DeleteBehavior.NoAction);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.Courses)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.NoAction);
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable("Users");
                entity.Property(e => e.Name).IsRequired().HasMaxLength(100);

            });
            modelBuilder.Entity<News>(entity =>
            {
                entity.Property(e => e.Description).IsRequired().HasMaxLength(200);
                entity.Property(e => e.CreationTime)
                    .IsRequired()
                    .HasDefaultValueSql("(getdate())");

            });


        }
    }
}
