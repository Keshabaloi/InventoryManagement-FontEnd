namespace InventoryManagement_FontEnd.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public DateTime CreatedOn { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
