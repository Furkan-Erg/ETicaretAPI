using ETicaretAPI.Domain.Entities.Common;
using System.Linq.Expressions;

namespace ETicaretAPI.Application.Repositories
{
    public interface IReadRepository<T> : IRepository<T> where T : BaseEntity //Irepository den türeyeceği için aynı şekilde biz genericimizi class olarak constraint ediyoruz
    {
        IQueryable<T> GetAll(bool tracking = true);//list yapmıyoruz çünkü o daha local odaklı IEnumarator ile döner ama bize query için gerekli olan IQueryable<T> dönecek

        //default olarak true olan tracking parametresini ekliyoruz
        IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true);//getwhere methodu ile sorgu yapıyoruz bool yazdığımız için doğruysa data döner ismide "method"

        Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true);//get single methodu ile sorgu yapıyoruz bool yazdığımız için doğruysa ilk data döner (firt or default async olacağı için task<t> ve isimlendirmede async kullandık

        Task<T> GetByIdAsync(string id, bool tracking = true);//id ye göre getirme işlemi yapıyoruz async olacağı için task<t> ve isimlendirmede async kullandık
    }
}