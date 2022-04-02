using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Abstractions
{
    public interface IProductService //interface olarak ProductService sınıfı
    {
        List<Product> GetProducts(); //generic tipi product olan bir liste döndüren method interface

    }
}
