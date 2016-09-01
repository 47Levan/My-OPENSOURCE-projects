using System;
using System.Collections.Generic;
using OnlineShop.Models.OnlineShopDatabase.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models.OnlineShopDatabase.Goods
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public double Price { get; set; }
        public string Picture { get; set; }
        public System.DateTime DateAdded { get; set; }
        public Guid SubCategory_Id { get; set; }
        public virtual ICollection<DescriptionParameters> Descriptions { get; set; }
        public virtual ICollection<User> User { get; set; }
        [ForeignKey("SubCategory_Id")]
        public virtual SubCategory SubCategory { get; set; }
    }
}
