﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using WeekFourTemplate.Models;

namespace WeekFourTemplate.Migrations
{
    [DbContext(typeof(WeekFourTemplateContext))]
    [Migration("20210528042124_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.0");

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateCategory", b =>
                {
                    b.Property<int>("TemplateCategoryId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<string>("SomeProperty")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("TemplateCategoryId");

                    b.ToTable("TemplateCategories");
                });

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateCategoryItem", b =>
                {
                    b.Property<int>("TemplateCategoryItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("TemplateCategoryId")
                        .HasColumnType("int");

                    b.Property<int>("TemplateItemId")
                        .HasColumnType("int");

                    b.HasKey("TemplateCategoryItemId");

                    b.HasIndex("TemplateCategoryId");

                    b.HasIndex("TemplateItemId");

                    b.ToTable("TemplateCategoryItem");
                });

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateItem", b =>
                {
                    b.Property<int>("TemplateItemId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    b.Property<int>("SomeProperty")
                        .HasColumnType("int");

                    b.HasKey("TemplateItemId");

                    b.ToTable("TemplateItems");
                });

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateCategoryItem", b =>
                {
                    b.HasOne("WeekFourTemplate.Models.TemplateCategory", "TemplateCategory")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TemplateCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("WeekFourTemplate.Models.TemplateItem", "TemplateItem")
                        .WithMany("JoinEntities")
                        .HasForeignKey("TemplateItemId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TemplateCategory");

                    b.Navigation("TemplateItem");
                });

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateCategory", b =>
                {
                    b.Navigation("JoinEntities");
                });

            modelBuilder.Entity("WeekFourTemplate.Models.TemplateItem", b =>
                {
                    b.Navigation("JoinEntities");
                });
#pragma warning restore 612, 618
        }
    }
}