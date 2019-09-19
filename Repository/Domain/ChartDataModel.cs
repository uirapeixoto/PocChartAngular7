using System.Collections.Generic;

namespace Repository.Domain
{
    public class ChartDataModel
    {
        public int Id { get; set; }
        public string Label { get; set; }
        public int? IdData { get; set; }

        public IEnumerable<DataModel> Data { get; set; }
    }
}
