using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace TaskManager.Models
{
    public class ChangePasswordModel
    {
        [Required, DataType(DataType.Password), Display(Name = "Aktualne hasło")]
        public string CurrentPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Nowe hasło")]
        public string NewPassword { get; set; }
        [Required, DataType(DataType.Password), Display(Name = "Potwierdź nowe hasło")]
        [Compare("NewPassword", ErrorMessage = "Potwierdzenie nowego hasła nie zgadza się")]

        public string ConfirmNewPassword { get; set; }
    }
}
