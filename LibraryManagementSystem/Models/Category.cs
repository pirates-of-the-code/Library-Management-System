﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class Category
    {
        public Category()
        {
            ISBNs = new HashSet<Book>();
        }

        public int Category_Id { get; set; }
        public string name { get; set; }

        public virtual ICollection<Book> ISBNs { get; set; }
    }
}