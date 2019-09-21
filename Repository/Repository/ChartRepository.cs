using Repository.Contract;
using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Repository
{
    public class ChartRepository : IChartRepository
    {

        public IEnumerable<ChartModel> Get(int i)
        {
           return DataManager.GetData(i);
        }

        public IEnumerable<ChartModel> GetVarious(int data, int amount)
        {
            return DataManager.GetVariousData(data, amount);
        }

        public ChartModel GetOne(int value)
        {
            return DataManager.GetOne(value);
        }
    }
}
