using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Domain
{
    public class ChartDataModel
    {
        public int Id { get; set; }
        public List<Data> Data { get; set; }
        public string Label { get; set; }

        public ChartDataModel()
        {
            Data = new List<Data>();
        }
    }
}
