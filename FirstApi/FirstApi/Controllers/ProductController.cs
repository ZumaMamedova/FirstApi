using FirstApi.DAL;
using FirstApi.Dtos.Product;
using FirstApi.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Xml.Linq;

namespace FirstApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly AppDbContext _appDbcontext;

        public ProductController(AppDbContext appDbcontext)
        {
            _appDbcontext = appDbcontext;
        }

        //private List<Product> products = new()
        //{
        //    new Product{Id=1, Name="Product1"},
        //    new Product{Id=2, Name="Product2"},
        //    new Product{Id=3, Name="Product3"},
        //    new Product{Id=4, Name="Product4"},
        //};
        [Route("{id}")]
        [HttpGet]
         public IActionResult Get(int id)
        {
            var product =_appDbcontext.Products.FirstOrDefault(p=>p.Id==id&& p.IsDeleted);
            if (product == null) return NotFound();
            var returnProduct = new ProductReturnDto
            {
                Name = product.Name,
                SalePrice = product.SalePrice,
                CostPrice = product.CostPrice,
                IsDeleted = product.IsDeleted
            };
           
            return StatusCode(200,returnProduct);
        }
        
       
        [HttpGet]//api
        public IActionResult GetAll()
        {
            var query = _appDbcontext.Products.Where(p => !p.IsDeleted);
            var itemList=new List<ProductListItemDto>();
            foreach (var item in query.ToList())
            {
                ProductListItemDto productListItemDto = new()
                {
                    Name = item.Name,
                    CostPrice = item.CostPrice,
                    SalePrice = item.SalePrice,
                };
                itemList.Add(productListItemDto);
            }
            var productsListDto = new ProductListDto
            {
                TotalCount = itemList.Count,
                Items = itemList,
            };
          
            
            return StatusCode(StatusCodes.Status200OK,productsListDto);
        }

       
        [HttpPost]
        public IActionResult Create(ProductCreateDto productCreateDto)
        {
            var newProduct=new Product();
            newProduct.Name = productCreateDto.Name;
            newProduct.SalePrice = productCreateDto.SalePrice;
            newProduct.CostPrice = productCreateDto.CostPrice;
            _appDbcontext.Products.Add(newProduct);
            _appDbcontext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        //[Route("{id}")]
        [HttpPut]
        public IActionResult Update(Product product)
        {
            var existProduct = _appDbcontext.Products.FirstOrDefault(p => p.Id == product.Id);
            if (existProduct == null) return NotFound();
            existProduct.Name = product.Name;
            existProduct.SalePrice = product.SalePrice;
            existProduct.CostPrice = product.CostPrice;
            _appDbcontext.SaveChanges();
            return NoContent();
        }
        [Route("{id}")]
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var existProduct = _appDbcontext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            _appDbcontext.Products.Remove(existProduct);
            _appDbcontext.SaveChanges();
            return NoContent();

        }

        [Route("{id}")]
        [HttpPatch]
        public IActionResult Delete(int id, bool isDelete)
        {
            var existProduct = _appDbcontext.Products.FirstOrDefault(p => p.Id == id);
            if (existProduct == null) return NotFound();
            existProduct.IsDeleted = isDelete;
            _appDbcontext.SaveChanges();
            return NoContent();

        }
    }
}
