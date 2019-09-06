using Repository.Context;
using Repository.Contract;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Repository.Repository
{
    public class ChartRepository : IChartRepository
    {
        public readonly DataContext _context;

        public ChartRepository(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<ChartModel> GetData(int i)
        {
            return _context.ChartModel.Where((x, index) => index.Equals(i)).ToList();
        }

        public IEnumerable<ChartModel> GenerateData(int data, int amount) {
            
            var r  = DataManager.GetVariousData(data, amount);

            _context.ChartModel.AddRange(r);
            _context.SaveChanges();

            return r;
        }

        public IEnumerable<ChartModel> GetVariousData(int amount)
        {
            return _context.ChartModel.Take(amount);
        }

    }
}
