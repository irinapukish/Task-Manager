using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class SignUpUserModel
    {
        [Required(ErrorMessage = "Proszę podać swoje imię")]
        public string FirstName { get; set; }
        public string LastName { get; set; }

        [Required(ErrorMessage = "Proszę wpisać swój adres e-mail")]
        [Display(Name = "Email")]
        [EmailAddress(ErrorMessage = "Proszę podać poprawny adres e-mail")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Proszę wprowadzić hasło")]
        [Compare("ConfirmPassword", ErrorMessage = "Hasło się nie zgadza")]
        [Display(Name = "Hasło")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Proszę powtórzyć hasło")]
        [Display(Name = "Powtórz hasło")]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
    }
}
