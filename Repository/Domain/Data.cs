using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Domain
{
    public class Data
    {
        public int Id { get; set; }
        public int Mes { get; set; }
        public string NomeMes { get; set; }
        public int Ano { get; set; }
        public decimal Valor { get; set; }
        public int LabelId { get; set; }
    }
}
