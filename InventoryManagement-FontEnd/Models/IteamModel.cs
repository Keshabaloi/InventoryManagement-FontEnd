using Microsoft.AspNetCore.Mvc.Rendering;

namespace InventoryManagement_FontEnd.Models
{
    public class IteamModel
    {
     
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string? Description { get; set; }
            public decimal Price { get; set; }
            public int Quantity { get; set; }
            public string? ImageUrl { get; set; }
            public int ThresholdQuantity { get; set; }
            public bool IsAvailable { get; set; }
            public bool DeleteFlag { get; set; }
            public DateTime? CreatedOn { get; set; }
            public Guid CategoryId { get; set; }
            public List<ItemCategories>? ItemCategories { get; set; }
          
        }

        public class ItemCategories
        {
            public string CategoryName { get; set; }
            public Guid CategoryId { get; set; }
        }
    }
