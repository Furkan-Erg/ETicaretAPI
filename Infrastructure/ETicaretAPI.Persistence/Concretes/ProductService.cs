using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Concretes
{
    public class ProductService : IProductService
    {
        public List<Product> GetProducts() //generic tipi product olan bir liste döndüren methodu tanımlıyoruz
            => new() //arrow functionla new() yaptığımızda otomatik olarak product tutan list oluşturuyor
            {
                new() { Id = Guid.NewGuid(), Name = "Product1", Price = 100, Stock = 100 }, //new() ile product nesnesi oluşturuyoruz
                new() { Id = Guid.NewGuid(), Name = "Product2", Price = 200, Stock = 100 },
                new() { Id = Guid.NewGuid(), Name = "Product3", Price = 300, Stock = 100 },
                new() { Id = Guid.NewGuid(), Name = "Product4", Price = 400, Stock = 100 },
                new() { Id = Guid.NewGuid(), Name = "Product5", Price = 500, Stock = 100 },
            };
    }
}
