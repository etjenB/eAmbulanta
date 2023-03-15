﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using eAmbulantaWebApp.Data;

#nullable disable

namespace eAmbulantaWebApp.Migrations
{
    [DbContext(typeof(AuthenticationContext))]
    [Migration("20230314125024_pacijentIdToBolest")]
    partial class pacijentIdToBolest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

                    b.Property<string>("Discriminator")
                        .IsRequired()
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

                    b.HasDiscriminator<string>("Discriminator").HasValue("IdentityUser");

                    b.UseTphMappingStrategy();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

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

            modelBuilder.Entity("eAmbulantaWebApp.Models.Bolest", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ICDKod")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PacijentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("PacijentId");

                    b.ToTable("Bolest");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.JavnaNabavka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdministratorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("pdfFajl")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("JavnaNabavka");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Lijek", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("DoktorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Kolicina")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odgovor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Odobreno")
                        .HasColumnType("bit");

                    b.Property<string>("PacijentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Lijek");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Lokacija", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Adresa")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Latitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Longitude")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Lokacija");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.MedicinskiTretman", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime?>("DatumIVrijemeObavljanja")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("DatumIVrijemePropisa")
                        .HasColumnType("datetime2");

                    b.Property<string>("MedicinskaSestraTehnicarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Obavljen")
                        .HasColumnType("bit");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PacijentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MedicinskaSestraTehnicarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("MedicinskiTretman");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Novost", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdministratorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("Slika")
                        .HasColumnType("varbinary(max)");

                    b.Property<DateTime>("datumIVrijemeObjave")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Novost");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Odluka", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdministratorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Opis")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte[]>("pdfFajl")
                        .IsRequired()
                        .HasColumnType("varbinary(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Odluka");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Oglas", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AdministratorId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Sadrzaj")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("AdministratorId");

                    b.ToTable("Oglas");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Posjeta", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("MedicinskaSestraTehnicarId")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Odgovor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Odobreno")
                        .HasColumnType("bit");

                    b.Property<string>("PacijentId")
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("MedicinskaSestraTehnicarId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Posjeta");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Pregled", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("DatumIVrijeme")
                        .HasColumnType("datetime2");

                    b.Property<string>("Dijagnoza")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("DoktorId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Napomena")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Obavljeno")
                        .HasColumnType("bit");

                    b.Property<string>("Odgovor")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("Odobreno")
                        .HasColumnType("bit");

                    b.Property<string>("PacijentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Terapija")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DoktorId");

                    b.HasIndex("PacijentId");

                    b.ToTable("Pregled");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Specijalizacija", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"));

                    b.Property<string>("naziv")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Specijalizacija");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Administrator", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AspNetUsers");

                    b.HasDiscriminator().HasValue("Administrator");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Doktor", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int?>("SpecijalizacijaDoktorId")
                        .HasColumnType("int");

                    b.Property<string>("Titula")
                        .HasColumnType("nvarchar(max)");

                    b.HasIndex("SpecijalizacijaDoktorId");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("Ime")
                                .HasColumnName("Doktor_Ime");

                            t.Property("Prezime")
                                .HasColumnName("Doktor_Prezime");
                        });

                    b.HasDiscriminator().HasValue("Doktor");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.MedicinskaSestraTehnicar", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Obrazovanje")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("Ime")
                                .HasColumnName("MedicinskaSestraTehnicar_Ime");

                            t.Property("Prezime")
                                .HasColumnName("MedicinskaSestraTehnicar_Prezime");
                        });

                    b.HasDiscriminator().HasValue("MedicinskaSestraTehnicar");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Pacijent", b =>
                {
                    b.HasBaseType("Microsoft.AspNetCore.Identity.IdentityUser");

                    b.Property<string>("Ime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("JMBG")
                        .HasColumnType("nvarchar(13)");

                    b.Property<int?>("LokacijaID")
                        .HasColumnType("int");

                    b.Property<string>("Prezime")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("datumRodjenja")
                        .HasColumnType("datetime2");

                    b.HasIndex("LokacijaID");

                    b.ToTable("AspNetUsers", t =>
                        {
                            t.Property("Ime")
                                .HasColumnName("Pacijent_Ime");

                            t.Property("Prezime")
                                .HasColumnName("Pacijent_Prezime");
                        });

                    b.HasDiscriminator().HasValue("Pacijent");
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

            modelBuilder.Entity("eAmbulantaWebApp.Models.Bolest", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Pacijent", "Pacijent")
                        .WithMany("Bolesti")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.JavnaNabavka", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Administrator", "Administrator")
                        .WithMany("JavneNabavke")
                        .HasForeignKey("AdministratorId");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Lijek", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Doktor", "Doktor")
                        .WithMany("DoktorLijekovi")
                        .HasForeignKey("DoktorId");

                    b.HasOne("eAmbulantaWebApp.Models.Pacijent", "Pacijent")
                        .WithMany("PacijentLijekovi")
                        .HasForeignKey("PacijentId");

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.MedicinskiTretman", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.MedicinskaSestraTehnicar", "MedicinskaSestraTehnicar")
                        .WithMany("Tretmani")
                        .HasForeignKey("MedicinskaSestraTehnicarId");

                    b.HasOne("eAmbulantaWebApp.Models.Pacijent", "Pacijent")
                        .WithMany("PropisaniTretmani")
                        .HasForeignKey("PacijentId");

                    b.Navigation("MedicinskaSestraTehnicar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Novost", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Administrator", "Administrator")
                        .WithMany("Novosti")
                        .HasForeignKey("AdministratorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Odluka", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Administrator", "Administrator")
                        .WithMany("Odluke")
                        .HasForeignKey("AdministratorId");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Oglas", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Administrator", "Administrator")
                        .WithMany("Oglasi")
                        .HasForeignKey("AdministratorId");

                    b.Navigation("Administrator");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Posjeta", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.MedicinskaSestraTehnicar", "MedicinskaSestraTehnicar")
                        .WithMany("Posjete")
                        .HasForeignKey("MedicinskaSestraTehnicarId");

                    b.HasOne("eAmbulantaWebApp.Models.Pacijent", "Pacijent")
                        .WithMany("ZatrazenePosjete")
                        .HasForeignKey("PacijentId");

                    b.Navigation("MedicinskaSestraTehnicar");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Pregled", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Doktor", "Doktor")
                        .WithMany("DoktorPregledi")
                        .HasForeignKey("DoktorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("eAmbulantaWebApp.Models.Pacijent", "Pacijent")
                        .WithMany("PacijentPregledi")
                        .HasForeignKey("PacijentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Doktor");

                    b.Navigation("Pacijent");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Doktor", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Specijalizacija", "SpecijalizacijaDoktor")
                        .WithMany()
                        .HasForeignKey("SpecijalizacijaDoktorId");

                    b.Navigation("SpecijalizacijaDoktor");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Pacijent", b =>
                {
                    b.HasOne("eAmbulantaWebApp.Models.Lokacija", "Lokacija")
                        .WithMany()
                        .HasForeignKey("LokacijaID");

                    b.Navigation("Lokacija");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Administrator", b =>
                {
                    b.Navigation("JavneNabavke");

                    b.Navigation("Novosti");

                    b.Navigation("Odluke");

                    b.Navigation("Oglasi");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Doktor", b =>
                {
                    b.Navigation("DoktorLijekovi");

                    b.Navigation("DoktorPregledi");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.MedicinskaSestraTehnicar", b =>
                {
                    b.Navigation("Posjete");

                    b.Navigation("Tretmani");
                });

            modelBuilder.Entity("eAmbulantaWebApp.Models.Pacijent", b =>
                {
                    b.Navigation("Bolesti");

                    b.Navigation("PacijentLijekovi");

                    b.Navigation("PacijentPregledi");

                    b.Navigation("PropisaniTretmani");

                    b.Navigation("ZatrazenePosjete");
                });
#pragma warning restore 612, 618
        }
    }
}
