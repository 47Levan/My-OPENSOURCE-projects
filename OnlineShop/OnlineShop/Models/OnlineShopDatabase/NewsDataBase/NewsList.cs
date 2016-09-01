using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models.OnlineShopDatabase.NewsDataBase
{
    public enum Categories
    {
        Smart_Phones,
        Computers,
        Hi_Tech,
        HeadPhones,
        Internet
    }
    public class NewsList
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public string ShortDiscription { get; set; }
        public Categories categories { get; set; }
        public string PreviewPicture { get; set; }
        public string FullPageLink { get; set; }
    }
}
