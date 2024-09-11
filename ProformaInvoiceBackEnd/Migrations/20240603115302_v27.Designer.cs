﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProformaInvoiceBackEnd.Models;

#nullable disable

namespace ProformaInvoiceBackEnd.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240603115302_v27")]
    partial class v27
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.Departement", b =>
                {
                    b.Property<int>("Id_departement")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_departement"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("manager")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_departement");

                    b.ToTable("departement");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.PlantDepartement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_departement")
                        .HasColumnType("int");

                    b.Property<int>("Id_plant")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_departement");

                    b.HasIndex("Id_plant");

                    b.ToTable("PlantDepartement");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.User", b =>
                {
                    b.Property<int>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("UserId"));

                    b.Property<int>("BackUp")
                        .HasColumnType("int");

                    b.Property<int>("DepartementId")
                        .HasColumnType("int");

                    b.Property<string>("Pwd")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Role")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("TeId")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("nPlus1")
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("DepartementId");

                    b.ToTable("user");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.UserPlant", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("Id_plant")
                        .HasColumnType("int");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Id_plant");

                    b.HasIndex("UserId");

                    b.ToTable("userplant");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.approverscenario", b =>
                {
                    b.Property<int>("id_approver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_approver"));

                    b.Property<int>("classe")
                        .HasColumnType("int");

                    b.Property<string>("role")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("scenarioId")
                        .HasColumnType("int");

                    b.HasKey("id_approver");

                    b.HasIndex("scenarioId");

                    b.ToTable("Approverscenario");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.plant", b =>
                {
                    b.Property<int>("Id_plant")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_plant"));

                    b.Property<string>("Building_id")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manager_plant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("businessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("plantNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_plant");

                    b.ToTable("plant");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request", b =>
                {
                    b.Property<int>("RequestNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("RequestNumber"));

                    b.Property<string>("DiliveryAddress")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoicesTypes")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Items")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ShippingPoint")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("incoterm")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("scenarioId")
                        .HasColumnType("int");

                    b.Property<int>("shipId")
                        .HasColumnType("int");

                    b.Property<int?>("shippointid_ship")
                        .HasColumnType("int");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("RequestNumber");

                    b.HasIndex("scenarioId");

                    b.HasIndex("shippointid_ship");

                    b.HasIndex("userId");

                    b.ToTable("request");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request_item", b =>
                {
                    b.Property<int>("Id_request_item")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_request_item"));

                    b.Property<string>("nameItem")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_request_item");

                    b.ToTable("requestsItem");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.scenario", b =>
                {
                    b.Property<int>("Id_scenario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_scenario"));

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_scenario");

                    b.ToTable("scenario");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.scenario_items_configuration", b =>
                {
                    b.Property<int>("Id_scenario")
                        .HasColumnType("int");

                    b.Property<int>("Id_request_item")
                        .HasColumnType("int");

                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("IsMandatory")
                        .HasColumnType("bit");

                    b.HasKey("Id_scenario", "Id_request_item");

                    b.HasIndex("Id_request_item");

                    b.ToTable("scenarioItemsConfiguration");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.shippoint", b =>
                {
                    b.Property<int>("id_ship")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_ship"));

                    b.Property<string>("FullAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("shipPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_ship");

                    b.ToTable("shippoint");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.PlantDepartement", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.Departement", "departement")
                        .WithMany("PlantDepartement")
                        .HasForeignKey("Id_departement")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProformaInvoiceBackEnd.Models.plant", "plant")
                        .WithMany("PlantDepartement")
                        .HasForeignKey("Id_plant")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("departement");

                    b.Navigation("plant");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.User", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.Departement", "Departement")
                        .WithMany()
                        .HasForeignKey("DepartementId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Departement");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.UserPlant", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.plant", "plant")
                        .WithMany("UserPlants")
                        .HasForeignKey("Id_plant")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("ProformaInvoiceBackEnd.Models.User", "user")
                        .WithMany("UserPlants")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("plant");

                    b.Navigation("user");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.approverscenario", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.scenario", "scenario")
                        .WithMany()
                        .HasForeignKey("scenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("scenario");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("scenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProformaInvoiceBackEnd.Models.shippoint", "shippoint")
                        .WithMany()
                        .HasForeignKey("shippointid_ship");

                    b.HasOne("ProformaInvoiceBackEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scenario");

                    b.Navigation("User");

                    b.Navigation("shippoint");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.scenario_items_configuration", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.request_item", "RequestItem")
                        .WithMany("scenarioItemsconfiguration")
                        .HasForeignKey("Id_request_item")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProformaInvoiceBackEnd.Models.scenario", "Scenario")
                        .WithMany("scenarioItemsconfiguration")
                        .HasForeignKey("Id_scenario")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("RequestItem");

                    b.Navigation("Scenario");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.Departement", b =>
                {
                    b.Navigation("PlantDepartement");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.User", b =>
                {
                    b.Navigation("UserPlants");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.plant", b =>
                {
                    b.Navigation("PlantDepartement");

                    b.Navigation("UserPlants");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request_item", b =>
                {
                    b.Navigation("scenarioItemsconfiguration");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.scenario", b =>
                {
                    b.Navigation("scenarioItemsconfiguration");
                });
#pragma warning restore 612, 618
        }
    }
}
