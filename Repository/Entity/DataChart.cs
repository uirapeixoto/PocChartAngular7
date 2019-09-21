using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    public partial class DataChart
    {
        public DataChart()
        {
            Data = new HashSet<Data>();
        }

        public int Id { get; set; }
        [StringLength(255)]
        public string Label { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CriadoEm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AlteradoEm { get; set; }

        [InverseProperty("IdDataChartNavigation")]
        public virtual ICollection<Data> Data { get; set; }
    }
}
