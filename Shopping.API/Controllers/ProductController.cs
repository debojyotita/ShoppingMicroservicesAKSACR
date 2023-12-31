using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using Shopping.API.Data;
using Shopping.API.Models;

namespace Shopping.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : Controller
    {

        private ProductContext _productContext;

        public ProductController(ProductContext productContext)
        {
            _productContext = productContext;
        }

        [HttpGet("getallproducts")]
        public async Task<IEnumerable<Product>> GetProducts()
        {
            return await (await (await _productContext.GetProducts()).FindAsync(_ => true)).ToListAsync();          
        }
    }
}
