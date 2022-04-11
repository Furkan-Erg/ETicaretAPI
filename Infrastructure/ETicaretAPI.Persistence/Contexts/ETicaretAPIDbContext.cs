﻿using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Domain.Entities.Common;
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

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)//save changes kısmına interceptor koyuyoruz insert ve updateler için
        {
            //DbContext ten geliyor değişikliği alıyoruz ve bunlarda time kısmını intercept ederek güncelliyoruz
            ChangeTracker.Entries<BaseEntity>()
                .Where(e => e.State == EntityState.Added || e.State == EntityState.Modified)
                .ToList()
                .ForEach(e =>
                {
                    if (e.State == EntityState.Added)
                    {
                        e.Entity.CreatedDate = DateTime.UtcNow;
                    }
                    e.Entity.UpdatedDate = DateTime.UtcNow;
                });

            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}