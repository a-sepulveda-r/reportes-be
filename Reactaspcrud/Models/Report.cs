using System;
using System.ComponentModel.DataAnnotations;

namespace Reactaspcrud.Models
{
    public class Report
    {
        [Key]
        public int id { get; set; }

        [Required(ErrorMessage = "La Fecha es obligatoria.")]
        [DataType(DataType.Date, ErrorMessage = "El campo Fecha debe ser una fecha válida.")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "La Descripción es obligatoria.")]
        [MaxLength(500, ErrorMessage = "La Descripción no puede exceder los 500 caracteres.")]
        public string Descripcion { get; set; }

        [Required(ErrorMessage = "Las Acciones Inmediatas es obligatoria.")]
        [MaxLength(500, ErrorMessage = "Las Acciones Inmediatas no puede exceder los 500 caracteres.")]
        public string AccionesInmediatas { get; set; }

        [Required(ErrorMessage = "Antecedentes es obligatorio.")]
        [MaxLength(500, ErrorMessage = "Antecedentes no puede exceder los 500 caracteres.")]
        public string Antecedentes { get; set; }

        [Required(ErrorMessage = "Las Atencion Al Evento es obligatoria.")]
        [MaxLength(500, ErrorMessage = "Las Atencion Al Evento no puede exceder los 500 caracteres.")]
        public string AtencionAlEvento { get; set; }

        [Required(ErrorMessage = "EL Personal involucrado es obligatorio.")]
        [MaxLength(500, ErrorMessage = "EL Personal involucrado no puede exceder los 500 caracteres.")]
        public string PersonalInvolucrado { get; set; }

        [Required(ErrorMessage = "El Impacto es obligatorio.")]
        [RegularExpression("ALTO|MEDIO|BAJO", ErrorMessage = "El Impacto debe ser ALTO, MEDIO o BAJO.")]
        public string Impacto { get; set; }

        public string imagePath { get; set; }
    }
}
