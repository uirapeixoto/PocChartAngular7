using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Repository.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public DbSet<ChartModel> ChartModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                //optionsBuilder.UseSqlServer("Server=wizposvenda001-hml-sqlserver.database.windows.net;Initial Catalog=SQG;Persist Security Info=False;User ID=usrAppSQG;Password=kcQBwev5TAjMn7wP;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            }
        }


    }
}
