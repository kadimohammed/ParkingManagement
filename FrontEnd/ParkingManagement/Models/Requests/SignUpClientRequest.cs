using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Models.Requests
{
    public class SignUpClientRequest
    {
        [Required(ErrorMessage = "Le nom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le nom ne doit pas dépasser 50 caractères")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "Le prénom est obligatoire")]
        [StringLength(50, ErrorMessage = "Le prénom ne doit pas dépasser 50 caractères")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "L'email est obligatoire")]
        [EmailAddress(ErrorMessage = "Format d'email invalide")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Le mot de passe est obligatoire")]
        [StringLength(100, ErrorMessage = "Le mot de passe doit contenir au moins {2} caractères", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; } = "";

        [Required(ErrorMessage = "Le numéro de téléphone est obligatoire")]
        [Phone(ErrorMessage = "Le numéro de téléphone n'est pas valide")]
        [Display(Name = "Téléphone")]
        public string Phone { get; set; }
    }
}
