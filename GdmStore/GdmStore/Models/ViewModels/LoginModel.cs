using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace GdmStore.ViewModels
{
    public class LoginModel
    {   //[Required]
        [Required(ErrorMessage = "Не указан Email")]
        public string Email { get; set; }
        //[Required]
        [Required(ErrorMessage = "Не указан пароль")]
        //[DataType(DataType.Password)]
        public string Password { get; set; }
        //[Required]
        //public string Name { get; set; }
        //[Required]
        //[UIHint("password")]
        //public string Password { get; set; }
        //public string ReturnUrl { get; set; } = "/";
    }
}
