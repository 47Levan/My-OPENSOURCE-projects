﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models.OnlineShopDatabase.Goods
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string category { get; set; }
        public string PictureRef { get; set; }
        public virtual ICollection<SubCategory> SubCategory { get; set; }
    }
}
