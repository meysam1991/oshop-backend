 
namespace Oshop.Dtos
{
    public class ProductResultDto
    {
        public int ProductId { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoriesId { get; set; }
    }
}
