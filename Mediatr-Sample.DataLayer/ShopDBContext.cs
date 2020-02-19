using Mediatr_Sample.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mediatr_Sample.DataLayer
{
   public class ShopDBContext:DbContext
    {
        public ShopDBContext(DbContextOptions<ShopDBContext> options):base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}
