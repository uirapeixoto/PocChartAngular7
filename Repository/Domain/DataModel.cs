using System;
using System.Collections.Generic;

namespace Repository.Domain
{
    public class DataModel
    {
        public int Id { get; set; }
        public int? Mes { get; set; }
        public int? Ano { get; set; }
        public decimal Valor { get; set; }
        public DateTime CriadoEm { get; set; }
        public DateTime? AlteradoEm { get; set; }

        public virtual ChartDataModel DataChart { get; set; }
    }
}
