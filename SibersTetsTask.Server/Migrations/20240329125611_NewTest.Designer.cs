﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SibersTetsTask.Server.Context;

#nullable disable

namespace SibersTetsTask.Server.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20240329125611_NewTest")]
    partial class NewTest
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("EmployeeEntityProjectEntity", b =>
                {
                    b.Property<Guid>("EmployeesId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ProjectsId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("EmployeesId", "ProjectsId");

                    b.HasIndex("ProjectsId");

                    b.ToTable("EmployeeEntityProjectEntity");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.Project.ProjectEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("CustomerName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("ExecutorName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid?>("ProjectManagerId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.HasIndex("ProjectManagerId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.ProjectTask.ProjectTaskEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Comment")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("EmployeeEntityId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Priority")
                        .HasColumnType("int");

                    b.Property<Guid>("ProjectId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Status")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeEntityId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectTasks");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.ProjectTask.TaskEmployee", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("TaskId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("TaskId");

                    b.ToTable("EmployeeTasks");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.EmployeeEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("HashPassword")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.ManagerEntity", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("EmployeeId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("EmployeeId");

                    b.ToTable("Managers");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.RoleEntity", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            RoleName = "Employee"
                        },
                        new
                        {
                            Id = 2,
                            RoleName = "Manager"
                        },
                        new
                        {
                            Id = 3,
                            RoleName = "Director"
                        });
                });

            modelBuilder.Entity("EmployeeEntityProjectEntity", b =>
                {
                    b.HasOne("SibersTetsTask.Server.Model.User.EmployeeEntity", null)
                        .WithMany()
                        .HasForeignKey("EmployeesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SibersTetsTask.Server.Model.Project.ProjectEntity", null)
                        .WithMany()
                        .HasForeignKey("ProjectsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.Project.ProjectEntity", b =>
                {
                    b.HasOne("SibersTetsTask.Server.Model.User.ManagerEntity", "ProjectManager")
                        .WithMany("Projects")
                        .HasForeignKey("ProjectManagerId");

                    b.Navigation("ProjectManager");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.ProjectTask.ProjectTaskEntity", b =>
                {
                    b.HasOne("SibersTetsTask.Server.Model.User.EmployeeEntity", null)
                        .WithMany("ExecutedTasks")
                        .HasForeignKey("EmployeeEntityId");

                    b.HasOne("SibersTetsTask.Server.Model.Project.ProjectEntity", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Project");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.ProjectTask.TaskEmployee", b =>
                {
                    b.HasOne("SibersTetsTask.Server.Model.User.EmployeeEntity", "Employee")
                        .WithMany()
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("SibersTetsTask.Server.Model.ProjectTask.ProjectTaskEntity", "Task")
                        .WithMany()
                        .HasForeignKey("TaskId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Task");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.ManagerEntity", b =>
                {
                    b.HasOne("SibersTetsTask.Server.Model.User.EmployeeEntity", "Employee")
                        .WithMany("ManagedProjects")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.Project.ProjectEntity", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.EmployeeEntity", b =>
                {
                    b.Navigation("ExecutedTasks");

                    b.Navigation("ManagedProjects");
                });

            modelBuilder.Entity("SibersTetsTask.Server.Model.User.ManagerEntity", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
