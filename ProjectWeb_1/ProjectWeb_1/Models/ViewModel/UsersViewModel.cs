using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ProjectWeb_1.Models.ViewModel
{
    public class QueryViewModel
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public int? Edad {  get; set; }

    }

    public class AddUsersViewModel
    {
        [Required]
        [Display(Name ="Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage ="Escriba el correo", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasenna { get; set; }

        [Required]
        [Display(Name = "Confirmar Contrasenna")]
        [DataType(DataType.Password)]
        [Compare("Contrasenna", ErrorMessage = "Deben coincidir las contraseñas")]
        public string ConfirmarContrasenna { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int Edad {  get; set; }
    }

    public class EditUsersViewModel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Nombre")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Email")]
        [EmailAddress]
        [StringLength(100, ErrorMessage = "Escriba el correo", MinimumLength = 6)]
        public string Email { get; set; }

        [Required]
        [Display(Name = "Contraseña")]
        [DataType(DataType.Password)]
        public string Contrasenna { get; set; }

        [Required]
        [Display(Name = "Confirmar Contrasenna")]
        [DataType(DataType.Password)]
        [Compare("Contrasenna", ErrorMessage = "Deben coincidir las contraseñas")]
        public string ConfirmarContrasenna { get; set; }

        [Required]
        [Display(Name = "Edad")]
        public int? Edad { get; set; }
    }
}