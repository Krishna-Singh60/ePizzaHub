using System.ComponentModel.DataAnnotations;

namespace ePizzaHub.UI.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "Please Enter a Email")]
        [EmailAddress(ErrorMessage ="Please Enter Valid Email")]
        public string Email { get; set; }

        [Required(ErrorMessage ="Please Enter Password")]
        public string Password { get; set; }
    }
}
