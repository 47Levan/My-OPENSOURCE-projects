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
    
    public partial class Product
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Product()
        {
            this.DescriptionParametrs = new HashSet<DescriptionParametrs>();
        }
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string Article { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public byte[] Picture { get; set; }
        public System.DateTime DateAdded { get; set; }
        public int SubCategoryId { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DescriptionParametrs> DescriptionParametrs { get; set; }
        public virtual SubCategory SubCategory { get; set; }
    }
}
