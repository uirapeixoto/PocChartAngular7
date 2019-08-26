using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Contract
{
    public interface IDataChartRepository
    {
        List<ChartModel> GetData();
        List<ChartModel> GetData(int value);
        List<ChartModel> GetVariousData(int data, int amount);
    }
}
