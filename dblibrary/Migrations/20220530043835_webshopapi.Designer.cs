﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using dblibrary.database;

namespace dblibrary.Migrations
{
    [DbContext(typeof(ABcontext))]
    [Migration("20220530043835_webshopapi")]
    partial class webshopapi
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("dblibrary.models.address", b =>
                {
                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.Property<string>("country")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("zipcode")
                        .HasColumnType("int");

                    b.HasKey("userid");

                    b.ToTable("address");
                });

            modelBuilder.Entity("dblibrary.models.currency", b =>
                {
                    b.Property<int>("currencyid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("currencyname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("currencyid");

                    b.ToTable("currency");
                });

            modelBuilder.Entity("dblibrary.models.currencyuser", b =>
                {
                    b.Property<int>("currencyuserid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("currencyid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("currencyuserid");

                    b.HasIndex("currencyid");

                    b.HasIndex("userid");

                    b.ToTable("currencyuser");
                });

            modelBuilder.Entity("dblibrary.models.delivery", b =>
                {
                    b.Property<int>("deliveryid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("deliveryid");

                    b.ToTable("delivery");
                });

            modelBuilder.Entity("dblibrary.models.orders", b =>
                {
                    b.Property<int>("orderid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("deliveryid")
                        .HasColumnType("int");

                    b.Property<int>("paymentid")
                        .HasColumnType("int");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.Property<int>("userid")
                        .HasColumnType("int");

                    b.HasKey("orderid");

                    b.HasIndex("deliveryid");

                    b.HasIndex("paymentid");

                    b.HasIndex("productid");

                    b.HasIndex("userid");

                    b.ToTable("orders");
                });

            modelBuilder.Entity("dblibrary.models.payment", b =>
                {
                    b.Property<int>("paymentid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("method")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("paymentid");

                    b.ToTable("payment");
                });

            modelBuilder.Entity("dblibrary.models.product", b =>
                {
                    b.Property<int>("productid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("price")
                        .HasColumnType("int");

                    b.Property<string>("productname")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("productid");

                    b.ToTable("product");
                });

            modelBuilder.Entity("dblibrary.models.seller", b =>
                {
                    b.Property<int>("sellerid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("productid")
                        .HasColumnType("int");

                    b.HasKey("sellerid");

                    b.HasIndex("productid");

                    b.ToTable("seller");
                });

            modelBuilder.Entity("dblibrary.models.user", b =>
                {
                    b.Property<int>("userid")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("userid");

                    b.ToTable("user");
                });

            modelBuilder.Entity("dblibrary.models.address", b =>
                {
                    b.HasOne("dblibrary.models.user", "user")
                        .WithOne("address")
                        .HasForeignKey("dblibrary.models.address", "userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("user");
                });

            modelBuilder.Entity("dblibrary.models.currencyuser", b =>
                {
                    b.HasOne("dblibrary.models.currency", "currency")
                        .WithMany("currencyuser")
                        .HasForeignKey("currencyid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dblibrary.models.user", "user")
                        .WithMany("currencyuser")
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("currency");

                    b.Navigation("user");
                });

            modelBuilder.Entity("dblibrary.models.orders", b =>
                {
                    b.HasOne("dblibrary.models.delivery", "delivery")
                        .WithMany()
                        .HasForeignKey("deliveryid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dblibrary.models.payment", "payment")
                        .WithMany()
                        .HasForeignKey("paymentid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dblibrary.models.product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("dblibrary.models.user", "user")
                        .WithMany()
                        .HasForeignKey("userid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("delivery");

                    b.Navigation("payment");

                    b.Navigation("product");

                    b.Navigation("user");
                });

            modelBuilder.Entity("dblibrary.models.seller", b =>
                {
                    b.HasOne("dblibrary.models.product", "product")
                        .WithMany()
                        .HasForeignKey("productid")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("product");
                });

            modelBuilder.Entity("dblibrary.models.currency", b =>
                {
                    b.Navigation("currencyuser");
                });

            modelBuilder.Entity("dblibrary.models.user", b =>
                {
                    b.Navigation("address");

                    b.Navigation("currencyuser");
                });
#pragma warning restore 612, 618
        }
    }
}