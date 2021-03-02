using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ServingYouAdmin.Data;
using ServingYouAdmin.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServingYouAdmin.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ServingYouContext(
                serviceProvider.GetRequiredService<DbContextOptions<ServingYouContext>>()))
            {
                if (context.Bookings.Any()) {
                    return;
                }

                if (context.Menus.Any())
                {
                    return; // DB hass been seeded
                }

                context.Menus.AddRange(
                    new Menu
                    {
                        Name = "King Sushi",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum omnis " +
                      "cum veniam commodi, maiores totam exercitationem officiis, molestiae ipsum voluptatum " +
                      "eius quia dignissimos reprehenderit, at illo atque doloremque fugiat nam!",
                        Available = true,
                        Category = MenuCategory.Japanes,
                        Price = 18.00m,
                        DateCreated = Convert.ToDateTime("20/11/2020")
                    },

                    new Menu
                    {
                        Name = "Tuna Sasimi",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum omnis " +
                      "cum veniam commodi, maiores totam exercitationem officiis, molestiae ipsum voluptatum " +
                      "eius quia dignissimos reprehenderit, at illo atque doloremque fugiat nam!",
                        Available = true,
                        Category = MenuCategory.Japanes,
                        Price = 25.00m,
                        DateCreated = Convert.ToDateTime("01/11/2020")
                    },

                    new Menu
                    {
                        Name = "Delux Pizza Large",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum omnis " +
                      "cum veniam commodi, maiores totam exercitationem officiis, molestiae ipsum voluptatum " +
                      "eius quia dignissimos reprehenderit, at illo atque doloremque fugiat nam!",
                        Available = true,
                        Category = MenuCategory.Italian,
                        Price = 20.00m,
                        DateCreated = Convert.ToDateTime("03/11/2020")
                    },

                    new Menu
                    {
                        Name = "Sea Food Ramen",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum omnis " +
                      "cum veniam commodi, maiores totam exercitationem officiis, molestiae ipsum voluptatum " +
                      "eius quia dignissimos reprehenderit, at illo atque doloremque fugiat nam!",
                        Available = true,
                        Category = MenuCategory.Japanes,
                        Price = 17.00m,
                        DateCreated = Convert.ToDateTime("01/11/2020")
                    },

                    new Menu
                    {
                        Name = "T-bone steak",
                        Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Rerum omnis " +
                      "cum veniam commodi, maiores totam exercitationem officiis, molestiae ipsum voluptatum " +
                      "eius quia dignissimos reprehenderit, at illo atque doloremque fugiat nam!",
                        Available = true,
                        Category = MenuCategory.Italian,
                        Price = 21.00m,
                        DateCreated = Convert.ToDateTime("01/11/2020")
                    }
                );
                context.SaveChanges();
            }
        }
    }
}
