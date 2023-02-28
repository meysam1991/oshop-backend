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
    public class CategoryController : Controller
    {
        private readonly OshopDbContext _db;
        public CategoryController(OshopDbContext db)
        {
            _db= db;
        }
        [HttpPost]
        public async Task <ActionResult> Create(Category model)
        {
            await _db.Categories.AddAsync(model);
            _db.SaveChanges();
            return  Ok();
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult> GetAll()
        {
            var items=await _db.Categories.Select(c=> new CategoryResultDto
            {CategoryId=c.Id,
            Name=c.Name,
            

            }).ToListAsync();
            return Ok(items);
        }
    }
}
