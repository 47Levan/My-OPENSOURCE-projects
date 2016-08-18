using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace OnlineShop.Models
{
    public enum Categories
    {
        Smart_Phones,
        Computers,
        Hi_Tech,
        HeadPhones,
        Internet
    }
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded{get; set;}
        public string ShortDiscription { get; set; }
        public Categories categories { get; set; }
        public string PreviewPicture { get; set; }
        public string FullPageLink { get; set; }
    }
}
