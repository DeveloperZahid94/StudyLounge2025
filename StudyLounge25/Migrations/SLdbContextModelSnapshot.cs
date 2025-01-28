﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StudyLounge25.Data;

#nullable disable

namespace StudyLounge25.Migrations
{
    [DbContext(typeof(SLdbContext))]
    partial class SLdbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StudyLounge25.DomainModels.AdminLogModal", b =>
                {
                    b.Property<Guid>("LogId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Action")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("AdminId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Timestamp")
                        .HasColumnType("datetime2");

                    b.HasKey("LogId");

                    b.ToTable("AdminLogs");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinAssignmentModal", b =>
                {
                    b.Property<Guid>("AssignmentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("AssignmentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("CabinId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime?>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("AssignmentId");

                    b.HasIndex("CabinId");

                    b.HasIndex("StudentId");

                    b.ToTable("CabinAssignments");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinModal", b =>
                {
                    b.Property<Guid>("CabinId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CabinName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("HasAc")
                        .HasColumnType("bit");

                    b.Property<bool?>("HasWifi")
                        .HasColumnType("bit");

                    b.Property<bool?>("IsAvailable")
                        .HasColumnType("bit");

                    b.Property<decimal?>("PricePerDay")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("CabinId");

                    b.ToTable("Cabins");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinSpecificationModal", b =>
                {
                    b.Property<Guid>("SpecificationId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("CabinId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SpecificationType")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("SpecificationId");

                    b.HasIndex("CabinId");

                    b.ToTable("CabinSpecifications");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.FeeModal", b =>
                {
                    b.Property<Guid>("FeeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal?>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("PaymentDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("PaymentStatus")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("StudentId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("FeeId");

                    b.HasIndex("StudentId");

                    b.ToTable("Fees");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.StudentModal", b =>
                {
                    b.Property<Guid>("StudentId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("DateOfBirth")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool?>("IsDisabled")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("RegistrationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StudentId");

                    b.ToTable("Students");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinAssignmentModal", b =>
                {
                    b.HasOne("StudyLounge25.DomainModels.CabinModal", "Cabin")
                        .WithMany("CabinAssignments")
                        .HasForeignKey("CabinId");

                    b.HasOne("StudyLounge25.DomainModels.StudentModal", "Student")
                        .WithMany("CabinAssignments")
                        .HasForeignKey("StudentId");

                    b.Navigation("Cabin");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinSpecificationModal", b =>
                {
                    b.HasOne("StudyLounge25.DomainModels.CabinModal", "Cabin")
                        .WithMany("CabinSpecifications")
                        .HasForeignKey("CabinId");

                    b.Navigation("Cabin");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.FeeModal", b =>
                {
                    b.HasOne("StudyLounge25.DomainModels.StudentModal", "Student")
                        .WithMany("Fees")
                        .HasForeignKey("StudentId");

                    b.Navigation("Student");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.CabinModal", b =>
                {
                    b.Navigation("CabinAssignments");

                    b.Navigation("CabinSpecifications");
                });

            modelBuilder.Entity("StudyLounge25.DomainModels.StudentModal", b =>
                {
                    b.Navigation("CabinAssignments");

                    b.Navigation("Fees");
                });
#pragma warning restore 612, 618
        }
    }
}
