﻿// <auto-generated />
using LHDAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace LHDAL.Migrations
{
    [DbContext(typeof(LHDbContext))]
    [Migration("20180920162335_InitialCreateStartUp2")]
    partial class InitialCreateStartUp2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.3-rtm-32065")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("LHBOL.Category", b =>
                {
                    b.Property<int>("CategoryId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName");

                    b.Property<string>("Description");

                    b.HasKey("CategoryId");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("LHBOL.LHUrl", b =>
                {
                    b.Property<int>("UrlId")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryId");

                    b.Property<string>("Description");

                    b.Property<string>("Id");

                    b.Property<bool>("IsApproved");

                    b.Property<string>("LHUrlName");

                    b.Property<string>("UrlTitle");

                    b.HasKey("UrlId");

                    b.HasIndex("CategoryId");

                    b.HasIndex("Id");

                    b.ToTable("LHUrl");
                });

            modelBuilder.Entity("LHBOL.LHUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Password");

                    b.Property<string>("UserEmail");

                    b.HasKey("Id");

                    b.ToTable("LHUser");
                });

            modelBuilder.Entity("LHBOL.LHUrl", b =>
                {
                    b.HasOne("LHBOL.Category", "Category")
                        .WithMany("LHUrl")
                        .HasForeignKey("CategoryId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("LHBOL.LHUser", "User")
                        .WithMany("LHUrl")
                        .HasForeignKey("Id");
                });
#pragma warning restore 612, 618
        }
    }
}
