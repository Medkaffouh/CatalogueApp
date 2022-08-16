

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

                if (!context.categories.Any())
                {
                    Console.WriteLine("Data Initialization...");
                    context.categories.AddRange(
                    new Category(){ Name = "Mohamed Kaffouh" },
                    new Category(){ Name = "Fatiha Saf" },
                    new Category(){ Name = "Med Aya" },
                    new Category(){ Name = "Kawtar Kiki" },
                    new Category(){ Name = "Mostafa mahmoud" },
                    new Category(){ Name = "Khalid ray" },
                    new Category(){ Name = "Mari do" },
                    new Category(){ Name = "Adam dom" }
                    );

                    context.SaveChanges();
                }
            }
        }

    }
}