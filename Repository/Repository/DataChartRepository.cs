using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contract;
using Repository.Domain;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Repository
{
    public class DataChartRepository : IDataChartRepository
    {
        private readonly DataContext _context;
        private DbSet<ChartDataModel> _entity;

        public DataChartRepository(DataContext context )
        {
            _context = context;
        }

        public ChartDataModel Add(ChartDataModel data)
        {
            try
            {
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
                return _entity.AsQueryable();
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

                return _entity.FirstOrDefault(x => x.Id.Equals(id));
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

                var i = _entity.FirstOrDefault(x => x.Id.Equals(id));
                 _entity.Remove(i);
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
                if (_entity == null || id == 0)
                    throw new ArgumentNullException("Update error");

                var update = GetById(id);
                if (!data.Equals(update))
                {
                    update.Data = data.Data;
                    update.Label = data.Label;
                    _context.SaveChanges();
                }

                return update;

            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
