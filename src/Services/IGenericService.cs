using System;
using System.Linq;
using System.Linq.Expressions;

namespace DemoApi.Services {
    public interface IGenericService<T> where T : class
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindBy(Expression<Func<T, bool>> predicate);
        T FindById(Expression<Func<T, bool>> predicate);
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}