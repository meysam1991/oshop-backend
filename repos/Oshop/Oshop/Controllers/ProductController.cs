using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Oshop.Data;
using Oshop.Dtos;
using Oshop.Entities;
using System.Linq;
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
        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var items = await _db.Products.Select(p => new ProductResultDto
            {
                CategoriesId = p.CategoriesId,
                ImageUrl = p.ImageUrl,
                Price = p.Price,
                ProductId = p.Id,
                Title = p.Title
            }).ToListAsync();
            return Ok(items);
        }
        [HttpGet("GetById")]
        public async Task<ActionResult> GetById(int id)
        {
            var item = await _db.Products.FirstOrDefaultAsync(x => x.Id == id);
            var product = new ProductResultDto
            {
                CategoriesId = item.CategoriesId,
                Title = item.Title,
                ImageUrl = item.ImageUrl,
                Price = item.Price,
                ProductId = item.Id,
            };
            return Ok(product);
        }
        [HttpPost]
        [EnableCors("AllowOrigin")]
        public async Task<ActionResult> Create(CreateProductDto model)
        {
            var newProduct = new Product
            {
                ImageUrl = model.ImageUrl,
                Price = model.Price,
                Title = model.Title,
                CategoriesId = model.CategoriesId,
            };
            await _db.Products.AddAsync(newProduct);
            _db.SaveChanges();
            return Ok();
        }
    }
}
