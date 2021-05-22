﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProfileDetailsAssessment.Models;

namespace ProfileDetailsAssessment.Migrations
{
    [DbContext(typeof(ProfileContext))]
    [Migration("20210521110139_myNewMig")]
    partial class myNewMig
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.6")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("ProfileDetailsAssessment.Models.Profile", b =>
                {
                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<string>("CurrentCTC")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmployed")
                        .HasColumnType("bit");

                    b.Property<string>("NoticePeriod")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Qualification")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Name");

                    b.ToTable("Profiles");
                });
#pragma warning restore 612, 618
        }
    }
}