﻿using ETicaretAPI.Application.Repositories;
using ETicaretAPI.Domain.Entities;
using ETicaretAPI.Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETicaretAPI.Persistence.Repositories
{
    public class OrderReadRepository : ReadRepository<Order>, IOrderReadRepository//inherit from readrepository also use IORRepo for dependecy inj
    {
        public OrderReadRepository(ETicaretAPIDbContext context) : base(context)
        {
        }
    }
}