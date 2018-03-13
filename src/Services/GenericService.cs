using System;
using System.Linq;
using System.Linq.Expressions;
using DemoApi.Repositories;

namespace DemoApi.Services {
    public class GenericService<T> : IGenericService<T> where T : class
    {
        protected readonly IGenericRepository<T> baseRepository;
        public GenericService(IGenericRepository<T> _baseRepository) => baseRepository = _baseRepository;
        public void Add(T entity) => baseRepository.Add(entity);

        public void Delete(T entity) => baseRepository.Delete(entity);

        public IQueryable<T> FindBy(Expression<Func<T, bool>> predicate) => baseRepository.FindBy(predicate);

        public T FindById(Expression<Func<T, bool>> predicate) => baseRepository.FindById(predicate);

        public IQueryable<T> GetAll() => baseRepository.GetAll();

        public void Save() => baseRepository.Save();

        public void Update(T entity) => baseRepository.Update(entity);
    }
}