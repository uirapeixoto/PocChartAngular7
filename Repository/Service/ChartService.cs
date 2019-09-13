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


        public IEnumerable<ChartModel> Get(int i)
        {
            return _repository.Get(i);
        }

        public ChartModel GetOne(int value)
        {
            return _repository.GetOne(value);
        }

        public IEnumerable<ChartModel> GetVarious(int data, int amount)
        {
            return _repository.GetVarious(data, amount);
        }
    }
}
