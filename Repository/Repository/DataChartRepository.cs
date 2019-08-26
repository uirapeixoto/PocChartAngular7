using Repository.Contract;
using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class DataChartRepository : IDataChartRepository
    {
        public List<ChartModel> GetData()
        {
            return DataManager.GetData();
        }

        public List<ChartModel> GetData(int value)
        {
            return DataManager.GetData(value);
        }

        public List<ChartModel> GetVariousData(int data, int amount)
        {
            return DataManager.GetVariousData(data, amount);
        }
    }
}
