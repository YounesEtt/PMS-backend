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
    [Migration("20240510083958_v12")]
    partial class v12
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

                    b.Property<int>("plantId")
                        .HasColumnType("int");

                    b.HasKey("Id_departement");

                    b.HasIndex("plantId");

                    b.ToTable("departement");
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

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.approver", b =>
                {
                    b.Property<int>("id_approver")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id_approver"));

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("UserId")
                        .HasColumnType("int");

                    b.Property<string>("comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id_approver");

                    b.ToTable("approver");
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

                    b.HasKey("Id_plant");

                    b.ToTable("plant");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request", b =>
                {
                    b.Property<int>("Id_request")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id_request"));

                    b.Property<string>("BusinessUnit")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Cost_Center")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DHL_Account")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DiliveryAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("InvoicesTypes")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("PN")
                        .HasColumnType("int");

                    b.Property<string>("Plant")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<float>("Price")
                        .HasColumnType("real");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.Property<int>("RequestNumber")
                        .HasColumnType("int");

                    b.Property<string>("ShippingPoint")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UnitOfQuantity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("created_at")
                        .HasColumnType("datetime2");

                    b.Property<string>("incoterm")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("scenarioId")
                        .HasColumnType("int");

                    b.Property<string>("scenarioName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("userId")
                        .HasColumnType("int");

                    b.HasKey("Id_request");

                    b.HasIndex("scenarioId");

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

                    b.Property<int>("approverId")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id_scenario");

                    b.HasIndex("approverId");

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

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.Departement", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.plant", "plant")
                        .WithMany()
                        .HasForeignKey("plantId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

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

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.request", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.scenario", "Scenario")
                        .WithMany()
                        .HasForeignKey("scenarioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ProformaInvoiceBackEnd.Models.User", "User")
                        .WithMany()
                        .HasForeignKey("userId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Scenario");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ProformaInvoiceBackEnd.Models.scenario", b =>
                {
                    b.HasOne("ProformaInvoiceBackEnd.Models.approver", "approver")
                        .WithMany()
                        .HasForeignKey("approverId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("approver");
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
