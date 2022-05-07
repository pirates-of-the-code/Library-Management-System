﻿// <auto-generated />
using LibraryManagementSystem.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LibraryManagementSystem.Migrations
{
    [DbContext(typeof(LibrarymanagementsystemContext))]
    partial class LibrarymanagementsystemContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Book_Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.HasKey("Author_Id", "ISBN")
                        .HasName("PK__Book_Aut__F1FE25D1EDDA42B4");

                    b.HasIndex("ISBN");

                    b.ToTable("Book_Author", (string)null);
                });

            modelBuilder.Entity("Book_Category", b =>
                {
                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.HasKey("ISBN", "Category_Id")
                        .HasName("PK__Book_Cat__B2A60E3D883CD03C");

                    b.HasIndex("Category_Id");

                    b.ToTable("Book_Category", (string)null);
                });

            modelBuilder.Entity("Book_Order", b =>
                {
                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.HasKey("Order_Id", "ISBN")
                        .HasName("PK__Book_Ord__55A3B31598EFF9C1");

                    b.HasIndex("ISBN");

                    b.ToTable("Book_Order", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasMaxLength(256)
                        .HasColumnType("nvarchar(256)");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

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
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Author", b =>
                {
                    b.Property<int>("Author_Id")
                        .HasColumnType("int");

                    b.Property<int>("bio")
                        .HasColumnType("int");

                    b.Property<int>("name")
                        .HasColumnType("int");

                    b.HasKey("Author_Id")
                        .HasName("PK__Author__55B9F6BF4F77C4EB");

                    b.ToTable("Author", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Book", b =>
                {
                    b.Property<int>("ISBN")
                        .HasColumnType("int");

                    b.Property<int>("License_Quantity")
                        .HasColumnType("int");

                    b.Property<int>("Price")
                        .HasColumnType("int");

                    b.Property<int>("image")
                        .HasColumnType("int");

                    b.Property<int>("title")
                        .HasColumnType("int");

                    b.HasKey("ISBN")
                        .HasName("PK__Book__447D36EBBC936786");

                    b.ToTable("Book", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.Category", b =>
                {
                    b.Property<int>("Category_Id")
                        .HasColumnType("int");

                    b.Property<int>("name")
                        .HasColumnType("int");

                    b.HasKey("Category_Id")
                        .HasName("PK__Category__6DB38D6EBB1CA63B");

                    b.ToTable("Category", (string)null);
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.OrderTable", b =>
                {
                    b.Property<int>("Order_Id")
                        .HasColumnType("int");

                    b.Property<string>("SSN")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("date")
                        .HasColumnType("int");

                    b.Property<int>("status")
                        .HasColumnType("int");

                    b.HasKey("Order_Id")
                        .HasName("PK__OrderTab__F1E4607B99730232");

                    b.HasIndex("SSN");

                    b.ToTable("OrderTable", (string)null);
                });

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

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

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

            modelBuilder.Entity("Book_Author", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Author", null)
                        .WithMany()
                        .HasForeignKey("Author_Id")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Auth__Autho__2E1BDC42");

                    b.HasOne("LibraryManagementSystem.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("ISBN")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Autho__ISBN__2F10007B");
                });

            modelBuilder.Entity("Book_Category", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Category", null)
                        .WithMany()
                        .HasForeignKey("Category_Id")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Cate__Categ__32E0915F");

                    b.HasOne("LibraryManagementSystem.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("ISBN")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Categ__ISBN__31EC6D26");
                });

            modelBuilder.Entity("Book_Order", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.Book", null)
                        .WithMany()
                        .HasForeignKey("ISBN")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Order__ISBN__3D5E1FD2");

                    b.HasOne("LibraryManagementSystem.Models.OrderTable", null)
                        .WithMany()
                        .HasForeignKey("Order_Id")
                        .IsRequired()
                        .HasConstraintName("FK__Book_Orde__Order__3C69FB99");
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.OrderTable", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.ApplicationUser", "SSNNavigation")
                        .WithMany("OrderTables")
                        .HasForeignKey("SSN")
                        .HasConstraintName("FK__OrderTable__SSN__398D8EEE");

                    b.Navigation("SSNNavigation");
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
                    b.HasOne("LibraryManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.ApplicationUser", null)
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

                    b.HasOne("LibraryManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("LibraryManagementSystem.Models.ApplicationUser", null)
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LibraryManagementSystem.Models.ApplicationUser", b =>
                {
                    b.Navigation("OrderTables");
                });
#pragma warning restore 612, 618
        }
    }
}
