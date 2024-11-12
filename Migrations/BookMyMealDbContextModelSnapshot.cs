﻿// <auto-generated />
using System;
using BookMyMeal.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace BookMyMeal.Migrations
{
    [DbContext(typeof(BookMyMealDbContext))]
    partial class BookMyMealDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.35")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("BookMyMeal.Models.Domain.Admin", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Admin");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.BookedMealDetails", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("BookMealid")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("MealId")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfMeal")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("BookMealid");

                    b.HasIndex("MealId");

                    b.ToTable("BookedMealsDetails");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.BookMeal", b =>
                {
                    b.Property<Guid>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Status")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("bookingDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid>("employeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<double>("payment")
                        .HasColumnType("float");

                    b.HasKey("id");

                    b.HasIndex("employeeId");

                    b.ToTable("BookMeals");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Department", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("DeptName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Department");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Employee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("DepartmentId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("DepartmentId");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Meal", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("day")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("mealTypeid")
                        .HasColumnType("int");

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("price")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("mealTypeid");

                    b.ToTable("Meals");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.MealType", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("MealTypes");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Menu", b =>
                {
                    b.Property<int>("id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("id"), 1L, 1);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("id");

                    b.ToTable("Menu");
                });

            modelBuilder.Entity("MealMenu", b =>
                {
                    b.Property<int>("MealsId")
                        .HasColumnType("int");

                    b.Property<int>("Menusid")
                        .HasColumnType("int");

                    b.HasKey("MealsId", "Menusid");

                    b.HasIndex("Menusid");

                    b.ToTable("MealMenu");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.BookedMealDetails", b =>
                {
                    b.HasOne("BookMyMeal.Models.Domain.BookMeal", "BookMeal")
                        .WithMany("BookedMealDetails")
                        .HasForeignKey("BookMealid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMyMeal.Models.Domain.Meal", "Meal")
                        .WithMany("BookedMealDetails")
                        .HasForeignKey("MealId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("BookMeal");

                    b.Navigation("Meal");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.BookMeal", b =>
                {
                    b.HasOne("BookMyMeal.Models.Domain.Employee", "employee")
                        .WithMany("BookMeals")
                        .HasForeignKey("employeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("employee");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Employee", b =>
                {
                    b.HasOne("BookMyMeal.Models.Domain.Department", "Department")
                        .WithMany("Employees")
                        .HasForeignKey("DepartmentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Department");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Meal", b =>
                {
                    b.HasOne("BookMyMeal.Models.Domain.MealType", "mealType")
                        .WithMany("Meal")
                        .HasForeignKey("mealTypeid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("mealType");
                });

            modelBuilder.Entity("MealMenu", b =>
                {
                    b.HasOne("BookMyMeal.Models.Domain.Meal", null)
                        .WithMany()
                        .HasForeignKey("MealsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("BookMyMeal.Models.Domain.Menu", null)
                        .WithMany()
                        .HasForeignKey("Menusid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.BookMeal", b =>
                {
                    b.Navigation("BookedMealDetails");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Department", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Employee", b =>
                {
                    b.Navigation("BookMeals");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.Meal", b =>
                {
                    b.Navigation("BookedMealDetails");
                });

            modelBuilder.Entity("BookMyMeal.Models.Domain.MealType", b =>
                {
                    b.Navigation("Meal");
                });
#pragma warning restore 612, 618
        }
    }
}
