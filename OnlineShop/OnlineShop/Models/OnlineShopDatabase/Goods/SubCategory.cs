using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models.OnlineShopDatabase.Goods
{
    public class SubCategory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Subcategory { get; set; }
        public virtual ICollection<Product> Product { get; set; }
        public Guid Category_Id { get; set; }
        [ForeignKey("Category_Id")]
        public virtual Category Category { get; set; }
    }
}
