using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Contract
{
    public interface IDataChartService
    {
        ChartDataModel GetById(int id);
        IEnumerable<ChartDataModel> GetAll();
        ChartDataModel Add(ChartDataModel data);
        ChartDataModel Update(int id, ChartDataModel data);
        bool Remove(int id, ChartDataModel data);
    }
}
