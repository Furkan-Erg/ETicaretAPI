using ETicaretAPI.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Contexts
{
    public class ETicaretAPIDbContext : DbContext //entity framework core daki dbcontext ten inherit alıyoruz
    {
        public ETicaretAPIDbContext(DbContextOptions options) : base(options) //generate constructor
        {
        }

        //burda tablolarımızın adını belirtiyoruz

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Customer> Customers { get; set; }
    }
}