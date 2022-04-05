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

        public IQueryable<T> GetAll()
         => Table; //table dbset tir bu yüzden table.getall() yazılmaz

        public async Task<T> GetByIdAsync(string id)
        => await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));//string id yi guid e çevirip verimizi getiriyoruz

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method)
       => await Table.FirstOrDefaultAsync(method);

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method)
       => Table.Where(method);
    }
}