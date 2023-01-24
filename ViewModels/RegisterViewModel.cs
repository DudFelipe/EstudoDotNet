using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EstudoDotNet.ViewModels
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "O nome é obrigatório!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "O email é obrigatório!")]
        [EmailAddress(ErrorMessage = "O email é inválido!")]
        public string Email { get; set; }
    }
}