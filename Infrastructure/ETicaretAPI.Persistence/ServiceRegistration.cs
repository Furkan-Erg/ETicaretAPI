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
            services.AddSingleton<ICustomerReadRepository, CustomerReadRepository>();//interface istendiğinde gerçek customerreadrepository döndürüyoruz
            services.AddSingleton<ICustomerWriteRepository, CustomerWriteRepository>();//interface istendiğinde gerçek customerwriterepository döndürüyoruz
            services.AddSingleton<IProductReadRepository, ProductReadRepository>();//interface istendiğinde gerçek productreadrepository döndürüyoruz
            services.AddSingleton<IProductWriteRepository, ProductWriteRepository>();//interface istendiğinde gerçek productwriterepository döndürüyoruz
            services.AddSingleton<IOrderReadRepository, OrderReadRepository>();//interface istendiğinde gerçek orderreadrepository döndürüyoruz
            services.AddSingleton<IOrderWriteRepository, OrderWriteRepository>();//interface istendiğinde gerçek orderwriterepository döndürüyoruz
        }
    }
}