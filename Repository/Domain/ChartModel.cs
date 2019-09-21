using System.Collections.Generic;

namespace Repository.Domain
{
    public class ChartModel
    {
        public int Id { get; set; }
        public List<int> Data { get; set; }
        public string Label { get; set; }

        public ChartModel()
        {
            Data = new List<int>();
        }
    }
}
