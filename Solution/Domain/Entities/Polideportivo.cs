
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Utils.Enum.Enums;

namespace Domain.Entities
{
    public class Polideportivo
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public int Capacidad { get; set; }

        [Required(ErrorMessage = "El campo Hora de Inicio es requerido")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime InicioAtencion { get; set; }

        [Required(ErrorMessage = "El campo Hora de Fin es requerido")]
        [DataType(DataType.Time)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime FinAtencion { get; set; }

        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }

        [Required]
        public int ComplejoDeportivoId { get; set; }
        [ForeignKey("ComplejoDeportivoId")]
        public ComplejoDeportivo? ComplejoDeportivo { get; set; }
    }

}


