using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Contract
{
    public interface IChartService
    {
        IEnumerable<ChartModel> GetData(int i);
        IEnumerable<ChartModel> GenerateData(int data, int amount);
        IEnumerable<ChartModel> GetVariousData(int amount);
    }
}
