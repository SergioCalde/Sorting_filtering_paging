using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Sorting_Filtering_Paging.Models
{
    public class Estudiante
    {
        [Required]
        [DisplayName("ID")]
        public int estudianteID { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Nombre Estudiante")]
        public string nombreEstudiante { get; set; }
        [Required]
        [StringLength(10)]
        [DisplayName("Apellido Estudiante")]
        public string apellidosEstudiante { get; set; }
        [Required]
        [StringLength(30)]
        [DisplayName("Correo Estudiante")]
        public string correoEstudiante { get; set; }
        [Required]
        [DisplayName("Edad Estudiante")]
        public int edadEstudiante { get; set; }
    }

    public enum BuscarPor
    {
        Nombre,
        Apellido
    }
}