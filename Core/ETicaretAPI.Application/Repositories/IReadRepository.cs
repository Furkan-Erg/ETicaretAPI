using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : class //Irepository den türeyeceği için aynı şekilde biz genericimizi class olarak constraint ediyoruz
    {
    }
}