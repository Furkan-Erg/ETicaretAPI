using ETicaretAPI.Application.Abstractions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase //presentation layerında---> product için controller yapısı 
    {
        private readonly IProductService productService; //Iproductservice yaratımı

        public ProductsController(IProductService productService) // constructerda eşleme
        {
            this.productService = productService;
        }
        public IActionResult GetProducts() // bütün producları döndüren method
        {
            var products = productService.GetProducts();
            return Ok(products);
        }


    }
}
