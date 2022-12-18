using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAppTask.Models;

namespace WebAppTask.Data
{
    public class ProductsDataContext : DbContext
    {
        public ProductsDataContext (DbContextOptions<ProductsDataContext> options)
            : base(options)
        {
        }

        public DbSet<WebAppTask.Models.Product> Product { get; set; } = default!;
    }
}
