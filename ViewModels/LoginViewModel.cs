using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoDotNet.ViewModels
{
    public class LoginViewModel
    {

        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "O email é inválido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A senha é obrigatória!")]
        public string Password { get; set; }
    }
}