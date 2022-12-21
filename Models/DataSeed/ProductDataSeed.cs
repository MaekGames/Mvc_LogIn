using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using WebAppTask.Data;
using System;
using System.Linq;

namespace WebAppTask.Models.DataSeed
{
    public class ProductDataSeed
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ProductsDataContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<ProductsDataContext>>()))
            {
                // Look for any movies.
                if (context.Product.Any())
                {
                    return;   // DB has been seeded
                }
                /*context.Product.AddRange(
                    new Product
                    {
                        ProductName = "Hdd 1",
                        Count = 17,
                        PriceForPiece = 50,
                        PvnPrice = 12,
                    },
                    new Product
                    {
                        ProductName = "Ram",
                        Count = 17,
                        PriceForPiece = 50,
                        PvnPrice = 12,
                    },
                    new Product
                    {
                        ProductName = "Sdd",
                        Count = 17,
                        PriceForPiece = 50,
                        PvnPrice = 12,
                    },
                    new Product
                    {
                        ProductName = "CPU",
                        Count = 213,
                        PriceForPiece = 53,
                        PvnPrice = 12,
                    }
                );*/
                context.SaveChanges();
            }
        }



    }
}
