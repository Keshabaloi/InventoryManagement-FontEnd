using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace InventoryManagement_FontEnd.Models
{
    public class CategoryModel
    {
        public Guid Id { get; set; }
        [Display(Name ="Category Name")]
        public string Name { get; set; }
        [Display(Name = "Created On")]
        public DateTime CreatedOn { get; set; }
        public bool DeleteFlag { get; set; }
    }
}
