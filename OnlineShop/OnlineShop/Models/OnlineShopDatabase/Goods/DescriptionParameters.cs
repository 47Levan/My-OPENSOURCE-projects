using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models.OnlineShopDatabase.Goods
{
    public class DescriptionParameters
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string DescriptionParameter { get; set; }
        public Guid Product_Id { get; set; }
        [ForeignKey("Product_Id")]
        public virtual Product Product { get; set; }
    }
}
