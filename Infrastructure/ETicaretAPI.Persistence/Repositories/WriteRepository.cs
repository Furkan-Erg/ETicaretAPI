using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities.Common;
using ETicaretAPI.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class WriteRepository<T> : IWriteRepository<T> where T : BaseEntity
    {
        private readonly ETicaretAPIDbContext _context; //readonly contexti taleb ediyoruz

        public WriteRepository(ETicaretAPIDbContext context)//constructer injection
        {
            _context = context;
        }

        public DbSet<T> Table => _context.Set<T>(); //db seti çağırıyoruz

        public async Task<bool> AddAsync(T model)//db ye ekleme işlemi
        {
            EntityEntry<T> entityEntry = await Table.AddAsync(model); //entity entry ile modeli ekliyoruz
            return entityEntry.State == EntityState.Added;//entityEntry nin stateni added diye güncelliyoruz
        }

        public async Task<bool> AddRangeAsync(List<T> datas)
        {
            await Table.AddRangeAsync(datas);//birden çok datayı ekliyoruz
            return true;
        }

        public async Task<bool> RemoveAsync(string id)
        {
            T model = await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));//async bir şekilde id ye göre modeli getiriyoruz
            return Remove(model);//altaki remove u çağırıyoruz code repeat olmasın diye
        }

        public bool Remove(T model)//db silme işlemi
        {
            EntityEntry<T> entityEntry = Table.Remove(model);//tabledan siliyor
            return entityEntry.State == EntityState.Deleted;//entity state i deleted diye güncelliyoruz
        }

        public bool RemoveRange(List<T> datas)
        {
            Table.RemoveRange(datas);//birden çok datayı siliyoruz
            return true;
        }

        public async Task<int> SaveAsync()
        => await _context.SaveChangesAsync();//async bir şekilde save ediyoruz

        public bool Update(T model)//update func
        {
            EntityEntry entityEntry = Table.Update(model); // tabloyu güncelliyoruz
            return entityEntry.State == EntityState.Modified; //entity state  i modified diye güncelliyoruz
        }
    }
}