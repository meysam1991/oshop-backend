using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Oshop.Data;
using Oshop.Dtos;
using Oshop.Entities;
using System.Threading.Tasks;

namespace Oshop.Api.Controllers
{
   
    [ApiController]
    [Route("[controller]")]

    public class ProductController : Controller
    {
        private readonly OshopDbContext _db;
        public ProductController(OshopDbContext db)
        {
            _db = db;
        }
        [HttpPost]
         
        public async Task<ActionResult> Create(CreateProductDto model)
        {
            var newProduct = new Product
            {
             ImageUrl=model.ImageUrl,
             Price= model.Price,
             Title=model.Title,
             CategoriesId=model.CategoriesId,
            };
            await _db.Products.AddAsync(newProduct);
            _db.SaveChanges();
            return Ok();
        }
    }
}
