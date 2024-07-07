
namespace ePizzaHub.Services.Interfaces
{
    public interface IService<TEntity> where TEntity : class
    {
        //All the generic method created in Iservice interface
        IEnumerable<TEntity> GetAll();
        TEntity Get(object id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(object  id);
        int SaveChanges();
    }
}
