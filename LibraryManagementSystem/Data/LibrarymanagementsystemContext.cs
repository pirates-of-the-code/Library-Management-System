﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using LibraryManagementSystem.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace LibraryManagementSystem.Data
{
    public partial class LibrarymanagementsystemContext : IdentityDbContext<ApplicationUser>
    {
        public LibrarymanagementsystemContext(DbContextOptions<LibrarymanagementsystemContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Book> Books { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<OrderTable> OrderTables { get; set; }
       
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            
            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(e => e.Author_Id)
                    .HasName("PK__Author__55B9F6BF4F77C4EB");

                entity.ToTable("Author");

                entity.Property(e => e.Author_Id).ValueGeneratedNever();

                entity.HasMany(d => d.ISBNs)
                    .WithMany(p => p.Authors)
                    .UsingEntity<Dictionary<string, object>>(
                        "Book_Author",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("ISBN").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Autho__ISBN__2F10007B"),
                        r => r.HasOne<Author>().WithMany().HasForeignKey("Author_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Auth__Autho__2E1BDC42"),
                        j =>
                        {
                            j.HasKey("Author_Id", "ISBN").HasName("PK__Book_Aut__F1FE25D1EDDA42B4");

                            j.ToTable("Book_Author");
                        });
            });

            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(e => e.ISBN)
                    .HasName("PK__Book__447D36EBBC936786");

                entity.ToTable("Book");

                entity.Property(e => e.ISBN).ValueGeneratedNever();

                entity.HasMany(d => d.Categories)
                    .WithMany(p => p.ISBNs)
                    .UsingEntity<Dictionary<string, object>>(
                        "Book_Category",
                        l => l.HasOne<Category>().WithMany().HasForeignKey("Category_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Cate__Categ__32E0915F"),
                        r => r.HasOne<Book>().WithMany().HasForeignKey("ISBN").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Categ__ISBN__31EC6D26"),
                        j =>
                        {
                            j.HasKey("ISBN", "Category_Id").HasName("PK__Book_Cat__B2A60E3D883CD03C");

                            j.ToTable("Book_Category");
                        });
            });
            
            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Category_Id)
                    .HasName("PK__Category__6DB38D6EBB1CA63B");

                entity.ToTable("Category");

                entity.Property(e => e.Category_Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<OrderTable>(entity =>
            {
                entity.HasKey(e => e.Order_Id)
                    .HasName("PK__OrderTab__F1E4607B99730232");

                entity.ToTable("OrderTable");

                entity.Property(e => e.Order_Id).ValueGeneratedNever();

                entity.HasOne(d => d.SSNNavigation)
                    .WithMany(p => p.OrderTables)
                    .HasForeignKey(d => d.SSN)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__OrderTable__SSN__398D8EEE");

                entity.HasMany(d => d.ISBNs)
                    .WithMany(p => p.Orders)
                    .UsingEntity<Dictionary<string, object>>(
                        "Book_Order",
                        l => l.HasOne<Book>().WithMany().HasForeignKey("ISBN").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Order__ISBN__3D5E1FD2"),
                        r => r.HasOne<OrderTable>().WithMany().HasForeignKey("Order_Id").OnDelete(DeleteBehavior.ClientSetNull).HasConstraintName("FK__Book_Orde__Order__3C69FB99"),
                        j =>
                        {
                            j.HasKey("Order_Id", "ISBN").HasName("PK__Book_Ord__55A3B31598EFF9C1");

                            j.ToTable("Book_Order");
                        });
            });

            

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}