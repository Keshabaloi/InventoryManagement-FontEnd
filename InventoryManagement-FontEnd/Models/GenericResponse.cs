namespace InventoryManagement_FontEnd.Models
{
    public class GenericResponse<T>
    {
       
            public bool Success { get; set; } = false;
            public string? Message { get; set; }
            public T? Data { get; set; }
       
    }
}
