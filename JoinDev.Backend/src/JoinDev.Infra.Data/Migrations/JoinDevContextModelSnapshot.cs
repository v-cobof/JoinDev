﻿// <auto-generated />
using System;
using JoinDev.Infra.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace JoinDev.Infra.Data.Migrations
{
    [DbContext(typeof(JoinDevContext))]
    partial class JoinDevContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.12")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("JoinDev.Domain.Entities.LinkSource", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("LinkSource", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.Project", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("CreatorId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("ProjectStatus")
                        .HasColumnType("int");

                    b.Property<string>("PublicDescription")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Title")
                        .HasColumnType("varchar(100)");

                    b.Property<int>("TotalSpots")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CreatorId");

                    b.ToTable("Projects", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.ProjectRestrictedInfo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId")
                        .IsUnique();

                    b.ToTable("ProjectsRestrictedInfo", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.Theme", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("ThemeCategoryId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("ThemeCategoryId");

                    b.ToTable("Themes", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.ThemeCategory", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.ToTable("ThemeCategory", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("varchar(500)");

                    b.Property<string>("Email")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Image")
                        .HasColumnType("varchar(100)");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Password")
                        .HasColumnType("varchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasFilter("[Email] IS NOT NULL");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.ValueObjects.Link", b =>
                {
                    b.Property<Guid>("AggregateId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Url")
                        .HasColumnType("varchar(100)");

                    b.Property<Guid>("LinkSourceId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("LinkType")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .HasColumnType("varchar(100)");

                    b.HasKey("AggregateId", "Url");

                    b.HasIndex("LinkSourceId");

                    b.ToTable("Links", (string)null);
                });

            modelBuilder.Entity("ProjectTheme", b =>
                {
                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ThemesId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ProjectsId", "ThemesId");

                    b.HasIndex("ThemesId");

                    b.ToTable("ProjectTheme");
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.Property<Guid>("MemberUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsAsMemberId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("MemberUsersId", "ProjectsAsMemberId");

                    b.HasIndex("ProjectsAsMemberId");

                    b.ToTable("MembersInProjects", (string)null);
                });

            modelBuilder.Entity("ProjectUser1", b =>
                {
                    b.Property<Guid>("InterestedUsersId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsAsInterestedId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("InterestedUsersId", "ProjectsAsInterestedId");

                    b.HasIndex("ProjectsAsInterestedId");

                    b.ToTable("InterestedInProjects", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.JobProject", b =>
                {
                    b.HasBaseType("JoinDev.Domain.Entities.Project");

                    b.Property<int>("JobProjectLevel")
                        .HasColumnType("int");

                    b.Property<decimal>("MemberPayment")
                        .HasColumnType("decimal(18,2)");

                    b.ToTable("JobProjects", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.StudyProject", b =>
                {
                    b.HasBaseType("JoinDev.Domain.Entities.Project");

                    b.Property<int>("StudyProjectLevel")
                        .HasColumnType("int");

                    b.ToTable("StudyProjects", (string)null);
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.Project", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.User", "Creator")
                        .WithMany("ProjectsAsCreator")
                        .HasForeignKey("CreatorId")
                        .IsRequired();

                    b.Navigation("Creator");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.ProjectRestrictedInfo", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.Project", "Project")
                        .WithOne("ProjectRestrictedInfo")
                        .HasForeignKey("JoinDev.Domain.Entities.ProjectRestrictedInfo", "ProjectId")
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.Theme", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.ThemeCategory", "ThemeCategory")
                        .WithMany("Themes")
                        .HasForeignKey("ThemeCategoryId")
                        .IsRequired();

                    b.Navigation("ThemeCategory");
                });

            modelBuilder.Entity("JoinDev.Domain.ValueObjects.Link", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.ProjectRestrictedInfo", null)
                        .WithMany("Links")
                        .HasForeignKey("AggregateId")
                        .IsRequired();

                    b.HasOne("JoinDev.Domain.Entities.User", null)
                        .WithMany("Links")
                        .HasForeignKey("AggregateId")
                        .IsRequired();

                    b.HasOne("JoinDev.Domain.Entities.LinkSource", "LinkSource")
                        .WithMany("Links")
                        .HasForeignKey("LinkSourceId")
                        .IsRequired();

                    b.Navigation("LinkSource");
                });

            modelBuilder.Entity("ProjectTheme", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .IsRequired();

                    b.HasOne("JoinDev.Domain.Entities.Theme", null)
                        .WithMany()
                        .HasForeignKey("ThemesId")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectUser", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("MemberUsersId")
                        .IsRequired();

                    b.HasOne("JoinDev.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsAsMemberId")
                        .IsRequired();
                });

            modelBuilder.Entity("ProjectUser1", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.User", null)
                        .WithMany()
                        .HasForeignKey("InterestedUsersId")
                        .IsRequired();

                    b.HasOne("JoinDev.Domain.Entities.Project", null)
                        .WithMany()
                        .HasForeignKey("ProjectsAsInterestedId")
                        .IsRequired();
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.JobProject", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.Project", null)
                        .WithOne()
                        .HasForeignKey("JoinDev.Domain.Entities.JobProject", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.StudyProject", b =>
                {
                    b.HasOne("JoinDev.Domain.Entities.Project", null)
                        .WithOne()
                        .HasForeignKey("JoinDev.Domain.Entities.StudyProject", "Id")
                        .OnDelete(DeleteBehavior.ClientCascade)
                        .IsRequired();
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.LinkSource", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.Project", b =>
                {
                    b.Navigation("ProjectRestrictedInfo");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.ProjectRestrictedInfo", b =>
                {
                    b.Navigation("Links");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.ThemeCategory", b =>
                {
                    b.Navigation("Themes");
                });

            modelBuilder.Entity("JoinDev.Domain.Entities.User", b =>
                {
                    b.Navigation("Links");

                    b.Navigation("ProjectsAsCreator");
                });
#pragma warning restore 612, 618
        }
    }
}
