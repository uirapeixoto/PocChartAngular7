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

        public DbSet<ChartDataModel> ChartDataModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                
            }
        }


    }
}
