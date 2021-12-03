using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BGlobal.Models
{
    public class Vehiculo
    {

        [Key]
        public int IdVehiculo { get; set; }

        [StringLength(8, ErrorMessage = "Exceso de caracteres")]
        [Required(ErrorMessage = "Patente requerido")]

        public String Patente { get; set; }

        [Required(ErrorMessage = "Marca requerido")]
        [Display(Name = "Marca")]
        public String Marca { get; set; }
        [Required(ErrorMessage = "Modelo requerido")]
        [Display(Name = "Modelo")]
        public String Modelo { get; set; }


        [Range(2, 5, ErrorMessage = "ingrese un valor de 2 a 5")]
        public int Puertas { get; set; }
        [Required(ErrorMessage = "Titular requerido")]
        [Display(Name = "Titular")]
        public String Titular { get; set; }

    }
}
