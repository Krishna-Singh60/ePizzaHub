using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;


namespace ePizzaHub.Services.Implemention
{
    public class Service<TEntity> : IService<TEntity> where TEntity : class
    {
        protected IRepository<TEntity> _repository;
        public Service(IRepository<TEntity> repository)
        {
            _repository = repository;
        }
        public void Add(TEntity entity)
        {
            _repository.Add(entity);
        }

        public void Delete(object id)
        {
           _repository?.Delete(id);
        }

        public TEntity Get(object id)
        {
            return _repository.Get(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return _repository.GetAll();
        }

        public int SaveChanges()
        {
            return _repository.SaveChanges();
        }

        public void Update(TEntity entity)
        {
            _repository.Update(entity);
        }
    }
}
