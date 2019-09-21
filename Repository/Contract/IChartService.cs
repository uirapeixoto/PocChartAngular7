using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contract
{
    public interface IChartService
    {
        IEnumerable<ChartModel> Get(int i);
        IEnumerable<ChartModel> GetVarious(int data, int amount);
        ChartModel GetOne(int value);
    }
}
