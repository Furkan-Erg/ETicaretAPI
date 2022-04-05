using ETicaretAPI.Application.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase //presentation layerında---> product için controller yapısı
    {
        private readonly IProductWriteRepository _productWriteRepository;
        private readonly IProductReadRepository _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }

        [HttpGet] //denemek için bir product example ının get metodu
        public async Task Get()
        {
            await _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Ürün1", Price = 100, CreatedDate = DateTime.UtcNow, Stock = 10 },
                new() { Id = Guid.NewGuid(), Name = "Ürün2", Price = 200, CreatedDate = DateTime.UtcNow, Stock = 20 },
                new() { Id = Guid.NewGuid(), Name = "Ürün3", Price = 300, CreatedDate = DateTime.UtcNow, Stock = 30 },
            });
            await _productWriteRepository.SaveAsync();
        }

        [HttpGet("{id}")] //denemek için bir product example ının getbyid metodu
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productReadRepository.GetByIdAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
    }
}