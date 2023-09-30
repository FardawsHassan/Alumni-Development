﻿// <auto-generated />
using System;
using Alumni.Web.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Alumni.Web.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.20")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Alumni.Web.Models.Activity", b =>
                {
                    b.Property<int>("ActivityId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Activity_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ActivityId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Published_Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("ActivityId");

                    b.ToTable("Activities");
                });

            modelBuilder.Entity("Alumni.Web.Models.Business", b =>
                {
                    b.Property<int>("BusinessId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Business_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BusinessId"), 1L, 1);

                    b.Property<string>("BusinessType")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("BusinessId");

                    b.HasIndex("ProfileId");

                    b.ToTable("Business");
                });

            modelBuilder.Entity("Alumni.Web.Models.Event", b =>
                {
                    b.Property<int>("EventId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Event_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("EventId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Published_Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("EventId");

                    b.ToTable("Events");
                });

            modelBuilder.Entity("Alumni.Web.Models.Freelance", b =>
                {
                    b.Property<int>("FreelanceId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Freelance_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("FreelanceId"), 1L, 1);

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<bool>("IsActive")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bit")
                        .HasDefaultValue(false);

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("WorkingFields")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)")
                        .HasColumnName("Working_Fields");

                    b.HasKey("FreelanceId");

                    b.HasIndex("ProfileId")
                        .IsUnique();

                    b.ToTable("Freelance");
                });

            modelBuilder.Entity("Alumni.Web.Models.GovtJob", b =>
                {
                    b.Property<int>("GovtJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("GovtJob_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GovtJobId"), 1L, 1);

                    b.Property<string>("Designation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("GovtJobId");

                    b.HasIndex("ProfileId");

                    b.ToTable("GovtJob");
                });

            modelBuilder.Entity("Alumni.Web.Models.Notice", b =>
                {
                    b.Property<int>("NoticeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Notice_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("NoticeId"), 1L, 1);

                    b.Property<string>("Description")
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)");

                    b.Property<DateTime>("PublishedDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Published_Date");

                    b.Property<string>("Title")
                        .IsRequired()
                        .ValueGeneratedOnAdd()
                        .HasColumnType("nvarchar(max)")
                        .HasDefaultValue("");

                    b.HasKey("NoticeId");

                    b.ToTable("Notices");
                });

            modelBuilder.Entity("Alumni.Web.Models.PhoneNumber", b =>
                {
                    b.Property<int>("PhoneId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Phone_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhoneId"), 1L, 1);

                    b.Property<string>("Phone_Number")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.HasKey("PhoneId");

                    b.HasIndex("ProfileId");

                    b.ToTable("PhoneNumbers");
                });

            modelBuilder.Entity("Alumni.Web.Models.Photo", b =>
                {
                    b.Property<int>("PhotoId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PhotoId"), 1L, 1);

                    b.Property<int>("ActivityId")
                        .HasColumnType("int")
                        .HasColumnName("Activity_ID");

                    b.Property<string>("Caption")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EventId")
                        .HasColumnType("int")
                        .HasColumnName("Event_ID");

                    b.Property<int>("NoticeId")
                        .HasColumnType("int")
                        .HasColumnName("Notice_ID");

                    b.Property<string>("PhotoPath")
                        .IsRequired()
                        .HasMaxLength(300)
                        .HasColumnType("nvarchar(300)")
                        .HasColumnName("Photo_Path");

                    b.Property<DateTime?>("UploadDate")
                        .HasColumnType("datetime2")
                        .HasColumnName("Upload_Date");

                    b.HasKey("PhotoId");

                    b.HasIndex("ActivityId");

                    b.HasIndex("EventId");

                    b.HasIndex("NoticeId");

                    b.ToTable("Photos");
                });

            modelBuilder.Entity("Alumni.Web.Models.PostGrad", b =>
                {
                    b.Property<int>("PostGradId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PostGrad_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PostGradId"), 1L, 1);

                    b.Property<string>("PostGradDegree")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("PostGradField")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<string>("PostGradUniversity")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.HasKey("PostGradId");

                    b.HasIndex("ProfileId");

                    b.ToTable("PostGrad");
                });

            modelBuilder.Entity("Alumni.Web.Models.PrivateJob", b =>
                {
                    b.Property<int>("PrivateJobId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PrivateJob_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PrivateJobId"), 1L, 1);

                    b.Property<string>("Designation")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Organization")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<int>("ProfileId")
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("PrivateJobId");

                    b.HasIndex("ProfileId");

                    b.ToTable("PrivateJob");
                });

            modelBuilder.Entity("Alumni.Web.Models.Profile", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Profile_ID");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Batches")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("CurrentAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FacebookUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)");

                    b.Property<string>("Gender")
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("GithubUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LinkedInUrl")
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NickName")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("PermanantAddress")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhotoPath")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("Roll")
                        .HasColumnType("int");

                    b.Property<int?>("Session")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)")
                        .HasColumnName("User_ID");

                    b.Property<bool?>("isApproved")
                        .HasColumnType("bit");

                    b.Property<bool?>("isCurrentStudent")
                        .HasColumnType("bit");

                    b.Property<bool?>("isRenowned")
                        .HasColumnType("bit");

                    b.Property<bool?>("isUnemployeed")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.ToTable("Profiles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderKey")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("LoginProvider")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Name")
                        .HasMaxLength(128)
                        .HasColumnType("nvarchar(128)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("Alumni.Web.Models.Business", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithMany("Businesses")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Alumni.Web.Models.Freelance", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithOne("Freelance")
                        .HasForeignKey("Alumni.Web.Models.Freelance", "ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Alumni.Web.Models.GovtJob", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithMany("GovtJobs")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Alumni.Web.Models.PhoneNumber", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithMany("PhoneNumbers")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Alumni.Web.Models.Photo", b =>
                {
                    b.HasOne("Alumni.Web.Models.Activity", "Activity")
                        .WithMany("Photos")
                        .HasForeignKey("ActivityId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni.Web.Models.Event", "Event")
                        .WithMany("Photos")
                        .HasForeignKey("EventId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Alumni.Web.Models.Notice", "Notice")
                        .WithMany("Photos")
                        .HasForeignKey("NoticeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Activity");

                    b.Navigation("Event");

                    b.Navigation("Notice");
                });

            modelBuilder.Entity("Alumni.Web.Models.PostGrad", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithMany("PostGrads")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Alumni.Web.Models.PrivateJob", b =>
                {
                    b.HasOne("Alumni.Web.Models.Profile", "Profile")
                        .WithMany("PrivateJobs")
                        .HasForeignKey("ProfileId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Profile");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Alumni.Web.Models.Activity", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Alumni.Web.Models.Event", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Alumni.Web.Models.Notice", b =>
                {
                    b.Navigation("Photos");
                });

            modelBuilder.Entity("Alumni.Web.Models.Profile", b =>
                {
                    b.Navigation("Businesses");

                    b.Navigation("Freelance");

                    b.Navigation("GovtJobs");

                    b.Navigation("PhoneNumbers");

                    b.Navigation("PostGrads");

                    b.Navigation("PrivateJobs");
                });
#pragma warning restore 612, 618
        }
    }
}
