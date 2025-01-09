﻿// <auto-generated />
using System;
using MasterNet.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace MasterNet.Persistence.Migrations
{
    [DbContext(typeof(MasterNetDbContext))]
    partial class MasterNetDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.0-preview.2.24128.4");

            modelBuilder.Entity("MasterNet.Domain.Calificacion", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Alumno")
                        .HasColumnType("TEXT");

                    b.Property<string>("Comentario")
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<int>("Puntaje")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("calificaciones", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Curso", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Descripcion")
                        .HasColumnType("TEXT");

                    b.Property<DateTime?>("FechaPublicacion")
                        .HasColumnType("TEXT");

                    b.Property<string>("Titulo")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("cursos", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("9d8126b1-f143-4f59-a648-9c4c4a3a63f2"),
                            Descripcion = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8007),
                            Titulo = "Rustic Granite Pizza"
                        },
                        new
                        {
                            Id = new Guid("c98198ea-95d4-4afe-80f3-3db5efefc071"),
                            Descripcion = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8035),
                            Titulo = "Refined Wooden Chicken"
                        },
                        new
                        {
                            Id = new Guid("6857f464-41f0-414d-a297-df2a22e54056"),
                            Descripcion = "The Apollotech B340 is an affordable wireless mouse with reliable connectivity, 12 months battery life and modern design",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8052),
                            Titulo = "Ergonomic Plastic Hat"
                        },
                        new
                        {
                            Id = new Guid("5f72c903-f750-4b11-8869-c76990f14ef2"),
                            Descripcion = "Carbonite web goalkeeper gloves are ergonomically designed to give easy fit",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8067),
                            Titulo = "Licensed Frozen Salad"
                        },
                        new
                        {
                            Id = new Guid("20ad9a3b-68fa-4d2f-b4cf-8f0ec5eab825"),
                            Descripcion = "New range of formal shirts are designed keeping you in mind. With fits and styling that will make you stand apart",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8098),
                            Titulo = "Unbranded Steel Table"
                        },
                        new
                        {
                            Id = new Guid("b215e469-7b81-4b3c-aad8-aa51f22033ee"),
                            Descripcion = "Ergonomic executive chair upholstered in bonded black leather and PVC padded seat and back for all-day comfort and support",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8115),
                            Titulo = "Handmade Metal Mouse"
                        },
                        new
                        {
                            Id = new Guid("4e723604-e681-454a-b719-81cf770eaf23"),
                            Descripcion = "Andy shoes are designed to keeping in mind durability as well as trends, the most stylish range of shoes & sandals",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8131),
                            Titulo = "Practical Concrete Bacon"
                        },
                        new
                        {
                            Id = new Guid("3e2be212-7517-43ae-a7e8-2b40aa112253"),
                            Descripcion = "The Nagasaki Lander is the trademarked name of several series of Nagasaki sport bikes, that started with the 1984 ABC800J",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8144),
                            Titulo = "Fantastic Frozen Ball"
                        },
                        new
                        {
                            Id = new Guid("e59a532d-c3f1-4dc4-926b-1f7fd5160815"),
                            Descripcion = "The automobile layout consists of a front-engine design, with transaxle-type transmissions mounted at the rear of the engine and four wheel drive",
                            FechaPublicacion = new DateTime(2025, 1, 9, 20, 27, 5, 736, DateTimeKind.Utc).AddTicks(8199),
                            Titulo = "Handmade Fresh Chips"
                        });
                });

            modelBuilder.Entity("MasterNet.Domain.CursoInstructor", b =>
                {
                    b.Property<Guid>("InstructorId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.HasKey("InstructorId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("cursos_instructores", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.CursoPrecio", b =>
                {
                    b.Property<Guid>("PrecioId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.HasKey("PrecioId", "CursoId");

                    b.HasIndex("CursoId");

                    b.ToTable("cursos_precios", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Instructor", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Apellidos")
                        .HasColumnType("TEXT");

                    b.Property<string>("Grado")
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("instructores", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("ce8fbddf-0a4d-4e30-8fd6-6f01bbfef705"),
                            Apellidos = "O'Connell",
                            Grado = "Human Quality Developer",
                            Nombre = "Myrtice"
                        },
                        new
                        {
                            Id = new Guid("d31a89c9-82f7-4fcb-a922-450f8b2fc9d2"),
                            Apellidos = "Wiza",
                            Grado = "Forward Paradigm Administrator",
                            Nombre = "Mary"
                        },
                        new
                        {
                            Id = new Guid("a1a25c4b-9c0e-4eb4-8a54-50b8d37b3af3"),
                            Apellidos = "Weissnat",
                            Grado = "Senior Communications Developer",
                            Nombre = "Veda"
                        },
                        new
                        {
                            Id = new Guid("d6102cd0-f956-4a49-9bd2-f8e7ddf2f03b"),
                            Apellidos = "Kunze",
                            Grado = "Chief Communications Administrator",
                            Nombre = "Kale"
                        },
                        new
                        {
                            Id = new Guid("29fbd543-898e-4dc7-bf19-b6700f40e86d"),
                            Apellidos = "Hettinger",
                            Grado = "Customer Intranet Coordinator",
                            Nombre = "Abdullah"
                        },
                        new
                        {
                            Id = new Guid("f5e91144-ce39-412e-bd45-2073653dc378"),
                            Apellidos = "Thiel",
                            Grado = "Global Identity Developer",
                            Nombre = "Amara"
                        },
                        new
                        {
                            Id = new Guid("a4deb887-e840-47a6-81f8-919cc41336bb"),
                            Apellidos = "Metz",
                            Grado = "International Program Orchestrator",
                            Nombre = "Mina"
                        },
                        new
                        {
                            Id = new Guid("c91fa4d2-ec40-4512-bdc4-2786538abbeb"),
                            Apellidos = "Torphy",
                            Grado = "Investor Program Officer",
                            Nombre = "Pablo"
                        },
                        new
                        {
                            Id = new Guid("bb840517-621f-4289-8304-69040a1a4a1e"),
                            Apellidos = "Boyer",
                            Grado = "Future Mobility Coordinator",
                            Nombre = "Mafalda"
                        },
                        new
                        {
                            Id = new Guid("08ecaea8-7d42-4cb5-99b1-c955cd3b182c"),
                            Apellidos = "Berge",
                            Grado = "Corporate Data Architect",
                            Nombre = "Brayan"
                        });
                });

            modelBuilder.Entity("MasterNet.Domain.Photo", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<Guid?>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<string>("PublicId")
                        .HasColumnType("TEXT");

                    b.Property<string>("Url")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("CursoId");

                    b.ToTable("imagenes", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Precio", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("TEXT");

                    b.Property<string>("Nombre")
                        .HasMaxLength(250)
                        .HasColumnType("VARCHAR");

                    b.Property<decimal>("PrecioActual")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.Property<decimal>("PrecioPromocion")
                        .HasPrecision(10, 2)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("precios", (string)null);

                    b.HasData(
                        new
                        {
                            Id = new Guid("f985e709-ff6d-4bf5-aaa0-88531d412959"),
                            Nombre = "Precio Regular",
                            PrecioActual = 10.0m,
                            PrecioPromocion = 8.0m
                        });
                });

            modelBuilder.Entity("MasterNet.Persistence.Models.AppUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Carrera")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("TEXT");

                    b.Property<string>("NombreCompleto")
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("TEXT");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("TEXT");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("INTEGER");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("INTEGER");

                    b.Property<string>("UserName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasDatabaseName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasDatabaseName("UserNameIndex");

                    b.ToTable("AspNetUsers", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256)
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasDatabaseName("RoleNameIndex");

                    b.ToTable("AspNetRoles", (string)null);

                    b.HasData(
                        new
                        {
                            Id = "0d4444b5-25da-47b4-82e5-c2894e698219",
                            Name = "ADMIN",
                            NormalizedName = "ADMIN"
                        },
                        new
                        {
                            Id = "b39fd178-aa4b-4573-b7be-4df1f234e3ce",
                            Name = "CLIENT",
                            NormalizedName = "CLIENT"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims", (string)null);

                    b.HasData(
                        new
                        {
                            Id = 1,
                            ClaimType = "POLICIES",
                            ClaimValue = "CURSO_READ",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 2,
                            ClaimType = "POLICIES",
                            ClaimValue = "CURSO_UPDATE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 3,
                            ClaimType = "POLICIES",
                            ClaimValue = "CURSO_WRITE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 4,
                            ClaimType = "POLICIES",
                            ClaimValue = "CURSO_DELETE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 5,
                            ClaimType = "POLICIES",
                            ClaimValue = "INSTRUCTOR_CREATE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 6,
                            ClaimType = "POLICIES",
                            ClaimValue = "INSTRUCTOR_READ",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 7,
                            ClaimType = "POLICIES",
                            ClaimValue = "INSTRUCTOR_UPDATE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 8,
                            ClaimType = "POLICIES",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 9,
                            ClaimType = "POLICIES",
                            ClaimValue = "COMENTARIO_DELETE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 10,
                            ClaimType = "POLICIES",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "0d4444b5-25da-47b4-82e5-c2894e698219"
                        },
                        new
                        {
                            Id = 11,
                            ClaimType = "POLICIES",
                            ClaimValue = "CURSO_READ",
                            RoleId = "b39fd178-aa4b-4573-b7be-4df1f234e3ce"
                        },
                        new
                        {
                            Id = 12,
                            ClaimType = "POLICIES",
                            ClaimValue = "INSTRUCTOR_READ",
                            RoleId = "b39fd178-aa4b-4573-b7be-4df1f234e3ce"
                        },
                        new
                        {
                            Id = 13,
                            ClaimType = "POLICIES",
                            ClaimValue = "COMENTARIO_READ",
                            RoleId = "b39fd178-aa4b-4573-b7be-4df1f234e3ce"
                        },
                        new
                        {
                            Id = 14,
                            ClaimType = "POLICIES",
                            ClaimValue = "COMENTARIO_CREATE",
                            RoleId = "b39fd178-aa4b-4573-b7be-4df1f234e3ce"
                        });
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClaimType")
                        .HasColumnType("TEXT");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("TEXT");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("TEXT");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("RoleId")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId")
                        .HasColumnType("TEXT");

                    b.Property<string>("LoginProvider")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .HasColumnType("TEXT");

                    b.Property<string>("Value")
                        .HasColumnType("TEXT");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens", (string)null);
                });

            modelBuilder.Entity("MasterNet.Domain.Calificacion", b =>
                {
                    b.HasOne("MasterNet.Domain.Curso", "Curso")
                        .WithMany("Calificaciones")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Curso");
                });

            modelBuilder.Entity("MasterNet.Domain.CursoInstructor", b =>
                {
                    b.HasOne("MasterNet.Domain.Curso", "Curso")
                        .WithMany("CursoInstructores")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterNet.Domain.Instructor", "Instructor")
                        .WithMany("CursoInstructores")
                        .HasForeignKey("InstructorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Instructor");
                });

            modelBuilder.Entity("MasterNet.Domain.CursoPrecio", b =>
                {
                    b.HasOne("MasterNet.Domain.Curso", "Curso")
                        .WithMany("CursoPrecios")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("MasterNet.Domain.Precio", "Precio")
                        .WithMany("CursoPrecios")
                        .HasForeignKey("PrecioId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Curso");

                    b.Navigation("Precio");
                });

            modelBuilder.Entity("MasterNet.Domain.Photo", b =>
                {
                    b.HasOne("MasterNet.Domain.Curso", "Curso")
                        .WithMany("Photos")
                        .HasForeignKey("CursoId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.Navigation("Curso");
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
                    b.HasOne("MasterNet.Persistence.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("MasterNet.Persistence.Models.AppUser", null)
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

                    b.HasOne("MasterNet.Persistence.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("MasterNet.Persistence.Models.AppUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("MasterNet.Domain.Curso", b =>
                {
                    b.Navigation("Calificaciones");

                    b.Navigation("CursoInstructores");

                    b.Navigation("CursoPrecios");

                    b.Navigation("Photos");
                });

            modelBuilder.Entity("MasterNet.Domain.Instructor", b =>
                {
                    b.Navigation("CursoInstructores");
                });

            modelBuilder.Entity("MasterNet.Domain.Precio", b =>
                {
                    b.Navigation("CursoPrecios");
                });
#pragma warning restore 612, 618
        }
    }
}