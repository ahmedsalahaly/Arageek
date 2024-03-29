﻿// <auto-generated />
using System;
using Arageek;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Arageek.Migrations
{
    [DbContext(typeof(ArageekDbContext))]
    [Migration("20220312103746_mainObj")]
    partial class mainObj
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Arageek.Models.Artical", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Body")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("autherId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("autherId");

                    b.ToTable("articals");
                });

            modelBuilder.Entity("Arageek.Models.Categories.MainCategorey", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<int>("articalId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("articalId");

                    b.ToTable("mainCategoreys");
                });

            modelBuilder.Entity("Arageek.Models.Users.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("userRoles");
                });

            modelBuilder.Entity("Arageek.Parent.Humen", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<DateTime>("BirthDay")
                        .HasColumnType("datetime2");

                    b.Property<int?>("CreatedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreatedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Discriminator")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("LastModifiedBy")
                        .HasColumnType("int");

                    b.Property<DateTime>("LastModifiedDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("humens");

                    b.HasDiscriminator<string>("Discriminator").HasValue("Humen");
                });

            modelBuilder.Entity("Arageek.Models.Auther", b =>
                {
                    b.HasBaseType("Arageek.Parent.Humen");

                    b.Property<string>("Bio")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasDiscriminator().HasValue("Auther");
                });

            modelBuilder.Entity("Arageek.Models.User", b =>
                {
                    b.HasBaseType("Arageek.Parent.Humen");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("UserRoleId")
                        .HasColumnType("int");

                    b.HasIndex("UserRoleId");

                    b.HasDiscriminator().HasValue("User");
                });

            modelBuilder.Entity("Arageek.Models.Artical", b =>
                {
                    b.HasOne("Arageek.Models.Auther", "auther")
                        .WithMany("articals")
                        .HasForeignKey("autherId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("auther");
                });

            modelBuilder.Entity("Arageek.Models.Categories.MainCategorey", b =>
                {
                    b.HasOne("Arageek.Models.Artical", "artical")
                        .WithMany("mainCategoreys")
                        .HasForeignKey("articalId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("artical");
                });

            modelBuilder.Entity("Arageek.Models.User", b =>
                {
                    b.HasOne("Arageek.Models.Users.UserRole", null)
                        .WithMany("users")
                        .HasForeignKey("UserRoleId");
                });

            modelBuilder.Entity("Arageek.Models.Artical", b =>
                {
                    b.Navigation("mainCategoreys");
                });

            modelBuilder.Entity("Arageek.Models.Users.UserRole", b =>
                {
                    b.Navigation("users");
                });

            modelBuilder.Entity("Arageek.Models.Auther", b =>
                {
                    b.Navigation("articals");
                });
#pragma warning restore 612, 618
        }
    }
}
