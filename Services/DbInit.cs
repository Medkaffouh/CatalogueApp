

using CatalogueApp.Models;

namespace CatalogueApp.Services
{
    public static class DbInit
    {

        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var serviceScope = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<CatalogueDbRepository>();
                Console.WriteLine("Data Initialization...");
                if (!context.categories.Any())
                {
                    context.categories.AddRange(
                        new Category() { Name = "Mohamed Kaffouh" },
                        new Category() { Name = "Fatiha Saf" },
                        new Category() { Name = "Med Aya" },
                        new Category() { Name = "Kawtar Kiki" },
                        new Category() { Name = "Mostafa mahmoud" },
                        new Category() { Name = "Khalid ray" },
                        new Category() { Name = "Mari do" },
                        new Category() { Name = "Adam dom" }
                    );

                    context.SaveChanges();
                }
                if (!context.products.Any())
                {
                    context.products.AddRange(
                        new Product() { Name = "Ordinateur G1", Price = 423, CategoryID = 2 },
                        new Product() { Name = "Imprimant T1", Price = 523, CategoryID = 1 },
                        new Product() { Name = "Ordinateur G1", Price = 823, CategoryID = 2 },
                        new Product() { Name = "Imprimant G1", Price = 634, CategoryID = 1 },
                        new Product() { Name = "Imprimant G2", Price = 934, CategoryID = 1 },
                        new Product() { Name = "Ordinateur G1", Price = 444, CategoryID = 3 }
                    );

                    context.SaveChanges();
                }
            }
        }

    }
}