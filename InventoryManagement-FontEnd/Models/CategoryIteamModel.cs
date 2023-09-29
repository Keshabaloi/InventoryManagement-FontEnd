using System.ComponentModel.DataAnnotations.Schema;

namespace InventoryManagement_FontEnd.Models
{
    public class CategoryIteamModel
    {
        public CategoryIteamModel()
        {

        }
        public Guid Id { get; set; }
        public Guid CategoryId { get; set; }
        public virtual CategoryModel Category { get; set; }
  
        public Guid ItemId { get; set; }
        public virtual IteamModel Item { get; set; }
    }
}
