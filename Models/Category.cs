using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogueApp.Models{
    [Table("CATEGORIES")]
    public class Category{
        [Key]
        public int CategoryID { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set;}
    }
}