using Microsoft.EntityFrameworkCore;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Persistence.Repositories;

namespace ETicaretAPI.Persistence
{
    public static class ServiceRegistration //ioc conteinerında kullanılacak servisleri register eden class
    {
        public static void AddPersistenceServices(this IServiceCollection services) //bütün persistence servisleri presentation layerda kullanabilmek için method
        {
            services.AddDbContext<ETicaretAPIDbContext>(options => options.UseNpgsql(Configuration.ConnectionString), ServiceLifetime.Singleton); //bütün persistence servisleri için dbcontexti ekliyoruz
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();//interface istendiğinde gerçek customerreadrepository döndürüyoruz
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();//interface istendiğinde gerçek customerwriterepository döndürüyoruz
            services.AddScoped<IProductReadRepository, ProductReadRepository>();//interface istendiğinde gerçek productreadrepository döndürüyoruz
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();//interface istendiğinde gerçek productwriterepository döndürüyoruz
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();//interface istendiğinde gerçek orderreadrepository döndürüyoruz
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();//interface istendiğinde gerçek orderwriterepository döndürüyoruz
        }
    }
}