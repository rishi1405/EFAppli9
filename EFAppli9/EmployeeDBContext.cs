﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace EFAppli9
{
    public class EmployeeDBContext:DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasKey(pk => pk.EmployeeID)
                .ToTable("Employees");

            modelBuilder.Entity<EmployeeContactDetail>()
                .HasKey(pk => pk.EmployeeID)
                .ToTable("Employees");

            modelBuilder.Entity<Employee>()
                .HasRequired(p => p.EmployeeContactDetail)
                .WithRequiredPrincipal(c => c.Employee);
        }
    }
}