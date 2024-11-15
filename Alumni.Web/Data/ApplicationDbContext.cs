﻿using Alumni.Web.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Activity = Alumni.Web.Models.Activity;

namespace Alumni.Web.Data
{
    public partial class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Profile>(entity =>
            {
                entity.Property(e => e.Id)
                .HasColumnName("Profile_ID");
                
                entity.Property(e => e.UserId)
                .HasColumnType("nvarchar(max)")
                .HasColumnName("User_ID")
                .IsRequired();

                entity.Property(e => e.FullName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NickName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasColumnType("nvarchar(20)")
                    .HasConversion(new EnumToStringConverter<Gender>()); ;
;
                entity.Property(e => e.isApproved)
                    .HasDefaultValue(false)
                    .IsRequired();

                entity.Property(p => p.BirthDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.PhotoPath)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .IsRequired();

                entity.Property(e => e.GithubUrl)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(100);

                entity.Property(e => e.LinkedInUrl)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(100);

                entity.Property(e => e.FacebookUrl)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(100);

                entity.Property(e => e.CurrentAddress)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(200);

                entity.Property(e => e.PermanantAddress)
                    .HasColumnType("nvarchar(max)")
                    .HasMaxLength(200);

                OnModelCreatingPartial(modelBuilder);
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.HasKey(e => new { e.PhoneId});

                entity.Property(e => e.PhoneId)
                    .HasColumnName("Phone_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.Phone_Number)
                    .HasMaxLength(20)
                    .IsUnicode(false);


                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<PostGrad>(entity =>
            {
                entity.HasKey(e => new { e.PostGradId});

                entity.Property(e => e.PostGradId)
                    .HasColumnName("PostGrad_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.PostGradDegree)
                    .HasMaxLength(50)
                    .IsUnicode(false);
                
                entity.Property(e => e.PostGradUniversity)
                    .HasMaxLength(100)
                    .IsUnicode(false);
                
                entity.Property(e => e.PostGradField)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Business>(entity =>
            {
                entity.HasKey(e => new { e.BusinessId });

                entity.Property(e => e.BusinessId)
                    .HasColumnName("Business_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime2");
                
                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.BusinessType)
                    .HasMaxLength(100);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<GovtJob>(entity =>
            {
                entity.HasKey(e => new { e.GovtJobId });
                
                entity.Property(e => e.GovtJobId)
                    .HasColumnName("GovtJob_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime2");
                
                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.Organization)
                    .IsUnicode(false)
                    .HasMaxLength(100);
                    
                entity.Property(e => e.Designation)
                    .IsUnicode(false)
                    .HasMaxLength(100);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<PrivateJob>(entity =>
            {
                entity.HasKey(e => new { e.PrivateJobId });
                
                entity.Property(e => e.PrivateJobId)
                    .HasColumnName("PrivateJob_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime2");
                
                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.Organization)
                    .IsUnicode(false)
                    .HasMaxLength(100);
                    
                entity.Property(e => e.Designation)
                    .IsUnicode(false)
                    .HasMaxLength(100);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Freelance>(entity =>
            {
                entity.HasKey(e => new { e.FreelanceId });
                
                entity.Property(e => e.FreelanceId)
                    .HasColumnName("Freelance_ID");

                entity.Property(e => e.ProfileId)
                    .HasColumnName("Profile_ID")
                    .IsRequired();

                entity.Property(e => e.IsActive)
                    .HasDefaultValue(false)
                    .IsRequired();

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime2");
                
                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime2");

                entity.Property(e => e.WorkingFields)
                    .HasColumnName("Working_Fields")
                    .IsUnicode(false)
                    .HasMaxLength(100);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Event>(entity =>
            {
                entity.HasKey(e => new { e.EventId });
                
                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID");

                entity.Property(e => e.Title)
                    .HasDefaultValue("")
                    .IsRequired();

                entity.Property(e => e.PublishedDate)
                    .HasColumnName("Published_Date")
                    .HasColumnType("datetime2")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(300);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Models.Activity>(entity =>
            {
                entity.HasKey(e => new { e.ActivityId });
                
                entity.Property(e => e.ActivityId)
                    .HasColumnName("Activity_ID");

                entity.Property(e => e.Title)
                    .HasDefaultValue("")
                    .IsRequired();

                entity.Property(e => e.PublishedDate)
                    .HasColumnName("Published_Date")
                    .HasColumnType("datetime2")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(300);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Notice>(entity =>
            {
                entity.HasKey(e => new { e.NoticeId });
                
                entity.Property(e => e.NoticeId)
                    .HasColumnName("Notice_ID");

                entity.Property(e => e.Title)
                    .HasDefaultValue("")
                    .IsRequired();

                entity.Property(e => e.PublishedDate)
                    .HasColumnName("Published_Date")
                    .HasColumnType("datetime2")
                    .IsRequired();

                entity.Property(e => e.Description)
                    .HasMaxLength(300);

                OnModelCreatingPartial(modelBuilder);
            });
            
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.HasKey(e => new { e.PhotoId });
                
                entity.Property(e => e.EventId)
                    .HasColumnName("Event_ID");
                
                entity.Property(e => e.NoticeId)
                    .HasColumnName("Notice_ID");
                
                entity.Property(e => e.ActivityId)
                    .HasColumnName("Activity_ID");

                entity.Property(e => e.Caption);

                entity.Property(e => e.UploadDate)
                    .HasColumnName("Upload_Date")
                    .HasColumnType("datetime2");

                entity.Property(e => e.PhotoPath)
                    .HasColumnName("Photo_Path")
                    .HasMaxLength(300)
                    .IsRequired();

                OnModelCreatingPartial(modelBuilder);
            });

            modelBuilder.Entity<PhoneNumber>()
                .HasOne(p => p.Profile)
                .WithMany(pn => pn.PhoneNumbers)
                .HasForeignKey(pn => pn.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PostGrad>()
                .HasOne(p => p.Profile)
                .WithMany(pn => pn.PostGrads)
                .HasForeignKey(pn => pn.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<Business>()
                .HasOne(p => p.Profile)
                .WithMany(pn => pn.Businesses)
                .HasForeignKey(pn => pn.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<GovtJob>()
                .HasOne(p => p.Profile)
                .WithMany(pn => pn.GovtJobs)
                .HasForeignKey(pn => pn.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);
            
            modelBuilder.Entity<PrivateJob>()
                .HasOne(p => p.Profile)
                .WithMany(pn => pn.PrivateJobs)
                .HasForeignKey(pn => pn.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Freelance>()
                .HasOne(p => p.Profile)
                .WithOne(pn => pn.Freelance)
                .HasForeignKey<Freelance>(f => f.ProfileId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Photo>()
             .HasOne(p => p.Event)
             .WithOne(pn => pn.Photo)
             .HasForeignKey<Event>(f => f.EventId)
             .OnDelete(DeleteBehavior.Cascade);


            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Activity)
                .WithOne(pn => pn.Photo)
                .HasForeignKey<Activity>(f => f.ActivityId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Photo>()
                .HasOne(p => p.Notice)
                .WithOne(pn => pn.Photo)
                .HasForeignKey<Notice>(f => f.NoticeId)
                .OnDelete(DeleteBehavior.Cascade);

            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Profile> Profiles { get; set; }
        public DbSet<PhoneNumber> PhoneNumbers { get; set; }
        public DbSet<Models.Activity> Activities { get; set; }
        public DbSet<Notice> Notices { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Photo> Photos { get; set; }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}