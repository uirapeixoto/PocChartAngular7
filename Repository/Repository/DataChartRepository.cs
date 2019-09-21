using Microsoft.EntityFrameworkCore;
using Repository.Contract;
using Repository.Domain;
using Repository.Entity;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class DataChartRepository : IDataChartRepository
    {
        private readonly DataContext _context;

        public DataChartRepository(DataContext context )
        {
            _context = context;
        }

        public ChartDataModel Add(ChartDataModel data)
        {
            try
            {
                DataChart chart = new DataChart
                {
                    Id = data.Id,
                    Label = data.Label,
                    
                };

                _context.Add(data);
                _context.SaveChanges();
                return data;
            }
            catch (System.Exception e)
            {
                throw e;
            } 
        }

        public IEnumerable<ChartDataModel> GetAll()
        {
            try
            {
                return _context.DataChart.Select(x => new ChartDataModel {
                    Id= x.Id,
                    Label = x.Label,
                });
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ChartDataModel GetById(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentException("query error");

                return _context.DataChart.Where(x => x.Id.Equals(id)).Select(x => new ChartDataModel {
                    Id = x.Id,
                    Label = x.Label
                }).FirstOrDefault();
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public bool Remove(int id, ChartDataModel data)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException("Remove error");

                var i = _context.DataChart.FirstOrDefault(x => x.Id.Equals(id));
                _context.Remove(i);
                _context.SaveChanges();
                return true;
            }
            catch (Exception e)
            {

                throw e;
            }
        }

        public ChartDataModel Update(int id, ChartDataModel data)
        {
            try
            {
                if (data == null || id == 0)
                    throw new ArgumentNullException("Update error");

                var update = _context.DataChart.FirstOrDefault(x => x.Id == id);
                if (!data.Equals(update))
                {
                    update.Label = data.Label;
                    _context.SaveChanges();
                }

                return data;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
