using ePizzaHub.core.Entities;
using ePizzaHub.Model;
using ePizzaHub.Repositories.Interfaces;
using ePizzaHub.Services.Interfaces;

namespace ePizzaHub.Services.Implemention
{
    public class ItemService : Service<Item>, IItemService
    {
        private readonly IRepository<Item> _itemRepo;
        public ItemService(IRepository<Item> itemRepo) : base(itemRepo)
        {
            _itemRepo = itemRepo;
            
        }
        public IEnumerable<ItemModel> GetItems()
        {
            var data = _itemRepo.GetAll().OrderBy(item => item.CategoryId).Select(item =>
            new ItemModel
            {
                Id = item.Id,
                Name = item.Name,
                CategoryId = item.CategoryId,
                Description = item.Description,
                UnitPrice   = item.UnitPrice,
                ImageUrl = item.ImageUrl,
                ItemTypeId = item.ItemTypeId
            });
            return data;

        }

    }
}
