using ePizzaHub.core.Entities;
using ePizzaHub.Model;


namespace ePizzaHub.Services.Interfaces
{
    public interface IItemService : IService<Item>
    {
        IEnumerable<ItemModel> GetItems();
    }
}
