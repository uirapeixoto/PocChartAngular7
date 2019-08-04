using Repository.Contract;
using Repository.Domain;
using System.Collections.Generic;

namespace Repository.Service
{
    public class DataChartService : IDataChartService
    {
        private readonly IDataChartRepository _repository;

        public DataChartService(IDataChartRepository repository)
        {
            _repository = repository;
        }

        public List<ChartModel> GetOne()
        {
            return _repository.GetData();
        }

        public List<ChartModel> GetOne(int value)
        {
            return _repository.GetData(value);
        }

        public List<ChartModel> GetVarious(int data, int amount)
        {
            return _repository.GetVariousData(data, amount);
        }
    }
}
