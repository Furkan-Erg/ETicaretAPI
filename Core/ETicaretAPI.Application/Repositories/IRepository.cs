using ETicaretAPI.Domain.Entities.Common;
using Microsoft.EntityFrameworkCore;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : BaseEntity // generic yapabilmek için T diyoruz fakat DbSet sadece Class kabul ediyor bu yüzden biz generic imizi constraint ediyoruz
    {
        DbSet<T> Table { get; }//database deki karşılığımız Table olduğu için get yaptık
    }
}