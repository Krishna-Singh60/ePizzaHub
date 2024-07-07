using ePizzaHub.core;
using ePizzaHub.Model;
using ePizzaHub.Repositories.Interfaces;

namespace ePizzaHub.Repositories.Implementions
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _db;
        public Repository(AppDbContext db) //constructor injection
        {
            _db = db;
        }
        public void Add(TEntity entity)
        {
           _db.Set<TEntity>().Add(entity);
        }

        public void Delete(object id)
        {
            TEntity entity = _db.Set<TEntity>().Find(id);
            if (entity != null)
            {
                _db.Set<TEntity>().Remove(entity);
            }
        }

        public TEntity Get(object id)
        {
            return _db.Set<TEntity>().Find(id);
        }

        public IEnumerable<TEntity> GetAll()
        {
           return _db.Set<TEntity>().ToList();
        }

        public int SaveChanges()
        {
          return  _db.SaveChanges();

        }

        public void Update(TEntity entity)
        {
           _db.Set<TEntity>().Update(entity);
        }

        public UserModel ValidateUser(string email, string passowrd)
        {
            throw new NotImplementedException();
        }
    }
}
