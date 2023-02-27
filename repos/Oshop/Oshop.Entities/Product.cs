 

namespace Oshop.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public double Price { get; set; }
        public string ImageUrl { get; set; }
        public int CategoriesId { get; set; }
        public virtual Category Categories { get; set; }
    }
}
