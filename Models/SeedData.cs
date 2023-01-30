using Bakery.Data;
using Microsoft.EntityFrameworkCore;

namespace Bakery.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new BakeryContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<BakeryContext>>()))    
            {
                if (context == null || context.Products == null)
                {
                    throw new ArgumentNullException("Null BakeryContext");
                }

                // Look for any products.
                if (context.Products.Any())
                {
                    return;   // DB has been seeded
                }
                context.Products.AddRange(
                new Product
                {
                    Name = "Carrot Cake",
                    Description = "A scrumptious mini-carrot cake encrusted with sliced almonds",
                    Price = 8.99m,
                    ImageName = "carrot_cake.jpg"
                },
                new Product
                {
                   
                    Name = "Lemon Tart",
                    Description = "A delicious lemon tart with fresh meringue cooked to perfection",
                    Price = 9.99m,
                    ImageName = "lemon_tart.jpg"
                },
                new Product
                {
                   
                    Name = "Cupcakes",
                    Description = "Delectable vanilla and chocolate cupcakes",
                    Price = 5.99m,
                    ImageName = "cupcakes.jpg"
                },
                new Product
                {
                    
                    Name = "Bread",
                    Description = "Fresh baked French-style bread",
                    Price = 1.49m,
                    ImageName = "bread.jpg"
                },
                new Product
                {
                   
                    Name = "Pear Tart",
                    Description = "A glazed pear tart topped with sliced almonds and a dash of cinnamon",
                    Price = 5.99m,
                    ImageName = "pear_tart.jpg"
                },
                new Product
                {
                   
                    Name = "Chocolate Cake",
                    Description = "Rich chocolate frosting cover this chocolate lover's dream",
                    Price = 8.99m,
                    ImageName = "chocolate_cake.jpg"
                }
            );
                context.SaveChanges();
            }
        }
    }
}
