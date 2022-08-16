using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers{
    [Route("/api/categories")]
    public class CategoryRestController:Controller{
        public CatalogueDbRepository catalogueRepository { get; set; }

        public CategoryRestController(CatalogueDbRepository repository){
            this.catalogueRepository=repository;
        }

        [HttpGet]
        public IEnumerable<Category> listCats(){
            return catalogueRepository.categories;
        }

        [HttpGet("{Id}")]
        public Category getCat(int Id){
            return catalogueRepository.categories.FirstOrDefault(c=>c.CategoryID==Id);
        }

        [HttpGet("{Id}/products")]
        public IEnumerable<Product> products(int Id){
            Category category = catalogueRepository.categories.Include(c=>c.Products).FirstOrDefault(c=>c.CategoryID==Id);
            return category.Products;
        }

        [HttpPost]
        public Category Save([FromBody]Category category){
            catalogueRepository.categories.Add(category);
            catalogueRepository.SaveChanges();
            return category;
        }

        [HttpPut("{Id}")]
        public Category Update([FromBody]Category category, int Id){
            category.CategoryID=Id;
            catalogueRepository.categories.Update(category);
            catalogueRepository.SaveChanges();
            return category;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Category category = catalogueRepository.categories.FirstOrDefault(c=>c.CategoryID==Id);
            catalogueRepository.Remove(category);
            catalogueRepository.SaveChanges();
        }
    }
}