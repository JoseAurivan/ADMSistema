using System.ComponentModel.DataAnnotations;

namespace AdmSemas.ViewModels
{
    public class LoginTiViewModel
    {
        public readonly string Username = "PortoTI";
        public readonly string Password = "$$admP2020G7";
        
        [Required]
        public string TypedUser { get; set; }
        [Required]
        public string TypedPassword { get; set; }
    }
}