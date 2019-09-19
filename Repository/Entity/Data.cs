using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    public partial class Data
    {
        public int Id { get; set; }
        public int? Mes { get; set; }
        public int? Ano { get; set; }
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime CriadoEm { get; set; }
        [Column(TypeName = "datetime")]
        public DateTime? AlteradoEm { get; set; }
        public int? IdDataChart { get; set; }

        [ForeignKey("IdDataChart")]
        [InverseProperty("Data")]
        public virtual DataChart IdDataChartNavigation { get; set; }
    }
}
