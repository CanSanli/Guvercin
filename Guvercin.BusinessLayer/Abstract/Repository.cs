using Guvercin.DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Guvercin.BusinessLayer.Abstract
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DataContext _dataContext = new DataContext();
        private DbSet<T> _objectSet;
        public Repository()
        {
            _objectSet = _dataContext.Set<T>();
        }
        public void Delete(T t)
        {
            _objectSet.Remove(t);
            Save();
        }

        public IEnumerable<T> Get(Expression<Func<T, bool>> filter = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null, string includeProperties = "")
        {
            IQueryable<T> query = _objectSet;
            if (filter !=null)
            {
                query = query.Where(filter);

            }
            if (includeProperties != null)
            {
                foreach (var item in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
                {
                    query = query.Include(item);
                }
            }
            if (orderBy !=null)
            {
                return orderBy(query).ToList();
            }
            else
            {
                return query.ToList();
            }
          

            
        }

        public T GetbyId(int id)
        {
            return _objectSet.Find(id);
        }

        public void Insert(T t)
        {
            _objectSet.Add(t);
            Save();
        }

        public List<T> List()
        {
            return _objectSet.ToList();
        }

        public void Save()
        {
            try
            {
                // Veritabanı işlemleri
                _dataContext.SaveChanges();
            }
            catch (System.Data.Entity.Validation.DbEntityValidationException dbEx)
            {
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                {
                    foreach (var validationError in validationErrors.ValidationErrors)
                    {
                       Console.WriteLine("Property: {0} Error: {1}",
                                          validationError.PropertyName,
                                          validationError.ErrorMessage);
                    }
                }
            }
        }

        public void Update(T t)
        {
            _objectSet.Attach(t);
            _dataContext.Entry(t).State = EntityState.Modified;
            Save();
        }
    }
}
