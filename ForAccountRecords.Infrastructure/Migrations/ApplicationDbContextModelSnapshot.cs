﻿// <auto-generated />
using System;
using ForAccountRecords.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ForAccountRecords.Infrastructure.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.Entry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("EntryTypeId")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RefrenceNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SubTransactionClassificationId")
                        .HasColumnType("int");

                    b.Property<decimal>("Units")
                        .HasColumnType("decimal(18,2)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("EntryTypeId");

                    b.HasIndex("SubTransactionClassificationId");

                    b.HasIndex("UserId");

                    b.ToTable("Entries");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.EntryType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("EntryTypes");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.SubTransactionClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionClassificationId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionClassificationId");

                    b.ToTable("SubTransactionClassifications");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.TransactionClassification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("TransactionTypeId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("TransactionTypeId");

                    b.ToTable("TransactionClassifications");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.TransactionType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("TransactionTypes");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConfirmationCode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("ConfirmationCodeDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsEmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<bool>("IsNewsLetter")
                        .HasColumnType("bit");

                    b.Property<DateTime>("JoinedOn")
                        .HasColumnType("datetime2");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("LastOnline")
                        .HasColumnType("datetime2");

                    b.Property<string>("MiddleName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserRolesId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("UserRolesId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.UserContact", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Address")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("EmailAddress")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("SecondPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ThirdPhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UserContactsCategoryId")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("Website")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("XUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("facbookUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("linkedInUrl")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("UserContactsCategoryId");

                    b.HasIndex("UserId");

                    b.ToTable("Contacts");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.UserContactsCategory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("ContactsCategories");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.UserRole", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.Entry", b =>
                {
                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.EntryType", "EntryType")
                        .WithMany()
                        .HasForeignKey("EntryTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.SubTransactionClassification", "SubTransactionClassification")
                        .WithMany()
                        .HasForeignKey("SubTransactionClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("EntryType");

                    b.Navigation("SubTransactionClassification");

                    b.Navigation("User");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.SubTransactionClassification", b =>
                {
                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.TransactionClassification", "TransactionClassification")
                        .WithMany()
                        .HasForeignKey("TransactionClassificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionClassification");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.TransactionClassification", b =>
                {
                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.TransactionType", "TransactionType")
                        .WithMany()
                        .HasForeignKey("TransactionTypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.User", b =>
                {
                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.UserRole", "UserRoles")
                        .WithMany()
                        .HasForeignKey("UserRolesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("UserRoles");
                });

            modelBuilder.Entity("ForAccountRecords.Domain.Models.DatabaseModels.UserContact", b =>
                {
                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.UserContactsCategory", "UserContactsCategory")
                        .WithMany()
                        .HasForeignKey("UserContactsCategoryId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("ForAccountRecords.Domain.Models.DatabaseModels.User", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");

                    b.Navigation("UserContactsCategory");
                });
#pragma warning restore 612, 618
        }
    }
}
