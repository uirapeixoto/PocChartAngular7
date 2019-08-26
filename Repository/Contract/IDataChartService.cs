using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Contract
{
    public interface IDataChartService
    {
        List<ChartModel> GetOne();
        List<ChartModel> GetOne(int value);
        List<ChartModel> GetVarious(int data, int amount);
    }
}
