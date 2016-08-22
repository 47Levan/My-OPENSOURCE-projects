using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Mail;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
namespace OnlineShop.Models.Authentication
{
    public  class SignIn
    {
        [Required(ErrorMessage ="Please enter email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please enter password")]
        [StringLength(100, ErrorMessage ="The {0} must be at least {2} characters long.",MinimumLength =6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [HiddenInput]
        public string returnUrl { get; set; }
    }
}
