using FirstApi.DAL;
using FirstApi.Dtos.Category;
using FirstApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;

        public CategoryController(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }
        [Route("{id}")]
        [HttpGet]
        public IActionResult Get(int id) 
        { 
            var category=_appDbcontext.Categories.FirstOrDefault(c => c.Id == id);
            if(category == null) return NotFound();
            return Ok(category);
        }

       
        [HttpGet]
        public IActionResult GetAll()
        {
            var category = _appDbcontext.Categories.ToList();
            return Ok(category);
        }

        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existCategory = _appDbcontext.Categories.FirstOrDefault(p => p.Id == id);
            if (existCategory == null) return NotFound();
            _appDbcontext.Categories.Remove(existCategory);
            _appDbcontext.SaveChanges();
            return NoContent();

        }

        [HttpPost]
        public IActionResult Create([FromForm]CategoryCreateDto category)
        {
            if (_appDbcontext.Categories.Any(c => category.Name.ToLower() == category.Name.ToLower()))
            {
                return BadRequest();
            }
            _appDbcontext.Categories.Add(new Category { Name=category.Name,ImageUrl="lorem.jpg"});
            _appDbcontext.SaveChanges();
            return StatusCode(201);
        }
        [Route("{id}")]
        [HttpPut]
        public IActionResult Update(int id, CategoryCreateDto category) 
        {
            var existCategory=_appDbcontext.Categories.FirstOrDefault(c => c.Id == id);
            if (existCategory == null) return NotFound();
            if (_appDbcontext.Categories.Any(c => category.Name.ToLower() == category.Name.ToLower()&&c.Id!=existCategory.Id))
            {
                return BadRequest();
            }
            existCategory.Name= category.Name;
            _appDbcontext.SaveChanges();
            return NoContent() ;
        }
    } 
}
