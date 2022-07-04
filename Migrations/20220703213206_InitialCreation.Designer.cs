﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SistemaLocacao.Data;

#nullable disable

namespace SistemaLocacao.Migrations
{
    [DbContext(typeof(SistemaLocacaoDbContext))]
    [Migration("20220703213206_InitialCreation")]
    partial class InitialCreation
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 64);

            modelBuilder.Entity("SistemaLocacao.Models.Cliente", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CPF")
                        .IsRequired()
                        .HasMaxLength(11)
                        .HasColumnType("VARCHAR(11)")
                        .HasColumnName("CPF");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("datetime(6)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("VARCHAR(200)")
                        .HasColumnName("Nome");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "CPF" }, "idx_CPF")
                        .IsUnique();

                    b.HasIndex(new[] { "Nome" }, "idx_NOME");

                    b.ToTable("Clientes", (string)null);
                });

            modelBuilder.Entity("SistemaLocacao.Models.Filme", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClassificacaoIndicativa")
                        .HasColumnType("INT")
                        .HasColumnName("ClassificacaoIndicativa");

                    b.Property<sbyte>("Lancamento")
                        .HasColumnType("TINYINT")
                        .HasColumnName("Lancamento");

                    b.Property<string>("Titulo")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("Titulo");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "Lancamento" }, "idx_Lancamento");

                    b.HasIndex(new[] { "Titulo" }, "idx_Titulo");

                    b.ToTable("Filmes", (string)null);
                });

            modelBuilder.Entity("SistemaLocacao.Models.Locacao", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("ClienteId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("DataDevolucao")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataDevolucao");

                    b.Property<DateTime>("DataLocacao")
                        .HasColumnType("DATETIME")
                        .HasColumnName("DataLocacao");

                    b.Property<int>("FilmeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex(new[] { "ClienteId" }, "FK_Cliente_idx");

                    b.HasIndex(new[] { "FilmeId" }, "FK_Filme_idx");

                    b.ToTable("Locacoes", (string)null);
                });

            modelBuilder.Entity("SistemaLocacao.Models.Locacao", b =>
                {
                    b.HasOne("SistemaLocacao.Models.Cliente", "Cliente")
                        .WithMany("Locacoes")
                        .HasForeignKey("ClienteId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Cliente_Locacao");

                    b.HasOne("SistemaLocacao.Models.Filme", "Filme")
                        .WithMany("Locacoes")
                        .HasForeignKey("FilmeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired()
                        .HasConstraintName("FK_Filme_Locacao");

                    b.Navigation("Cliente");

                    b.Navigation("Filme");
                });

            modelBuilder.Entity("SistemaLocacao.Models.Cliente", b =>
                {
                    b.Navigation("Locacoes");
                });

            modelBuilder.Entity("SistemaLocacao.Models.Filme", b =>
                {
                    b.Navigation("Locacoes");
                });
#pragma warning restore 612, 618
        }
    }
}
