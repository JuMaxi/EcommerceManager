namespace EcommerceManager.Models.DataBase
{
    public class CategoryRequest
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Image { get; set; }
        public CategoryRequest? Parent { get; set; }
        
    }
}
