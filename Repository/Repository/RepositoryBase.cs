using Microsoft.EntityFrameworkCore;
using Repository.Context;
using Repository.Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Repository.Repository
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly DataContext _context;
        private DbSet<T> entities;
        string errorMessage = string.Empty;

        public RepositoryBase(DataContext context)
        {
            _context = context;
            entities = context.Set<T>();
        }

        public void Add(T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                _context.Add(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }

        public void Update(int id, T entity)
        {
            try
            {
                if (entity == null)
                    throw new ArgumentNullException("entity");

                var update = Get(id);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public void Remove(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentNullException("delete error");
                var entity = Get(id);
                entities.Remove(entity);
                _context.SaveChanges();
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
        {
            try
            {
                return entities.Where(predicate);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public T Get(int id)
        {
            try
            {
                if (id == 0)
                    throw new ArgumentException("query error");
                return entities.Find(id);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            try
            {
                return entities.AsNoTracking();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
