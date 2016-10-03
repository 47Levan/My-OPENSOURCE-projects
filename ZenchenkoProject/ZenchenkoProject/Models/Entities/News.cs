using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace ZenchenkoProject.Models.Entities
{
    public class News
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public int id { get; set; }
        public string Title { get; set; }
        public DateTime DateAdded { get; set; }
        public string ShortDiscription { get; set; }
        public string PreviewPicture { get; set; }
        public string FullPageLink { get; set; }
    }
}
