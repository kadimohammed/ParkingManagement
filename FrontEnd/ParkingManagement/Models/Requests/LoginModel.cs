using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Models.Requests
{
    public class LoginModel
    {
        [Required(ErrorMessage = "L'email est requis.")]
        [EmailAddress(ErrorMessage = "Veuillez entrer un email valide.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est requis.")]
        [StringLength(100, MinimumLength = 6, ErrorMessage = "Le mot de passe doit comporter au moins 6 caractères.")]
        public string Password { get; set; }
    }
}
