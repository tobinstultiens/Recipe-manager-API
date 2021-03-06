﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;
using RecipeManager.API.Persistence.EntityFramework.Contexts;

namespace RecipeManager.API.Persistence.Migrations
{
    [DbContext(typeof(RecipeContext))]
    [Migration("20200427180527_Recipe")]
    partial class Recipe
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn)
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 63);

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.Direction", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Index")
                        .HasColumnType("integer");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Directions");
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.Ingredient", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("IngredientDescription")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<int>("Measurement")
                        .HasColumnType("integer");

                    b.Property<string>("MeasurementType")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId");

                    b.ToTable("Ingredients");
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.Recipe", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<DateTime>("CreationDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<string>("ImgLink")
                        .HasColumnType("text");

                    b.Property<DateTime>("LastUpdatedDateTime")
                        .HasColumnType("timestamp without time zone");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("text");

                    b.Property<Guid>("UserId")
                        .HasColumnType("uuid");

                    b.Property<string>("VideoLink")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.RecipeTime", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uuid");

                    b.Property<string>("CookTime")
                        .HasColumnType("text");

                    b.Property<string>("PrepTime")
                        .HasColumnType("text");

                    b.Property<Guid>("RecipeId")
                        .HasColumnType("uuid");

                    b.Property<string>("TotalTime")
                        .HasColumnType("text");

                    b.HasKey("Id");

                    b.HasIndex("RecipeId")
                        .IsUnique();

                    b.ToTable("RecipeTimes");
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.Direction", b =>
                {
                    b.HasOne("RecipeManager.API.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Directions")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.Ingredient", b =>
                {
                    b.HasOne("RecipeManager.API.Domain.Entities.Recipe", "Recipe")
                        .WithMany("Ingredients")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("RecipeManager.API.Domain.Entities.RecipeTime", b =>
                {
                    b.HasOne("RecipeManager.API.Domain.Entities.Recipe", "Recipe")
                        .WithOne("RecipeTime")
                        .HasForeignKey("RecipeManager.API.Domain.Entities.RecipeTime", "RecipeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
