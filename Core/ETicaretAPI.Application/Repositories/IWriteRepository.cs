using ETicaretAPI.Domain.Entities.Common;

namespace ETicaretAPI.Application.Repositories
{
    public interface IWriteRepository<T> : IRepository<T> where T : BaseEntity //Irepository den türeyeceği için aynı şekilde biz genericimizi class olarak constraint ediyoruz
    {
        Task<bool> AddAsync(T model);

        Task<bool> AddRangeAsync(List<T> datas);

        Task<bool> RemoveAsync(string id);

        bool RemoveRange(List<T> datas);

        bool Remove(T model);

        bool Update(T model);

        Task<int> SaveAsync();
    }
}