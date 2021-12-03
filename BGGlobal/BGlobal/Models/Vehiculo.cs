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
        public String Patente { get; set; }

        public String Marca { get; set; }

        public String Modelo { get; set; }


        [Range(2, 5, ErrorMessage = "ingrese un valor de 2 a 5")]
        public int Puertas { get; set; }

        public String Titular { get; set; }

    }
}
