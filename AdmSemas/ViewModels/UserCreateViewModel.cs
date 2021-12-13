using System.ComponentModel.DataAnnotations;
using AdmSemas.Models;

namespace AdmSemas.ViewModels
{
    public class UserCreateViewModel
    {
        [Required(ErrorMessage = "Campo Matrícula é obrigatório")]
        public string Nome { get; set; }
        
        [EmailAddress(ErrorMessage = "Campo de email é obrigatório")]
        public string Email { get; set; }
        
        [Required(ErrorMessage = "Campo CPF é obrigatório")]
        [MaxLength(11, ErrorMessage = "CPF deve ter 11 caracteres")]
        [MinLength(11, ErrorMessage = "CPF deve ter 11 caracteres")]
        [RegularExpression("^[0-9]*$", ErrorMessage = "CPF deve ser numerico")]
        public string Cpf { get; set; }

        [Required(ErrorMessage = "Campo Senha é obrigatório")]
        public string Senha { get; set; }  
        
        public User GetModel(string cpf, string nome, string senha, string email)
        {
            return new User()
            {
                Nome = nome,
                Username = cpf,
                Password = senha,
                Email = email
            };
        }
    }
}