﻿// <auto-generated />
using System;
using InterviewBank.Database;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace InterviewBank.Database.Migrations
{
    [DbContext(typeof(BankDbContext))]
    partial class BankDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "6.0.7");

            modelBuilder.Entity("InterviewBank.Database.Models.Account", b =>
                {
                    b.Property<string>("AccountNumber")
                        .HasColumnType("TEXT");

                    b.Property<string>("BIN")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Balance")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ClientId")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccountNumber");

                    b.HasIndex("BIN");

                    b.HasIndex("ClientId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            AccountNumber = "45jmsh2",
                            BIN = "815",
                            Balance = 0,
                            ClientId = "1122943"
                        },
                        new
                        {
                            AccountNumber = "smn4592",
                            BIN = "004",
                            Balance = 0,
                            ClientId = "1122943"
                        });
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Bank", b =>
                {
                    b.Property<string>("BIN")
                        .HasColumnType("TEXT");

                    b.Property<string>("Country")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BIN");

                    b.ToTable("Banks");

                    b.HasData(
                        new
                        {
                            BIN = "815",
                            Country = "Québec",
                            Name = "Caisse Populaire DesJardins"
                        },
                        new
                        {
                            BIN = "004",
                            Country = "Canada",
                            Name = "Toronto Dominion"
                        });
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Client", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Clients");

                    b.HasData(
                        new
                        {
                            Id = "1122943",
                            Name = "Bob The Builder"
                        });
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Transaction", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("TEXT");

                    b.Property<string>("AccountNumber")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Amount")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsFlagged")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Timestamp")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("AccountNumber");

                    b.ToTable("Transactions");
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Account", b =>
                {
                    b.HasOne("InterviewBank.Database.Models.Bank", "Bank")
                        .WithMany("Accounts")
                        .HasForeignKey("BIN")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("InterviewBank.Database.Models.Client", "Client")
                        .WithMany("Accounts")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Bank");

                    b.Navigation("Client");
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Transaction", b =>
                {
                    b.HasOne("InterviewBank.Database.Models.Account", "Account")
                        .WithMany()
                        .HasForeignKey("AccountNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Bank", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("InterviewBank.Database.Models.Client", b =>
                {
                    b.Navigation("Accounts");
                });
#pragma warning restore 612, 618
        }
    }
}
