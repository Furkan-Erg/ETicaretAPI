using ETicaretAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IOrderReadRepository : IReadRepository<Order>//generic yapmamıza gerek yok çünkü bunun order olduğu kesin
    {
    }
}