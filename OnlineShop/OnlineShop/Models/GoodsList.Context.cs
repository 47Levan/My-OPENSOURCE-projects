﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class GoodsContainer1 : DbContext
    {
        public GoodsContainer1()
            : base("name=GoodsContainer1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Category> CategorySet { get; set; }
        public virtual DbSet<Product> ProductSet { get; set; }
        public virtual DbSet<SubCategory> SubCategorySet { get; set; }
        public virtual DbSet<DescriptionParametrs> DiscriptionParameters { get; set; }
    }
}
