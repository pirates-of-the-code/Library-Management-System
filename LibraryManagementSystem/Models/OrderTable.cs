﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace LibraryManagementSystem.Models
{
    public partial class OrderTable
    {
        public OrderTable()
        {
            ISBNs = new HashSet<Book>();
        }

        public int Order_Id { get; set; }
        public string date { get; set; }
        public int status { get; set; }
        public string SSN { get; set; }

        public virtual ApplicationUser SSNNavigation { get; set; }

        public virtual ICollection<Book> ISBNs { get; set; }
    }
}