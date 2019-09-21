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
            _repository.Add(data);
            return data;
        }

        public IEnumerable<ChartDataModel> GetAll() => _repository.GetAll();
        public ChartDataModel GetById(int id) => _repository.GetById(id);


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
