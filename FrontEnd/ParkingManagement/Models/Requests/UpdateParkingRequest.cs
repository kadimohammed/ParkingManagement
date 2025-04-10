using Microsoft.AspNetCore.Components.Forms;
using System.ComponentModel.DataAnnotations;

namespace ParkingManagement.Models.Requests
{
    public class UpdateParkingRequest
    {
        public int Id { get; set; }

        [Range(-90, 90, ErrorMessage = "La latitude doit être comprise entre -90 et 90.")]
        public double Latitude { get; set; }

        [Range(-180, 180, ErrorMessage = "La longitude doit être comprise entre -180 et 180.")]
        public double Longitude { get; set; }

        [Required(ErrorMessage = "Le nom du parking est obligatoire.")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Le nom doit comporter entre 3 et 100 caractères.")]
        public string NomParcking { get; set; }

        [Required(ErrorMessage = "L'adresse est obligatoire.")]
        [StringLength(200, ErrorMessage = "L'adresse ne doit pas dépasser 200 caractères.")]
        public string Adresse { get; set; }

        [Range(0.1, double.MaxValue, ErrorMessage = "La surface doit être supérieure à 0.")]
        public double Surface { get; set; }

        [Required(ErrorMessage = "L'heure de début est obligatoire.")]
        public TimeOnly TimeStartWork { get; set; }

        [Required(ErrorMessage = "L'heure de fin est obligatoire.")]
        public TimeOnly TimeEndWork { get; set; }

        [Required(ErrorMessage = "La date de création est obligatoire.")]
        public DateOnly CreationDate { get; set; }

        [Required(ErrorMessage = "L'image est obligatoire.")]
        public IBrowserFile Picture { get; set; }

        public bool IsWorking { get; set; }

        public bool[] Days { get; set; } = new bool[7];
    }
}
