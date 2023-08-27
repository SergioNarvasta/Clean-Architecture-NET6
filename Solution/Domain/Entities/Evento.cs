
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Utils.Enums;

namespace Domain.Entities
{
    public class Evento
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; }
        [Required]
        public DateTime Fecha { get; set; }
        [Required]
        public int Duracion { get; set; }
        [Required]
        public int NroParticipantes { get; set; }
        [Required]
        public int NroComisarios { get; set; }
        [DefaultValue(Estados.Active)]
        public Estados Estado { get; set; }

        public int ComplejoDeportivoId { get; set; }
        [ForeignKey("ComplejoDeportivoId")]
        public ComplejoDeportivo ComplejoDeportivo { get; set; }
    }
}

    

