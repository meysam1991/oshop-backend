using Microsoft.AspNetCore.Mvc;
using Oshop.Data;
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

        [HttpGet]
        public async Task<ActionResult> GetAll()
        {
            return Ok(_db.Categories.ToList());
        }
    }
}
