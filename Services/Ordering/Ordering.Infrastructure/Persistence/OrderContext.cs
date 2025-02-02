﻿using Microsoft.EntityFrameworkCore;

using Ordering.Domain.Entitites;
using System.Collections.Generic;

namespace Ordering.Infrastructure.Persistence
{
    public class OrderContext : DbContext
    {
        public OrderContext(DbContextOptions<OrderContext> options) : base(options)
        {
        }

        public DbSet<Order> Orders { get; set; }
    }
}
