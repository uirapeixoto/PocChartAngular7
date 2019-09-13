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

        public ChartDataModel Add(ChartDataModel data)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<ChartDataModel> GetAll()
        {
            throw new System.NotImplementedException();
        }

        public ChartDataModel GetById(int id)
        {
            throw new System.NotImplementedException();
        }

        public bool Remove(int id, ChartDataModel data)
        {
            throw new System.NotImplementedException();
        }

        public ChartDataModel Update(int id, ChartDataModel data)
        {
            throw new System.NotImplementedException();
        }
    }
}
