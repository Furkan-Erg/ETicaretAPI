using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Application.Repositories
{
    public interface IRepository<T> where T : class // generic yapabilmek için T diyoruz fakat DbSet sadece Class kabul ediyor bu yüzden biz generic imizi constraint ediyoruz
    {
        DbSet<T> Table { get; }//database deki karşılığımız Table olduğu için get yaptık
    }
}