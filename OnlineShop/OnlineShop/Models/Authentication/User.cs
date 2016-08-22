using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNet.Identity.EntityFramework;
namespace OnlineShop.Models.Authentication
{
    public class User :IdentityUser
    {     
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string Country { get; set; }
        public int? Age { get; set; }
    }
}
