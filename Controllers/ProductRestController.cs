using CatalogueApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogueApp.Controllers{
    [Route("/api/products")]
    public class ProductRestController:Controller{
        public CatalogueDbRepository catalogueRepository { get; set; }

        public ProductRestController(CatalogueDbRepository repository){
            this.catalogueRepository=repository;
        }

        [HttpGet]
        public IEnumerable<Product> listProducts(){
            return catalogueRepository.products.Include(p=>p.Category);
        }

        [HttpGet("{Id}")]
        public Product getProduct(int Id){
            return catalogueRepository.products.Include(p=>p.Category).FirstOrDefault(c=>c.ProductID==Id);
        }

        [HttpPost]
        public Product Save([FromBody]Product product){
            catalogueRepository.products.Add(product);
            catalogueRepository.SaveChanges();
            return product;
        }

        [HttpPut("{Id}")]
        public Product Update([FromBody]Product product, int Id){
            product.ProductID=Id;
            catalogueRepository.products.Update(product);
            catalogueRepository.SaveChanges();
            return product;
        }

        [HttpDelete("{Id}")]
        public void Delete(int Id){
            Product product = catalogueRepository.products.FirstOrDefault(c=>c.ProductID==Id);
            catalogueRepository.Remove(product);
            catalogueRepository.SaveChanges();
        }
    }
}