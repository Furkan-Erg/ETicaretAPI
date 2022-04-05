using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace ETicaretAPI.Persistence.Repositories
{
    public class ReadRepository<T> : IReadRepository<T> where T : BaseEntity //concrete sınıf interface implement ederken içinide implement etmeliyiz
    {
        private readonly ETicaretAPIDbContext _context;//read işlemleri için context i taleb ediyoruz

        public ReadRepository(ETicaretAPIDbContext context)//constructer injection
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>();//set diyerek contexti genericleştirebiliyoruz

        public IQueryable<T> GetAll(bool tracking = true)//table döndüren method
        {//tracking istenmiyorsa tracki kesiyoruz
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }

        public async Task<T> GetByIdAsync(string id, bool tracking = true)

        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id)); //string id yi guid e çevirip verimizi getiriyoruz

        //=> await Table.FindAsync(Guid.Parse(id));//efcore find metodu ile id ye göre getiriyoruz bide string id yi guid e çevirip verimizi getiriyoruz
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));//marker async kullanmam lazım çünkü tracking query optimizasyonda efcore find çalışmıyor
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return await query.FirstOrDefaultAsync(method);
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.Where(method).AsQueryable();
            if (!tracking)
            {
                query = query.AsNoTracking();
            }
            return query;
        }
    }
}