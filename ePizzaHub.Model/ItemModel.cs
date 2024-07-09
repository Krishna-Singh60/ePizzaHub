using Microsoft.AspNetCore.Http;

namespace ePizzaHub.Model
{
    public class ItemModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public string ItemId { get; set; }
        public string ImageUrl { get; set; }
        public int CategoryId { get; set; }
        public string Quantity { get; set; }
        public int Total { get; set; }
        public IFormFile File { get; set; } //It use in admin module, when it come to upload the file
        public int ItemTypeId { get; set; }
    }
}
