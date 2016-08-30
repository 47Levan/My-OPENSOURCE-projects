using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace OnlineShop.Models.Authentication
{
    public class SignUp
    {
        public string Id { get; set; }
        [Required(ErrorMessage = "Enter your UserName please")]
        public string UserName { get; set; }      
        public string FirstName { get;set; }
        public string SecondName { get; set; }
        public int Age { get; set; }
        public string Country { get; set; }
        [Required(ErrorMessage = "Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string EmailAdress { get; set; }
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Enter your password please")]
        public string Password { get; set; }
        public string PhoneNumber { get; set; }
    }
}
