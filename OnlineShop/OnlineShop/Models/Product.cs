//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OnlineShop.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    public partial class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "Enter name of product")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter article of product")]
        public string Article { get; set; }
        [Required(ErrorMessage = "Enter description of product")]
        public string Description { get; set; }
        [Required(ErrorMessage = "Enter price of product")]
        public decimal Price { get; set; }
        [Required(ErrorMessage = "Select picture of product")]
        public byte[] Picture { get; set; }
        [Required(ErrorMessage = "Enter date of product")]
        public System.DateTime DateAdded { get; set; }
        [Required(ErrorMessage = "Choose subcategory of product")]
        public virtual SubCategory SubCategory { get; set; }
        public int selectedSub { get; set; }
    }
}
