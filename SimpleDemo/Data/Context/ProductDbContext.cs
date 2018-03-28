using Microsoft.EntityFrameworkCore;
using SimpleDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SimpleDemo.Data.Context
{
    public class ProductDbContext: DbContext
    {
		public ProductDbContext(DbContextOptions<ProductDbContext> options) : base(options)
		{

		}

		public DbSet<Product> Products { get; set; }
    }
}
