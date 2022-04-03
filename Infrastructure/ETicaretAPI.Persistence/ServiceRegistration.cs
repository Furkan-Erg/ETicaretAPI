using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Application.Abstractions;
using ETicaretAPI.Persistence.Concretes;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration //ioc conteinerında kullanılacak servisleri register eden class
    {
        public static void AddPersistenceServices(this IServiceCollection services) //bütün persistence servisleri presentation layerda kullanabilmek için method
        {
            services.AddSingleton<IProductService, ProductService>(); //bu line sayesinde ne zaman productservice'in interface i call edilse bize gerçek productservisi döndürecek

            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString)); //bütün persistence servisleri için dbcontexti ekliyoruz
        }
    }
}