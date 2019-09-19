using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Repository.Entity
{
    public partial class DataContext : DbContext
    {
        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Data> Data { get; set; }
        public virtual DbSet<DataChart> DataChart { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=NOTE\\SQLEXPRESS;Initial Catalog=DataChartDb;Integrated Security=SSPI;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Data>(entity =>
            {
                entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.IdDataChartNavigation)
                    .WithMany(p => p.Data)
                    .HasForeignKey(d => d.IdDataChart)
                    .HasConstraintName("FK_Data_DataChart");
            });

            modelBuilder.Entity<DataChart>(entity =>
            {
                entity.Property(e => e.CriadoEm).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Label).IsUnicode(false);
            });
        }
    }
}
