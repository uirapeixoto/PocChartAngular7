using Repository.Contract;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.Service
{
    public class ChartService : IChartService
    {
        private readonly IChartRepository _repository;

        public ChartService(IChartRepository repository)
        {
            _repository = repository;
        }

        public IEnumerable<ChartModel> GenerateData(int data, int amount)
        {
            return _repository.GenerateData(data, amount);
        }

        public IEnumerable<ChartModel> GetData(int i)
        {
            return _repository.GetData(i);
        }

        public IEnumerable<ChartModel> GetVariousData(int amount)
        {
            return _repository.GetVariousData(amount);
        }
    }
}
